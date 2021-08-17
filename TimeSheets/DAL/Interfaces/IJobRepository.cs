using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Interfaces
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<IEnumerable<JobDto>> GetCompletedTasks();
        Task<IEnumerable<JobDto>> GetCompletedTasksById(int id);
        Task<IEnumerable<Job>> GetTasksById(int id);
        Task<JobDto> UpdateTask(int id, TimeSheet timeSheet);
    }
}
