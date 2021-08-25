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
        Task<JobEmployeeDto> GetCompletedJob(int id, int idJ);
        Task<IReadOnlyList<JobEmployeeDto>> GetCompletedJobs(int id);
        Task<IReadOnlyList<JobDto>> GetJobs();
        Task<bool> ChangeEmployee(int id, Employee employee);
        Task<bool> CreateTimeSheet(int id, TimeSheet timeSheet);
        Task<bool> DeleteEmployee(int id);
    }
}
