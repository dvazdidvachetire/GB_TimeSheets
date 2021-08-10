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
    public class ClientController : ControllerBase
    {
        private readonly IClientsRepository _repository;

        public ClientController(IClientsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("client")]
        public IActionResult Create([FromBody] Client client)
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
        public IActionResult Update([FromBody] Client client)
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
