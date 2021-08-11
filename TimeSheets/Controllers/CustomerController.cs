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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomersRepository _repository;

        public CustomerController(ICustomersRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("client")]
        public IActionResult Create([FromBody] Customer client)
        {
            var clients = _repository.AddObjects(client);
            return Ok(client);
        }

        [HttpGet("clients")]
        public IActionResult Read()
        {
            var clients = _repository.GetAllObjects();
            return Ok(clients);
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Customer client)
        {
            var clients = _repository.ChangeObjects(client);
            return Ok(clients);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var clients = _repository.DeleteObjects(id);
            return Ok(clients);
        }
    }
}
