using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/contract")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly Repositories _repositories;

        public ContractsController(Repositories repositories)
        {
            _repositories = repositories;
        }

        [HttpPost()]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            _repositories.Contracts.Add(contract);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetContractById([FromRoute] int id)
        {
            var contract = _repositories.Contracts.SingleOrDefault(c => c.Id == id);
            return Ok(contract);
        }
    }
}
