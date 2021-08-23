using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        public EmployeeService(IEmployeesRepository employeesRepository,
            IJobRepository jobRepository,
            ITimeSheetRepository timeSheetRepository)
        {
            _jobRepository = jobRepository;
            _employeesRepository = employeesRepository;
            _timeSheetRepository = timeSheetRepository;
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            return await _employeesRepository.CreateObjects(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _employeesRepository.GetObjects();
        }

        public async Task<JobForEmployeeDto> GetJobEmployee(int id, int idJ)
        {
            ////TODO: исправить!
            //var jobs = await _jobRepository.GetObjects();
            //var job = await Task.Run(() => jobs.SingleOrDefault(j => j.EmployeeId == id));

            //var timeSheets = await _timeSheetRepository.GetObjects();
            //var timeSheetsJob = await Task.Run(() => timeSheets.Where(t => t.JobId == idJ));

            //var config = await Task.Run(() => new MapperConfiguration(cfg => cfg.CreateMap<Job, JobDto>()
            //    .ForMember(dest => dest.TimeSheet, act => act.MapFrom(src => timeSheetsJob))));
            //var mapper = config.CreateMapper();

            //return await Task.Run(() => mapper.Map<JobDto>(job));
            return null;
        }

        public async Task<IReadOnlyList<JobForEmployeeDto>> GetJobs(int id)
        {
            var jobs = await _jobRepository.GetObjects();
            var jobsEmployee = await Task.Run(() => jobs.Where(j => j.Employee.Id == id).ToList());

            var mc = await Task.Run(() => new MapperConfiguration(cfg => cfg.CreateMap<Job, JobForEmployeeDto>()));
            var mapper = mc.CreateMapper();

            return await Task.Run(() => mapper.Map<IList<Job>, IList<JobForEmployeeDto>>(jobsEmployee).ToList());
        }

        public async Task<IReadOnlyList<Job>> GetJobs()
        {
            return await _jobRepository.GetObjects();
        }

        public async Task<bool> ChangeEmployee(int id, Employee employee)
        {
            return await _employeesRepository.UpdateObjects(id, employee);
        }

        public async Task<bool> CreateTimeSheet(int idE, int idJ, TimeSheet timeSheet)
        {
            return await Task.Run(async () =>
            {
                timeSheet.Job.Id = idJ;
                await _jobRepository.UpdateObjects(idJ, new Job { Employee = new Employee{ Id = idE } });
                return await _timeSheetRepository.CreateObjects(timeSheet);
            });
        }

        public async Task<bool> DeleteEmployee(int id)
        {
           return await _employeesRepository.DeleteObjects(id);
        }
    }
}
