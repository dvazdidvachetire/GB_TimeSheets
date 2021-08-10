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
        private readonly SortedDictionary<int, Employee> _employees = new SortedDictionary<int, Employee>();

        public SortedDictionary<int, Employee> AddObjects(Employee employee, int id)
        {
            try
            {
                _employees.Add(id, employee);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }

            return _employees;
        }

        public SortedDictionary<int, Employee> GetAllObjects()
        {
            return _employees;
        }

        public SortedDictionary<int, Employee> ChangeObjects(Employee employee, int id)
        {
            _employees[id] = employee;
            return _employees;
        }

        public SortedDictionary<int, Employee> DeleteObjects(int id)
        {
            _employees.Remove(id);
            return _employees;
        }
    }
}
