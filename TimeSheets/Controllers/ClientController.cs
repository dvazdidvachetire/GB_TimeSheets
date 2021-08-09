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
    public class ClientController : ControllerBase
    {
        [HttpPost("client")]
        public IActionResult Create([FromBody] Client client)
        {
            return Ok();
        }

        [HttpGet("clients")]
        public IActionResult Read()
        {
            return Ok();
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Client client)
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
