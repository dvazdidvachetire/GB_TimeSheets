using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost()]
        public IActionResult Create([FromBody] Employee employee)
        {
            _repositories.Employees.Add(employee);
            return Ok();
        }

        [HttpPost("{id}/task/{idTask}/timesheet")]
        public IActionResult CreateTimeSheet([FromRoute] int id, [FromRoute] int idTask, [FromBody] TimeSheet timeSheet)
        {
            var employee = _repositories.Employees.SingleOrDefault(e => e.Id == id);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById([FromRoute] int id)
        {
            var employee = _repositories.Employees.SingleOrDefault(e => e.Id == id);
            return Ok(employee);
        }

        [HttpGet()]
        public IActionResult GetEmployees()
        {
            return Ok(_repositories.Employees);
        }
    }
}
