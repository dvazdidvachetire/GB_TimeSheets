using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TimeSheets.Models;

namespace TimeSheets.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly Repositories _tasksRepositories;

        public TasksController(Repositories tasksRepositories)
        {
            _tasksRepositories = tasksRepositories;
        }

        [HttpPost()]
        public IActionResult Create([FromBody] Task task)
        {
            _tasksRepositories.Tasks.Add(task);
            return Ok();
        }

        [HttpGet()]
        public IActionResult GetAllTask()
        {
            return Ok(_tasksRepositories.Tasks);
        }
    }
}
