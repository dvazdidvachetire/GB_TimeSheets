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
    public interface ITasksRepository
    {
        Task<IEnumerable<Models.Task>> CreateTask(Models.Task task);
        Task<Models.Task> GetByIdTask(int id);
        Task<IEnumerable<Models.Task>> GetByIdTasks(int id);
        Task<IEnumerable<Models.Task>> GetAllTasks();
        Task<TaskDto> GetByIdCompletedTask(int id, int idT);
        Task<IEnumerable<TaskDto>> GetByIdCompletedTasks(int id);
        Task<TaskDto> UpdateTask(int id, TimeSheet timeSheet);
    }
}
