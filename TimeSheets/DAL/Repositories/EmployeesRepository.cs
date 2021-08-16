using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private IList<Employee> _employees = new List<Employee>();

        public async Task CreateObjects(Employee employee)
        {
            await Task.Run(() => _employees.Add(employee));
        }

        public async Task<Employee> GetObject(int id)
        {
            return await Task.Run( () => _employees.SingleOrDefault(e => e.Id == id));
        }

        public async Task UpdateObject(int id, Employee employee)
        {
            await Task.Run(() =>
            {
                _employees = _employees.Select(e =>
                {
                    if (e.Id == id)
                    {
                        e = employee;
                        return e;
                    }

                    return e;

                }).ToList();
            });
        }

        public async Task DeleteObject(int id)
        {
            await Task.Run(() => _employees.RemoveAt(id));
        }
    }
}
