using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DTO;
using Task = TimeSheets.DAL.Models.Task;

namespace TimeSheets.DAL.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        public IList<Task> Tasks { get; set; } = new List<Task>();
        public IList<TaskDto> TaskDtos { get; set; } = new List<TaskDto>();
    }
}
