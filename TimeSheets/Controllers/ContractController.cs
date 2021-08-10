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

        [HttpPost("contract")]
        public IActionResult Create([FromBody] Contract contract)
        {
            var contracts = _repository.AddContracts(contract);
            return Ok(contracts);
        }

        [HttpGet("contracts")]
        public IActionResult Read()
        {
            var contracts = _repository.GetAllContracts();
            return Ok(contracts);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var contracts = _repository.DeleteContracts(id);
            return Ok(contracts);
        }
    }
}
