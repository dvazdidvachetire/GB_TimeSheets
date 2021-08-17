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
        Task<TaskDto> GetEmployeeTask(int id, int idT);
        Task<IEnumerable<TaskDto>> GetEmployeeTasks(int id);
        Task<Models.Task> GetTask(int id);
        Task<IEnumerable<Models.Task>> GetAllTask();
        Task<TaskDto> CreateTimeSheet(int id, TimeSheet timeSheet);
    }
}
