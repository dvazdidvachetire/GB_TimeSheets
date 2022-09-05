using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.Infrastructure.Models;
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
            var jobs = await _managerService.CreateJob(job);
            return Ok(jobs);
        }

        [HttpPost("contract")]
        public async Task<IActionResult> CreateContract([FromBody] Contract contract)
        {
            var contracts = await _managerService.CreateContract(contract);
            return Ok(contracts);
        }

        [HttpPost("invoice")]
        public async Task<IActionResult> CreateInvoice([FromBody] Invoice invoice)
        {
            var invoices = await _managerService.CreateInvoice(invoice);
            return Ok(invoices);
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
