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

        /// <summary>
        /// Добавляет сотрудника
        /// </summary>
        /// <param name="employee">сотрудник</param>
        /// <returns></returns>
        public async Task CreateObjects(Employee employee)
        {
            await Task.Run(() => _employees.Add(employee));
        }

        /// <summary>
        /// Возвращает сотрудника по его ид
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>сотрудник</returns>
        public async Task<Employee> GetObject(int id)
        {
            return await Task.Run( () => _employees.SingleOrDefault(e => e.Id == id));
        }

        /// <summary>
        /// Изменяет данные сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="employee">новые данные сотрудника</param>
        /// <returns></returns>
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

        /// <summary>
        /// Удаляет сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns></returns>
        public async Task DeleteObject(int id)
        {
            await Task.Run(() => _employees.RemoveAt(id));
        }

        /// <summary>
        /// Возвращает конкретную задачу, которую сотрудник уже выполнил
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="idT">ид задачи</param>
        /// <returns>задача</returns>
        public async Task<TaskDto> GetEmployeeTask(int id, int idT)
        {
            return await _tasksRepository.GetByIdCompletedTask(id, idT);
        }

        /// <summary>
        /// Возвращает список выполненых задач сотрудником
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>список задач</returns>
        public async Task<IEnumerable<TaskDto>> GetEmployeeTasks(int id)
        {
            return await _tasksRepository.GetByIdCompletedTasks(id);
        }

        /// <summary>
        /// Возвращает конкретную задачу из общего списка задач, созданного менеджером
        /// </summary>
        /// <param name="id">ид задачи</param>
        /// <returns>задача</returns>
        public async Task<Models.Task> GetTask(int id)
        {
            return await _tasksRepository.GetByIdTask(id);
        }

        /// <summary>
        /// Возвращает общий список задач, созданного менеджером
        /// </summary>
        /// <returns>список задач</returns>
        public async Task<IEnumerable<Models.Task>> GetAllTask()
        {
            return await _tasksRepository.GetAllTasks();
        }

        /// <summary>
        /// Изменяет табель задачи
        /// </summary>
        /// <param name="id">ид задачи</param>
        /// <param name="timeSheet">табель</param>
        /// <returns>задача</returns>
        public async Task<TaskDto> CreateTimeSheet(int id, TimeSheet timeSheet)
        {
            return await _tasksRepository.UpdateTask(id, timeSheet);
        }
    }
}
