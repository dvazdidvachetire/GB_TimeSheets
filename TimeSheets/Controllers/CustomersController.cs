using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DTO;
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

        [HttpPost("register")]
        public IActionResult Create([FromBody] Customer customer)
        {
            _repositories.Customers.Add(customer);
            return Ok("Регистрация прошла успешно!");
        }

        [HttpGet("{idC}/contract/{id}")]
        public IActionResult GetContract([FromRoute] int idC, [FromRoute] int id)
        {
            var contracts = _repositories.Contracts.Where(c => c.Customer.Id == idC);
            var contract = contracts.SingleOrDefault(c => c.Id == id);
            return Ok(contract);
        }

        [HttpGet("{id}/contracts")]
        public IActionResult GetContracts([FromRoute] int id)
        {
            var contracts = _repositories.Contracts.Where(c => c.Customer.Id == id);
            return Ok(contracts);
        }

        [HttpGet("{idC}/invoice/{id}")]
        public IActionResult GetInvoice([FromRoute] int idC, [FromRoute] int id)
        {
            var invoices = _repositories.InvoiceDtos.Where(i => i.Customer.Id == idC);
            var invoice = invoices.SingleOrDefault(i => i.Id == id);
            return Ok(invoice);
        }

        [HttpGet("{id}/invoices")]
        public IActionResult GetInvoicesById([FromRoute] int id)
        {
            var invoices = _repositories.InvoiceDtos.Where(i => i.Customer.Id == id);
            return Ok(invoices);
        }

        [HttpGet("{id}/profile")]
        public IActionResult GetProfile([FromRoute] int id)
        {
            var employee = _repositories.Customers.SingleOrDefault(e => e.Id == id);
            return Ok(employee);
        }

        [HttpPut("{id}/edit_profile_customer")]
        public IActionResult EditProfile([FromRoute] int id, [FromBody] Customer customer)
        {
            _repositories.Customers = _repositories.Customers.Select(c =>
            {
                if (c.Id == id)
                {
                    c = customer;
                    return c;
                }

                return c;

            }).ToList();

            return Ok("Профиль успешно изменен!");
        }

        [HttpDelete("delete_profile_customer")]
        public IActionResult DeleteProfile([FromRoute] int id)
        {
            _repositories.Customers.RemoveAt(id);
            return Ok("Профиль успешно удален!");
        }
    }
}
