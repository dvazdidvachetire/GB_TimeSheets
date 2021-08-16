using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DTO;
using Task = TimeSheets.DAL.Models.Task;

namespace TimeSheets.DAL.Interfaces
{
    public interface ITasksRepository
    {
        public IList<Models.Task> Tasks { get; set; }
        public IList<TaskDto> TaskDtos { get; set; }
    }
}
