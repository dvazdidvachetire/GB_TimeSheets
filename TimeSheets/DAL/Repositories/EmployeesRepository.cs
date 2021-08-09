using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public Task AddObjects(Employee objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> ChangeObjects(Employee objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> DeleteObjects(string name)
        {
            throw new NotImplementedException();
        }
    }
}
