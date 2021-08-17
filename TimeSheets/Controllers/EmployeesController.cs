using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using TimeSheets.DTO;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeesRepository _employeesRepository;

        public EmployeesController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        /// <summary>
        /// Создает нового сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Строка об успешной регистрации</returns>
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            await _employeesRepository.CreateObjects(employee);
            return await Task.Run(() => Ok("Регистрация прошла успешно!"));
        }

        /// <summary>
        /// Получает конкретную сделанную задачу конкретного сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="idT">ид задачи</param>
        /// <returns>Задача</returns>
        [HttpGet("{id}/completed_task/{idT}")]
        public async Task<IActionResult> GetEmployeeTask([FromRoute] int id, [FromRoute] int idT)
        {
            var task = await _employeesRepository.GetEmployeeTask(id, idT);
            return await Task.Run(() => Ok(task));
        }

        /// <summary>
        /// Возвращает список сделанных задач конкретного сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Список задач</returns>
        [HttpGet("{id}/completed_tasks")]
        public async Task<IActionResult> GetEmployeeTasks([FromRoute] int id)
        {
            var tasks = await _employeesRepository.GetEmployeeTasks(id);
            return Ok(tasks);
        }

        /// <summary>
        /// Возвращает конкретную задачу
        /// </summary>
        /// <param name="id">ид задачи</param>
        /// <returns>Задача</returns>
        [HttpGet("task/{id}")]
        public async Task<IActionResult> GetTask([FromRoute] int id)
        {
            var task = await _employeesRepository.GetTask(id);
            return await Task.Run(() => Ok(task));
        }

        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <returns>Список задач</returns>
        [HttpGet("tasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _employeesRepository.GetAllTask();
            return await Task.Run( () => Ok(tasks));
        }

        /// <summary>
        /// Возвращает профиль сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Профиль сотрудника</returns>
        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile([FromRoute] int id)
        {
            var employee = await _employeesRepository.GetObject(id);
            return await Task.Run( () => Ok(employee));
        }

        /// <summary>
        /// Дает возможность сотруднику изменить табель задачи 
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="timeSheet">табель</param>
        /// <returns>Измененная задача</returns>
        [HttpPut("task/{id}/timesheet")]
        public async Task<IActionResult> CreateTimeSheet([FromRoute] int id, [FromBody] TimeSheet timeSheet)
        {
            var taskDto = await _employeesRepository.CreateTimeSheet(id, timeSheet);
            return Ok(taskDto);
        }

        /// <summary>
        /// Дает возможность сотруднику изменить его профиль
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="employee">сотрудник</param>
        /// <returns>Строка о успешном изменении профиля</returns>
        [HttpPut("{id}/edit_profile_employee")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Employee employee)
        {
            await _employeesRepository.UpdateObject(id, employee);
            return await Task.Run(() => Ok("Профиль успешно изменен!"));
        }

        /// <summary>
        /// Удаляет профиль сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Срока об успешном удалении</returns>
        [HttpDelete("delete_profile_employee")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            await _employeesRepository.DeleteObject(id);
            return await Task.Run(() => Ok("Профиль успешно удален!"));
        }
    }
}
