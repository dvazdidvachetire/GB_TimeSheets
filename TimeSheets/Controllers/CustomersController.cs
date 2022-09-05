using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TimeSheets.Infrastructure.Models;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            var customers = await _customerService.RegisterCustomer(customer);
            return Ok(customers);
        }

        [HttpGet("{id}/contract/{idC}")]
        public async Task<IActionResult> GetContract([FromRoute] int id, [FromRoute] int idC)
        {
            var contract = await _customerService.GetContractCustomer(id, idC);
            return Ok(contract);
        }

        [HttpGet("{id}/contracts")]
        public async Task<IActionResult> GetContracts([FromRoute] int id)
        {
            var contracts = await _customerService.GetContractsCustomer(id);
            return Ok(contracts);
        }

        [HttpGet("{id}/invoice/{idI}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int id, [FromRoute] int idI)
        {
            var invoice = await _customerService.GetInvoiceCustomer(id, idI);
            return Ok(invoice);
        }

        [HttpGet("{id}/invoices")]
        public async Task<IActionResult> GetInvoices([FromRoute] int id)
        {
            var invoices = await _customerService.GetInvoicesCustomer(id);
            return Ok(invoices);
        }

        [HttpPut("{id}/edit_profile_customer")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Customer customer)
        {
            var customers = await _customerService.ChangeCustomer(id, customer);
            return Ok(customers);
        }

        [HttpDelete("delete_profile_customer")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            var customers = await _customerService.DeleteCustomer(id);
            return Ok(customers);
        }
    }
}
