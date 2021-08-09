using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpPost("employee")]
        public IActionResult Create([FromBody] Employee employee)
        {
            return Ok();
        }

        [HttpGet("employees")]
        public IActionResult Read()
        {
            return Ok();
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Employee employee)
        {
            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromRoute] string name)
        {
            return Ok();
        }
    }
}
