using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DTO;
using TimeSheets.DAL.Models;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService)
        {
            _managerService = managerService;
        }

        [HttpPost("job")]
        public async Task<IActionResult> CreateJob([FromBody] Job job)
        {
            var isCreated = await _managerService.CreateJob(job);
            return Ok(isCreated);
        }

        [HttpPost("contract")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            var isCreated = await _managerService.CreateContract(contract);
            return Ok(isCreated);
        }

        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            var isCreated = await _managerService.CreateInvoice(invoice);
            return Ok(isCreated);
        }

        [HttpGet("{id}/customer_contracts")]
        public async Task<IActionResult> GetContractsById([FromRoute] int id)
        {
            var contracts = await _managerService.GetContractsCustomer(id);
            return Ok(contracts);
        }

        [HttpGet("{id}/customer_invoices")]
        public async Task<IActionResult> GetInvoicesById([FromRoute] int id)
        {
            var invoices = await _managerService.GetInvoicesCustomer(id);
            return Ok(invoices);
        }

        [HttpGet("contracts")]
        public async Task<IActionResult> GetContracts()
        {
            var contracts = await _managerService.GetContracts();
            return Ok(contracts);
        }

        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _managerService.GetInvoices();
            return Ok(invoices);
        }
    }
}
