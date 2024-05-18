using System;
using System.Collections.Generic;
using System.Linq;
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
            return await _employeesRepository.CreateObjectsAsync(employee);
        }

        public async Task<JobEmployeeDto> GetCompletedJob(int id, int idJ)
        {
            var jobsEmployeeDto = await GetCompletedJobs(id);
            return await Task.Run(() => jobsEmployeeDto.SingleOrDefault(j => j.Id == idJ));
        }

        public async Task<IReadOnlyList<JobEmployeeDto>> GetCompletedJobs(int id)
        {
            var employee = await _employeesRepository.GetObjectsAsync();
            var timeSheets = await _timeSheetRepository.GetObjectsAsync();

            var mapper = await MapperConfiguration();

            var employeeTimeSheets = await Task.Run(() => timeSheets.Join(employee,
                t => t.EmployeeIdT,
                e => e.Id,
                (timeSheet, empl)
                    => 
                {
                    timeSheet.Employee = empl;
                    return mapper.Map<TimeSheetDto>(timeSheet);
                }).ToList());

            var jobs = await _jobRepository.GetObjectsAsync();
            var customers = await _customersRepository.GetObjectsAsync();

            var jobsEmployee = await Task.Run(() => jobs.Join(customers,
                j => j.CustomerIdJ,
                c => c.Id,
                (job,customer) 
                    =>
                {
                    job.Customer = customer;
                    var dto = Task.Run(() => mapper.Map<JobEmployeeDto>(job)).GetAwaiter().GetResult();
                    dto.TimeSheets = Task.Run(() => employeeTimeSheets.Where(e => e.JobIdT == job.Id).ToList()).GetAwaiter().GetResult();
                    return dto;
                }).ToList());

            return await Task.Run(() =>  jobsEmployee.Where(j => j.TimeSheets.Select(j => j.EmployeeIdT)
                                                                                               .Contains(id))
                                                                                               .ToList());
        }

        public async Task<IReadOnlyList<JobDto>> GetJobs()
        {
            var jobs = await _jobRepository.GetObjectsAsync();
            var customers = await _customersRepository.GetObjectsAsync();

            var mapper = await MapperConfiguration();

            return await Task.Run(() => jobs.Join(customers,
                j => j.CustomerIdJ,
                c => c.Id,
                (job, customer) =>
                {
                    job.Customer = customer;
                    return mapper.Map<JobDto>(job);
                }).ToList());
        }

        public async Task<bool> ChangeEmployee(int id, Employee employee)
        {
            return await _employeesRepository.UpdateObjectsAsync(id, employee);
        }

        public async Task<bool> CreateTimeSheet(int id, TimeSheet timeSheet)
        {
            timeSheet.JobIdT = id;
            return await _timeSheetRepository.CreateObjectsAsync(timeSheet);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
           return await _employeesRepository.DeleteObjectsAsync(id);
        }

        private async Task<IMapper> MapperConfiguration()
        {
            var mcfg = await Task.Run(() => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TimeSheet, TimeSheetDto>()
                    .ForMember(dest => dest.EmployeeName, act => act.MapFrom(src => src.Employee.FullName));
                cfg.CreateMap<Job, JobEmployeeDto>()
                    .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.Customer.FullName));
                cfg.CreateMap<Job, JobDto>()
                    .ForMember(dest => dest.CustomerName, act => act.MapFrom(src => src.Customer.FullName));
            }));

            return mcfg.CreateMapper();
        }
    }
}
