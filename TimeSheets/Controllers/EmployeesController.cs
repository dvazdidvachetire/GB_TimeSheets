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

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            var employees = await _employeeService.RegisterEmployee(employee);
            return Ok(employees);
        }

        [HttpGet("{id}/completed_task/{idJ}")]
        public async Task<IActionResult> GetJobEmployee([FromRoute] int id, [FromRoute] int idJ)
        {
            var task = await _employeeService.GetJobEmployee(id, idJ);
            return Ok(task);
        }

        [HttpGet("{id}/completed_tasks")]
        public async Task<IActionResult> GetJobsEmployee([FromRoute] int id)
        {
            var tasks = await _employeeService.GetJobsEmployee(id);
            return Ok(tasks);
        }

        [HttpGet("task/{id}")]
        public async Task<IActionResult> GetJob([FromRoute] int id)
        {
            var task = await _employeeService.GetJob(id);
            return Ok(task);
        }

        [HttpGet("tasks")]
        public async Task<IActionResult> GetAllJobs()
        {
            var tasks = await _employeeService.GetJobs();
            return Ok(tasks);
        }

        [HttpPut("task/{id}/timesheet")]
        public async Task<IActionResult> CreateTimeSheet([FromRoute] int id, [FromBody] TimeSheet timeSheet)
        {
            var taskDto = await _employeeService.ChangeTimeSheet(id, timeSheet);
            return Ok(taskDto);
        }

        [HttpPut("{id}/edit_profile_employee")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Employee employee)
        {
            var employees = await _employeeService.ChangeEmployee(id, employee);
            return Ok(employees);
        }

        [HttpDelete("delete_profile_employee")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            var employees = await _employeeService.DeleteEmployee(id);
            return Ok(employees);
        }
    }
}
