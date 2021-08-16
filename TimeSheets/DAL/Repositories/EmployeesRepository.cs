using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private IList<Employee> _employees = new List<Employee>();
        private readonly ITasksRepository _tasksRepository;

        public EmployeesRepository(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public async Task CreateObjects(Employee employee)
        {
            await Task.Run(() => _employees.Add(employee));
        }

        public async Task<Employee> GetObject(int id)
        {
            return await Task.Run( () => _employees.SingleOrDefault(e => e.Id == id));
        }

        public async Task UpdateObject(int id, Employee employee)
        {
            await Task.Run(() =>
            {
                _employees = _employees.Select(e =>
                {
                    if (e.Id == id)
                    {
                        e = employee;
                        return e;
                    }

                    return e;

                }).ToList();
            });
        }

        public async Task DeleteObject(int id)
        {
            await Task.Run(() => _employees.RemoveAt(id));
        }

        public async Task<TaskDto> GetEmployeeTask(int id, int idT)
        {
            var tasks = await Task.Run( () => _tasksRepository.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id));
            var task = await Task.Run(() => tasks.SingleOrDefault(t => t.Id == idT));
            return task;
        }

        public async Task<IEnumerable<TaskDto>> GetEmployeeTasks(int id)
        {
            return await Task.Run(() => _tasksRepository.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id));
        }

        public async Task<Models.Task> GeTask(int id)
        {
            return await Task.Run(() => _tasksRepository.Tasks.SingleOrDefault(t => t.Id == id));
        }

        public async Task<IEnumerable<Models.Task>> GetAllTask()
        {
            return await Task.Run(() => _tasksRepository.Tasks);
        }

        public async Task<TaskDto> CreateTimeSheet(int id, TimeSheet timeSheet)
        {
            var task = await Task.Run(() => _tasksRepository.Tasks.SingleOrDefault(t => t.Id == id));

            var taskDto = await Task.Run(() => new TaskDto
            {
                CustomerId = task.CustomerId,
                Title = task.Title,
                Description = task.Description,
                Amount = task.Amount,
                TimeSheet = timeSheet
            });

            await Task.Run(() => _tasksRepository.TaskDtos.Add(taskDto));

            return taskDto;
        }
    }
}
