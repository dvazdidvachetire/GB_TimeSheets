using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Interfaces
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
        Task<Employee> GetByIdEmployee(int id);
        Task<JobDto> GetEmployeeTask(int id, int idT);
        Task<IEnumerable<JobDto>> GetEmployeeTasks(int id);
        Task<Models.Job> GetTask(int id);
        Task<IEnumerable<Models.Job>> GetAllTask();
        Task<JobDto> CreateTimeSheet(int id, TimeSheet timeSheet);
    }
}
