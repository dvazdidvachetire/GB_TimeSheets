using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly ICustomersRepository _customersRepository;
        public EmployeeService(IEmployeesRepository employeesRepository,
            IJobRepository jobRepository,
            ITimeSheetRepository timeSheetRepository,
            ICustomersRepository customersRepository)
        {
            _jobRepository = jobRepository;
            _employeesRepository = employeesRepository;
            _timeSheetRepository = timeSheetRepository;
            _customersRepository = customersRepository;
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            return await _employeesRepository.CreateObjects(employee);
        }

        public async Task<JobDto> GetJobEmployee(int id, int idJ)
        {
            var employee = await GetEmployee(id);

            var jobs = await _jobRepository.GetObjects();
            var job = await Task.Run(() => jobs.SingleOrDefault(j => j.Employee == employee));

            var timeSheetsJob = await GetTimeSheetsJob(job);

            var mc = await Task.Run(() => new MapperConfiguration(cfg => cfg.CreateMap<TimeSheet, TimeSheetDto>()
                .ForMember(dest => dest.EmployeeName, act => act.MapFrom(src => src.Employee.FullName))));
            var mapper = mc.CreateMapper();

            var timeSheetsJobDto = await Task.Run(() => mapper.Map<IReadOnlyList<TimeSheet>, IReadOnlyList<TimeSheetDto>>(timeSheetsJob));

            return await Map(timeSheetsJobDto, job);
        }

        public async Task<IReadOnlyList<JobDto>> GetJobs(int id)
        {
            //TODO: доделать
            var employee = await GetEmployee(id);

            var jobs = await _jobRepository.GetObjects();
            var jobsEmployee = await Task.Run(() => jobs.Where(j => j.Employee == employee).ToList());

            

            

            return null;
        }

        public async Task<IReadOnlyList<JobForEmployeeDto>> GetJobs()
        {
            var jobs = await _jobRepository.GetObjects();
            var customers = await _customersRepository.GetObjects();

            return await Task.Run(() => jobs.Join(customers,
                j => j.Customer.Id,
                c => c.Id,
                (job, customer)
                    => new JobForEmployeeDto 
                    { CustomerName = customer.FullName, 
                        Title = job.Title, 
                        Description = job.Description,
                        Amount = job.Amount
                    }).ToList());
        }

        public async Task<bool> ChangeEmployee(int id, Employee employee)
        {
            return await _employeesRepository.UpdateObjects(id, employee);
        }

        public async Task<bool> CreateTimeSheet(int idE, int id, TimeSheet timeSheet)
        {
            var jobs = await _jobRepository.GetObjects();
            var job = await Task.Run(() => jobs.SingleOrDefault(j => j.Id == id));

            timeSheet.JobId = job.Id;
            timeSheet.Employee = await GetEmployee(idE);
            job.Employee = await GetEmployee(id);

            await _timeSheetRepository.CreateObjects(timeSheet);

            var timeSheets = await GetTimeSheetsJob(job);
            var timeSheetsJob = await Task.Run(() => timeSheets.Where(t => t.JobId == job.Id).ToList());

            job.TimeSheets = timeSheetsJob;

            return await _jobRepository.UpdateObjects(id, job);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
           return await _employeesRepository.DeleteObjects(id);
        }

        private async Task<Employee> GetEmployee(int id)
        {
            var employees = await _employeesRepository.GetObjects();
            return await Task.Run(() => employees.SingleOrDefault(e => e.Id == id));
        }

        private async Task<IReadOnlyList<TimeSheet>> GetTimeSheetsJob(Job job)
        {
            var timeSheets = await _timeSheetRepository.GetObjects();
            return await Task.Run(() => timeSheets.Where(t => t.JobId == job.Id).ToList());
        }

        private async Task<JobDto> Map(IReadOnlyList<TimeSheetDto> timeSheets, Job job)
        {
            var mc = await Task.Run(() => new MapperConfiguration(cfg => cfg.CreateMap<Job, JobDto>()
                .ForMember(dest => dest.CustomerFullName, act => act.MapFrom(src => src.Employee.FullName))
                .ForMember(dest => dest.TimeSheets, act => act.MapFrom(src => timeSheets))));
            var mapper = mc.CreateMapper();

            return await Task.Run(() => mapper.Map<JobDto>(job));
        }
    }
}
