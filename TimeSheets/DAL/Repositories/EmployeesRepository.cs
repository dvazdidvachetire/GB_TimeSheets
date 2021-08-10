using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly IList<Employee> _employees = new List<Employee>();

        public IEnumerable<Employee> AddObjects(Employee employee)
        {
            try
            {
                _employees.Add(employee);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return _employees;
        }

        public IEnumerable<Employee> GetAllObjects()
        {
            return _employees;
        }

        public IEnumerable<Employee> ChangeObjects(Employee employee)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (_employees[i].Id == employee.Id)
                {
                    _employees[i] = employee;
                }
            }

            return _employees;
        }

        public IEnumerable<Employee> DeleteObjects(int id)
        {
            for (int i = 0; i < _employees.Count; i++)
            {
                if (id == _employees[i].Id)
                {
                    _employees.RemoveAt(i);
                }
            }

            return _employees;
        }
    }
}
