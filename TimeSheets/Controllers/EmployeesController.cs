using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //Регистрация сотрудника
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var isRegistered = await _employeeService.RegisterEmployee(employee);
            return Ok(isRegistered);
        }

        [HttpGet("{id}/task/{idJ}")]
        public async Task<IActionResult> GetJobEmployee([FromRoute] int id, [FromRoute] int idJ)
        {
            var task = await _employeeService.GetJobEmployee(id, idJ);
            return Ok(task);
        }

        //Список задач сотрудника
        [HttpGet("tasks/{id}")]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            var jobs = await _employeeService.GetJobs(id);
            return Ok(jobs);
        }

        //Список всех задач
        [HttpGet("tasks")]
        public async Task<IActionResult> GetAllJobs()
        {
            var tasks = await _employeeService.GetJobs();
            return Ok(tasks);
        }

        //Меняет табель
        [HttpPut("task/{id}/timesheet")]
        public async Task<IActionResult> CreateTimeSheet([FromRoute] int id, [FromBody] TimeSheet timeSheet)
        {
            var taskDto = await _employeeService.ChangeTimeSheet(id, timeSheet);
            return Ok(taskDto);
        }

        //Меняет профиль сотрудника
        [HttpPut("{id}/edit_profile_employee")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Employee employee)
        {
            var isChanged = await _employeeService.ChangeEmployee(id, employee);
            return Ok(isChanged);
        }

        //Удаляет профиль сотрудника
        [HttpDelete("{id}/delete_profile_employee")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            var isDeleted = await _employeeService.DeleteEmployee(id);
            return Ok(isDeleted);
        }
    }
}
