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
            var contracts = _repository.AddObjects(contract);
            var newContracts = _repository.ContractDtos;

            return Ok(newContracts);
        }

        [HttpGet("contracts")]
        public IActionResult Read()
        {
            return Ok(_repository.ContractDtos);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _repository.DeleteObjects(id);
            return Ok(_repository.ContractDtos);
        }
    }
}
