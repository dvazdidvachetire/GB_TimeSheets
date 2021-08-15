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

        [HttpPut("task/{idTask}/timesheet")]
        public IActionResult CreateTimeSheet([FromRoute] int idTask, [FromBody] TimeSheet timeSheet)
        {
            var task = _repositories.Tasks.SingleOrDefault(t => t.Id == idTask);
            task.TimeSheet = timeSheet;

            var taskDto = new TaskDto
            {
                Title = task.Title,
                Description = task.Description,
                Amount = task.Amount,
                TimeSheet = timeSheet
            };

            _repositories.TaskDtos.Add(taskDto);

            return Ok(taskDto);
        }

        [HttpGet("store/{id}")]
        public IActionResult GetEmployeeTasks([FromRoute] int id)
        {
            var tasks = _repositories.TaskDtos.Where(t => t.TimeSheet.EmployeeId == id);
            return Ok(tasks);
        }

        [HttpGet("tasks")]
        public IActionResult GetAllTasks()
        {
            return Ok(_repositories.Tasks);
        }
    }
}
