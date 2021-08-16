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
    public class CustomersRepository : ICustomersRepository
    {
        private IList<Customer> _customers = new List<Customer>();

        public async Task CreateObjects(Customer customer)
        {
            await Task.Run(() => _customers.Add(customer));
        }

        public async Task<Customer> GetObject(int id)
        {
            return await Task.Run(() =>_customers.SingleOrDefault(c => c.Id == id));
        }

        public async Task UpdateObject(int id, Customer customer)
        {
            await Task.Run(() =>
            {
                _customers = _customers.Select(c =>
                {
                    if (c.Id == id)
                    {
                        c = customer;
                        return c;
                    }

                    return c;

                }).ToList();
            });
        }

        public async Task DeleteObject(int id)
        {
            await Task.Run(() => _customers.RemoveAt(id));
        }
    }
}
