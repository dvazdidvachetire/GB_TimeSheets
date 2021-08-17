using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Task = TimeSheets.DAL.Models.Task;

namespace TimeSheets.DAL.Interfaces
{
    public interface ITasksRepository : IRepository<Models.Task>
    {
        Task<IEnumerable<TaskDto>> GetCompletedTasks();
        Task<IEnumerable<TaskDto>> GetCompletedTasksById(int id);
        Task<IEnumerable<Task>> GetTasksById(int id);
        Task<TaskDto> UpdateTask(int id, TimeSheet timeSheet);
    }
}
