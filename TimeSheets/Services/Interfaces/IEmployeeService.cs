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
        Task<JobDto> GetJobEmployee(int id, int idJ);
        Task<IReadOnlyList<JobDto>> GetJobs(int id);
        Task<IReadOnlyList<JobForEmployeeDto>> GetJobs();
        Task<bool> ChangeEmployee(int id, Employee employee);
        Task<bool> CreateTimeSheet(int idE, int id, TimeSheet timeSheet);
        Task<bool> DeleteEmployee(int id);
    }
}
