using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Task = TimeSheets.DAL.Models.Task;

namespace TimeSheets.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private IList<Task> _tasks = new List<Task>();
        private IList<TaskDto> _tasksDtos = new List<TaskDto>();

        private async Task<TaskDto> Map(Task task)
        {
            return await System.Threading.Tasks.Task.Run(() => 
                new TaskDto
                {
                    CustomerId = task.CustomerId,
                    Title = task.Title,
                    Description = task.Description,
                    Amount = task.Amount,
                    TimeSheet = task.TimeSheet
                });
        }

        public async Task<IEnumerable<Task>> CreateTask(Task task)
        {
            await System.Threading.Tasks.Task.Run(() => _tasks.Add(task));
            await System.Threading.Tasks.Task.Run(async () => _tasksDtos.Add(await Map(task)));
            return _tasks;
        }

        public async Task<Task> GetByIdTask(int id)
        {
            return await System.Threading.Tasks.Task.Run(() => _tasks.SingleOrDefault(t => t.Id == id));
        }

        public async Task<IEnumerable<Task>> GetByIdTasks(int id)
        {
            return await System.Threading.Tasks.Task.Run(() => _tasks.Where(t => t.CustomerId == id));
        }

        public async Task<IEnumerable<Task>> GetAllTasks()
        {
            return await System.Threading.Tasks.Task.Run(() => _tasks);
        }

        public async Task<TaskDto> GetByIdCompletedTask(int id, int idT)
        {
            var tasks = await GetByIdCompletedTasks(id);
            return await System.Threading.Tasks.Task.Run(() => tasks.SingleOrDefault(t => t.Id == idT));
        }

        public async Task<IEnumerable<TaskDto>> GetByIdCompletedTasks(int id)
        {
            return await System.Threading.Tasks.Task.Run(() => _tasksDtos.Where(t => t.TimeSheet.EmployeeId == id));
        }


        public async Task<TaskDto> UpdateTask(int id, TimeSheet timeSheet)
        {
            var task = await GetByIdTask(id);

            task.TimeSheet = timeSheet;

            _tasksDtos = await System.Threading.Tasks.Task.Run(() => _tasksDtos.Select(t =>
            {
                if (t.Id == id)
                {
                    t = Map(task).GetAwaiter().GetResult();
                }

                return t;

            }).ToList());

            var taskDto = await Map(task);

            return taskDto;
        }
    }
}
