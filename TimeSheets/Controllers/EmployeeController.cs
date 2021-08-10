using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeesRepository _repository;

        public EmployeeController(IEmployeesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("employee")]
        public IActionResult Create([FromBody] Employee employee)
        {
            var employees = _repository.AddObjects(employee);
            return Ok(employees);
        }

        [HttpGet("employees")]
        public IActionResult Read()
        {
            var employees = _repository.GetAllObjects();
            return Ok(employees);
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Employee employee)
        {
            var employees = _repository.ChangeObjects(employee);
            return Ok(employees);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var employees = _repository.DeleteObjects(id);
            return Ok(employees);
        }
    }
}
