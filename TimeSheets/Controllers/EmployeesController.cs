using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly Repositories _repositories;

        public EmployeesController(Repositories repositories)
        {
            _repositories = repositories;
        }

        /// <summary>
        /// Создает нового сотрудника
        /// </summary>
        /// <param name="employee">Сотрудник</param>
        /// <returns>Строка об успешной регистрации</returns>
        [HttpPost("register")]
        public IActionResult Create([FromBody] Employee employee)
        {
            _repositories.Employees.Add(employee);
            return Ok("Регистрация прошла успешно!");
        }

        /// <summary>
        /// Получает конкретную сделанную задачу конкретного сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="idT">ид задачи</param>
        /// <returns>Задача</returns>
        [HttpGet("{id}/completed_task/{idT}")]
        public IActionResult GetEmployeeTask([FromRoute] int id, [FromRoute] int idT)
        {
            var tasks = _repositories.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id);
            var task = tasks.SingleOrDefault(t => t.Id == idT);
            return Ok(task);
        }

        /// <summary>
        /// Возвращает список сделанных задач конкретного сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Список задач</returns>
        [HttpGet("{id}/completed_tasks")]
        public IActionResult GetEmployeeTasks([FromRoute] int id)
        {
            var tasks = _repositories.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id);
            return Ok(tasks);
        }

        /// <summary>
        /// Возвращает конкретную задачу
        /// </summary>
        /// <param name="id">ид задачи</param>
        /// <returns>Задача</returns>
        [HttpGet("task/{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
            var task = _repositories.Tasks.SingleOrDefault(t => t.Id == id);
            return Ok(task);
        }

        /// <summary>
        /// Возвращает список всех задач
        /// </summary>
        /// <returns>Список задач</returns>
        [HttpGet("tasks")]
        public IActionResult GetAllTasks()
        {
            return Ok(_repositories.Tasks);
        }

        /// <summary>
        /// Возвращает профиль сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Профиль сотрудника</returns>
        [HttpGet("{id}/profile")]
        public IActionResult GetProfile([FromRoute] int id)
        {
            var employee = _repositories.Employees.SingleOrDefault(e => e.Id == id);
            return Ok(employee);
        }

        /// <summary>
        /// Дает возможность сотруднику изменить табель задачи 
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="timeSheet">табель</param>
        /// <returns>Измененная задача</returns>
        [HttpPut("task/{id}/timesheet")]
        public IActionResult CreateTimeSheet([FromRoute] int id, [FromBody] TimeSheet timeSheet)
        {
            var task = _repositories.Tasks.SingleOrDefault(t => t.Id == id);
            task.TimeSheet = timeSheet;

            var taskDto = new TaskDto
            {
                CustomerId = task.CustomerId,
                Title = task.Title,
                Description = task.Description,
                Amount = task.Amount,
                TimeSheet = timeSheet
            };

            _repositories.TaskDtos.Add(taskDto);

            return Ok(taskDto);
        }

        /// <summary>
        /// Дает возможность сотруднику изменить его профиль
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <param name="employee">сотрудник</param>
        /// <returns>Строка о успешном изменении профиля</returns>
        [HttpPut("{id}/edit_profile_employee")]
        public IActionResult EditProfile([FromRoute] int id, [FromBody] Employee employee)
        {
            _repositories.Employees = _repositories.Employees.Select(e =>
            {
                if (e.Id == id)
                {
                    e = employee;
                    return e;
                }

                return e;

            }).ToList();

            return Ok("Профиль успешно изменен!");
        }

        /// <summary>
        /// Удаляет профиль сотрудника
        /// </summary>
        /// <param name="id">ид сотрудника</param>
        /// <returns>Срока об успешном удалении</returns>
        [HttpDelete("delete_profile_employee")]
        public IActionResult DeleteProfile([FromRoute] int id)
        {
            _repositories.Employees.RemoveAt(id);
            return Ok("Профиль успешно удален!");
        }
    }
}
