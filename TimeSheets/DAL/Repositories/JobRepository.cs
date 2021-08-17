using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Job = TimeSheets.DAL.Models.Job;

namespace TimeSheets.DAL.Repositories
{
    public class JobRepository : IJobRepository
    {
        private IList<Job> _tasks = new List<Job>();
        private IList<JobDto> _tasksDtos = new List<JobDto>();

        private async Task<JobDto> Map(Job task)
        {
            return await Task.Run(() => 
                new JobDto
                {
                    CustomerId = task.CustomerId,
                    Title = task.Title,
                    Description = task.Description,
                    Amount = task.Amount,
                    TimeSheet = task.TimeSheet
                });
        }

        public async Task<IEnumerable<Job>> CreateObjects(Job task)
        {
            await Task.Run(() => _tasks.Add(task));
            await Task.Run(async () => _tasksDtos.Add(await Map(task)));
            return _tasks;
        }

        public async Task<IEnumerable<Job>> GetTasksById(int id)
        {
            return await Task.Run(() => _tasks.Where(t => t.Id == id));
        }

        public async Task<IEnumerable<Job>> GetObjects()
        {
            return await Task.Run(() => _tasks);
        }

        public async Task<IEnumerable<JobDto>> GetCompletedTasks()
        {
            return await Task.Run(() => _tasksDtos);
        }

        public async Task<IEnumerable<JobDto>> GetCompletedTasksById(int id)
        {
            return await Task.Run(() => _tasksDtos.Where(t => t.CustomerId == id));
        }

        public async Task<JobDto> UpdateTask(int id, TimeSheet timeSheet)
        {
            var task = _tasks.SingleOrDefault(t => t.Id == id);

            task.TimeSheet = timeSheet;

            _tasksDtos = await Task.Run(() => _tasksDtos.Select(t =>
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

        public Task<IEnumerable<Job>> UpdateObjects(int id, Job task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Job>> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
