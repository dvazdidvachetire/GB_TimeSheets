using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<Contract>> CreateContract(Contract contract);
        Task<IEnumerable<Models.Task>> CreateTask(Models.Task task);
    }
}
