using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<bool> RegisterEmployee(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployee();
        Task<JobDto> GetJobEmployee(int id, int idJ);
        Task<IReadOnlyList<Job>> GetJobs(int id);
        Task<IReadOnlyList<Job>> GetJobs();
        Task<bool> ChangeEmployee(int id, Employee employee);
        Task<bool> CreateTimeSheet(TimeSheet timeSheet);
        Task<bool> DeleteEmployee(int id);
    }
}
