using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class EmployeesRepository : IEmployeesRepository
    {
        private readonly DbContextRepository _context;

        public EmployeesRepository(DbContextRepository context)
        {
            _context = context;
        }

        public async Task<bool> CreateObjects(Employee employee)
        {
            try
            {
                await _context.AddAsync(employee);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write($"Ошибка! Ошибка! {e.Message}");
                return false;
            }
        }

        public async Task<IReadOnlyList<Employee>> GetObjects()
        {
            try
            {
                return await _context.Employees.Where(e => e.IsDeleted == false).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public async Task<bool> UpdateObjects(int id, Employee employee)
        {
            try
            {
                var emp = await _context.Employees.FindAsync(id);
                emp.FullName = employee.FullName;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<bool> DeleteObjects(int id)
        {
            try
            {
                var employee = await _context.Employees.FindAsync(id);
                employee.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }
    }
}
