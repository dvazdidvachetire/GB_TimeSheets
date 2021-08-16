using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.DAL.Repositories
{
    public class ManagersRepository : IManagerRepository
    {
        private readonly ITasksRepository _tasksRepository;

        public ManagersRepository(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public Task CreateObjects(Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task<Manager> GetObject(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateObject(int id, Manager manager)
        {
            throw new NotImplementedException();
        }

        public Task DeleteObject(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Models.Task>> CreateTask(Models.Task task)
        {
            await Task.Run(() => _tasksRepository.Tasks.Add(task));
            return _tasksRepository.Tasks;
        }
    }
}
