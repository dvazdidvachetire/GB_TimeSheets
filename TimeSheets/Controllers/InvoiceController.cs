using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        [HttpGet("invoice")]
        public IActionResult Read([FromRoute] int number)
        {
            return Ok();
        }

        [HttpGet("invoices")]
        public IActionResult ReadAll()
        {
            return Ok();
        }
    }
}
