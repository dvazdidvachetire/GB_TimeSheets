using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Employee>> RegisterEmployee(Employee employee)
        {
            return await _employeesRepository.CreateObjects(employee);
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            return await _employeesRepository.GetObjects();
        }

        public async Task<JobDto> GetJobEmployee(int id, int idJ)
        {
            var jobsEmployee = await GetJobsEmployee(id);
            var jobEmployee = await Task.Run(() => jobsEmployee.SingleOrDefault(j => j.Id == id));
            return jobEmployee;
        }

        public async Task<IEnumerable<JobDto>> GetJobsEmployee(int id)
        {
            if (_jobRepository is JobRepository jobRepository)
            {
                var jobsEmployee = await Task.Run(() => jobRepository.JobsDtos.Where(j => j.TimeSheet.EmployeeId == id));
                return jobsEmployee;
            }

            return default;
        }

        public async Task<Job> GetJob(int id)
        {
            var jobs = await GetJobs();
            var job = await Task.Run(() => jobs.SingleOrDefault(j => j.Id == id));
            return job;
        }

        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _jobRepository.GetObjects();
        }

        public async Task<IEnumerable<Employee>> ChangeEmployee(int id, Employee employee)
        {
            return await _employeesRepository.UpdateObjects(id, employee);
        }

        public async Task<JobDto> ChangeTimeSheet(int id, TimeSheet timeSheet)
        {
            var job = await GetJob(id);

            job.TimeSheet = timeSheet;

            if (_jobRepository is JobRepository jobRepository)
            {
                await Task.Run(async () => jobRepository.JobsDtos.Add(await Map(job)));
            }

            return await Map(job);
        }

        public async Task<IEnumerable<Employee>> DeleteEmployee(int id)
        {
           return await _employeesRepository.DeleteObjects(id);
        }

        private async Task<JobDto> Map(Job job)
        {
            return await Task.Run(() =>
                new JobDto
                {
                    CustomerId = job.CustomerId,
                    Title = job.Title,
                    Description = job.Description,
                    Amount = job.Amount,
                    TimeSheet = job.TimeSheet
                });
        }
    }
}
