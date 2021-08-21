using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class CustomersRepository : ICustomersRepository
    {
        private IList<Customer> _customers = new List<Customer>();

        public async Task<IEnumerable<Customer>> CreateObjects(Customer contract)
        {
            await Task.Run(() => _customers.Add(contract));
            return _customers;
        }

        public async Task<IEnumerable<Customer>> GetObjects()
        {
            return await Task.Run(() =>_customers);
        }

        public async Task<IEnumerable<Customer>> UpdateObjects(int id, Customer customer)
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

            return _customers;
        }

        public async Task<IEnumerable<Customer>> DeleteObjects(int id)
        {
            await Task.Run(() => _customers.RemoveAt(id));
            return _customers;
        }
    }
}
