using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        [HttpPost("contract")]
        public IActionResult Create([FromBody] Contract contract)
        {
            return Ok();
        }

        [HttpGet("contracts")]
        public IActionResult Read()
        {
            return Ok();
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Contract contract)
        {
            return Ok();
        }

        [HttpDelete("")]
        public IActionResult Delete([FromRoute] string name)
        {
            return Ok();
        }
    }
}
