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

        public async Task<IEnumerable<Task>> CreateObjects(Task task)
        {
            await System.Threading.Tasks.Task.Run(() => _tasks.Add(task));
            await System.Threading.Tasks.Task.Run(async () => _tasksDtos.Add(await Map(task)));
            return _tasks;
        }

        public async Task<IEnumerable<Task>> GetTasksById(int id)
        {
            return await System.Threading.Tasks.Task.Run(() => _tasks.Where(t => t.Id == id));
        }

        public async Task<IEnumerable<Task>> GetObjects()
        {
            return await System.Threading.Tasks.Task.Run(() => _tasks);
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedTasks()
        {
            return await System.Threading.Tasks.Task.Run(() => _tasksDtos);
        }

        public async Task<IEnumerable<TaskDto>> GetCompletedTasksById(int id)
        {
            return await System.Threading.Tasks.Task.Run(() => _tasksDtos.Where(t => t.CustomerId == id));
        }

        public async Task<TaskDto> UpdateTask(int id, TimeSheet timeSheet)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);

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

        public Task<IEnumerable<Task>> UpdateObjects(int id, Task task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Task>> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
