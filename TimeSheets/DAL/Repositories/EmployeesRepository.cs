using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private IList<Employee> _employees = new List<Employee>();

        public async Task<IEnumerable<Employee>> CreateObjects(Employee contract)
        {
            await Task.Run(() => _employees.Add(contract));
            return _employees;
        }

        public async Task<IEnumerable<Employee>> GetObjects()
        {
            return await Task.Run(() => _employees);
        }

        public async Task<IEnumerable<Employee>> UpdateObjects(int id, Employee employee)
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

            return _employees;
        }

        public async Task<IEnumerable<Employee>> DeleteObjects(int id)
        {
            await Task.Run(() => _employees.RemoveAt(id));
            return _employees;
        }
    }
}
