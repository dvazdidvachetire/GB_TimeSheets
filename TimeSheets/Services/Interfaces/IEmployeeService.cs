using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;

namespace TimeSheets.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> RegisterEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<JobDto> GetJobEmployee(int id, int idJ);
        Task<IEnumerable<JobDto>> GetJobsEmployee(int id);
        Task<Job> GetJob(int id);
        Task<IEnumerable<Job>> GetJobs();
        Task<IEnumerable<Employee>> ChangeEmployee(int id, Employee employee);
        Task<JobDto> ChangeTimeSheet(int id, TimeSheet timeSheet);
        Task<IEnumerable<Employee>> DeleteEmployee(int id);
    }
}
