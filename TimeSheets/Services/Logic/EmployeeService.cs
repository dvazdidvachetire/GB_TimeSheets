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
        public EmployeeService(IEmployeesRepository employeesRepository,
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<bool> RegisterEmployee(Employee employee)
        {
            return await _employeesRepository.CreateObjects(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _employeesRepository.GetObjects();
        }

        public async Task<JobDto> GetJobEmployee(int id, int idJ)
        {
            //var jobsEmployee = await GetJobsEmployee(id);
            //var jobEmployee = await Task.Run(() => jobsEmployee.SingleOrDefault(j => j.Id == id));
            //return jobEmployee;
            return null;
        }

        public async Task<IReadOnlyList<Job>> GetJobs(int id)
        {
            var jobs = await _jobRepository.GetObjects();
            return await Task.Run(() => jobs.Where(j => j.TimeSheet.EmployeeId == id).ToList());
        }

        public async Task<IReadOnlyList<Job>> GetJobs()
        {
            return await _jobRepository.GetObjects();
        }

        public async Task<bool> ChangeEmployee(int id, Employee employee)
        {
            return await _employeesRepository.UpdateObjects(id, employee);
        }

        public async Task<JobDto> ChangeTimeSheet(int id, TimeSheet timeSheet)
        {
            var jobs = await _jobRepository.GetObjects();
            var job = await Task.Run(() => jobs.SingleOrDefault(j => j.Id == id));

            job.TimeSheet = timeSheet;

            return await Map(job);
        }

        public async Task<bool> DeleteEmployee(int id)
        {
           return await _employeesRepository.DeleteObjects(id);
        }

        private async Task<JobDto> Map(Job job)
        {
            var config = await Task.Run(() => new MapperConfiguration(cfg => cfg.CreateMap<Job, JobDto>()));
            var mapper = config.CreateMapper();

            return await Task.Run(() => mapper.Map<JobDto>(job));
        }
    }
}
