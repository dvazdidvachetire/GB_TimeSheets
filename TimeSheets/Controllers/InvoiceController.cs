using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoicesRepository _repository;

        public InvoiceController(IInvoicesRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] Invoice invoice)
        {
            var invoices = _repository.CreateInvoice(invoice);
            return Ok(invoices);
        }

        [HttpGet("invoice/{number}")]
        public IActionResult Read([FromRoute] int number)
        {
            var invoice = _repository.GetInvoice(number);
            return Ok(invoice);
        }

        [HttpGet("invoices")]
        public IActionResult ReadAll()
        {
            var invoices = _repository.GetAllInvoices();
            return Ok(invoices);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var invoices = _repository.DeleteInvoice(id);
            return Ok(invoices);
        }
    }
}
