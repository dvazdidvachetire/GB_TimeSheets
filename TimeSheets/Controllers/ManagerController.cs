using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost("invoice")]
        public IActionResult CreateInvoice()
        {
            return Ok();
        }
    }
}
