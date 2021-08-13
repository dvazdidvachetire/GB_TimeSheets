using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly Repositories _repositories;

        public CustomersController(Repositories repositories)
        {
            _repositories = repositories;
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Customer customer)
        {
            _repositories.Customers.Add(customer);
            return Ok("Регистрация прошла успешно!");
        }

        [HttpGet("{id}/contract/{idContract}")]
        public IActionResult GetContract([FromRoute] int id, [FromRoute] int idContract)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == id);
            var contract = customer?.Contracts.SingleOrDefault(c => c.Id == idContract);
            return Ok(contract);
        }

        [HttpGet("{id}/contracts")]
        public IActionResult GetContracts([FromRoute] int id)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == id);
            return Ok(customer?.Contracts);
        }

        [HttpGet("{id}/invoice/{idInvoice}")]
        public IActionResult GetInvoice([FromRoute] int id, [FromRoute] int idInvoice)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == id);
            var invoice = customer?.Invoices.SingleOrDefault(i => i.Id == idInvoice);
            return Ok(invoice);
        }

        [HttpGet("{id}/invoices")]
        public IActionResult GetInvoices([FromRoute] int id)
        {
            var customer = _repositories.Customers.SingleOrDefault(c => c.Id == id);
            var invoices = customer?.Invoices;
            return Ok(invoices);
        }
    }
}
