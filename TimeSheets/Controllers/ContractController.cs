using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.Responses.DTO;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IContractsRepository _repository;

        public ContractController(IContractsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("contract/{id}")]
        public IActionResult Create([FromBody] Contract contract, [FromRoute] int id)
        {
            var contracts = _repository.AddObjects(contract, id);
            var newContracts = new SortedDictionary<int, ContractDto>();

            foreach (var cont in contracts)
            {
                newContracts.Add(cont.Key, new ContractDto
                {
                    NumberContract = cont.Value.NumberContract,
                    Client = cont.Value.Client,
                    Employees = cont.Value.Employees,
                    TypeJob = cont.Value.TypeJob,
                    QuantityJob = cont.Value.QuantityJob,
                    Price = cont.Value.Price
                });
            }

            return Ok(newContracts);
        }

        [HttpGet("contracts")]
        public IActionResult Read()
        {
            return Ok();
        }

        [HttpPut("change")]
        public IActionResult Update([FromBody] Contract contract, [FromRoute] int id)
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
