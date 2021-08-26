using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
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

        //Регистрирует покупателя
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] Customer customer)
        {
            var isRegistered = await _customerService.RegisterCustomer(customer);
            return Ok(isRegistered);
        }

        
        [HttpGet("contract/{id}")]
        public async Task<IActionResult> GetContract([FromRoute] int id)
        {
            var contract = await _customerService.GetContractCustomer(id);
            return Ok(contract);
        }

        //Контракты покупателя
        [HttpGet("{id}/contracts")]
        public async Task<IActionResult> GetContracts([FromRoute] int id)
        {
            var contracts = await _customerService.GetContracts(id);
            return Ok(contracts);
        }

        
        [HttpGet("invoice/{id}")]
        public async Task<IActionResult> GetInvoice([FromRoute] int id)
        {
            var invoice = await _customerService.GetInvoiceCustomer(id);
            return Ok(invoice);
        }

        //Счета покупателя
        [HttpGet("{id}/invoices")]
        public async Task<IActionResult> GetInvoices([FromRoute] int id)
        {
            var invoices = await _customerService.GetInvoices(id);
            return Ok(invoices);
        }

        //
        [HttpPut("{id}/edit_profile_customer")]
        public async Task<IActionResult> EditProfile([FromRoute] int id, [FromBody] Customer customer)
        {
            var isChanged = await _customerService.ChangeCustomer(id, customer);
            return Ok(isChanged);
        }

        [HttpDelete("{id}/delete_profile_customer")]
        public async Task<IActionResult> DeleteProfile([FromRoute] int id)
        {
            var isDeleted = await _customerService.DeleteCustomer(id);
            return Ok(isDeleted);
        }
    }
}
