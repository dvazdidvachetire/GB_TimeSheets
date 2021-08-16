using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Interfaces
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
    }
}
