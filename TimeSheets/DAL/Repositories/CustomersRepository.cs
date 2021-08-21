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
    internal sealed class CustomersRepository : ICustomersRepository
    {
        private DbContextRepository _context;

        public CustomersRepository(DbContextRepository context)
        {
            _context = context;
        }

        public async Task<bool> CreateObjects(Customer customer)
        {
            try
            {
                await _context.AddAsync(customer);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.Write($"Ошибка! Ошибка! {e.Message}");
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyList<Customer>> GetObjects()
        {
            try
            {
                return await _context.Customers.Where(c => c.IsDeleted == false).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public async Task<bool> UpdateObjects(int id, Customer customer)
        {
            try
            {
                var cus = await _context.Customers.FindAsync(id);
                cus = customer;
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
            var customer = await _context.Customers.FindAsync(id);
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
