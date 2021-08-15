using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Models;

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

        [HttpPost("register")]
        public IActionResult Create([FromBody] Employee employee)
        {
            _repositories.Employees.Add(employee);
            return Ok("Регистрация прошла успешно!");
        }

        [HttpGet("{id}/completed_task/{idT}")]
        public IActionResult GetEmployeeTask([FromRoute] int id, [FromRoute] int idT)
        {
            var tasks = _repositories.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id);
            var task = tasks.SingleOrDefault(t => t.Id == idT);
            return Ok(task);
        }

        [HttpGet("{id}/completed_tasks")]
        public IActionResult GetEmployeeTasks([FromRoute] int id)
        {
            var tasks = _repositories.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id);
            return Ok(tasks);
        }

        [HttpGet("task/{id}")]
        public IActionResult GetTask([FromRoute] int id)
        {
            var task = _repositories.Tasks.SingleOrDefault(t => t.Id == id);
            return Ok(task);
        }

        [HttpGet("tasks")]
        public IActionResult GetAllTasks()
        {
            return Ok(_repositories.Tasks);
        }

        [HttpGet("{id}/profile")]
        public IActionResult GetProfile([FromRoute] int id)
        {
            var employee = _repositories.Employees.SingleOrDefault(e => e.Id == id);
            return Ok(employee);
        }

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

        [HttpDelete("delete_profile_employee")]
        public IActionResult DeleteProfile([FromRoute] int id)
        {
            _repositories.Employees.RemoveAt(id);
            return Ok("Профиль успешно удален!");
        }
    }
}
