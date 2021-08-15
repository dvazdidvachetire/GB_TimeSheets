using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheets.DTO;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly Repositories _repositories;

        public ManagerController(Repositories repositories)
        {
            _repositories = repositories;
        }

        [HttpPost("task")]
        public IActionResult CreateTask([FromBody] Task task)
        {
            _repositories.Tasks.Add(task);
            return Ok(_repositories.Tasks);
        }

        [HttpPost("contract")]
        public IActionResult CreateContract([FromBody] Contract contract)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == contract.CustomerId);
            var tasks = _repositories.Tasks.Where(s => s.Id == customer?.Id);
            var contractDto = new ContractDto
            {
                NumberContract = contract.NumberContract,
                Customer = customer,
                Tasks = tasks
            };

            _repositories.Contracts.Add(contractDto);

            return Ok(_repositories.Contracts);
        }

        [HttpGet("contracts")]
        public IActionResult GetAllContracts()
        {
            return Ok(_repositories.Contracts);
        }

        [HttpPost("invoice")]
        public IActionResult CreateInvoice([FromBody] Invoice invoice)
        {
            _repositories.Invoices.Add(invoice);
            return Ok(_repositories.Invoices);
        }
    }
}
