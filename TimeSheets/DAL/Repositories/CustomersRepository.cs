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
    public class CustomersRepository : ICustomersRepository
    {
        private IList<Customer> _customers = new List<Customer>();
        private readonly IInvoicesRepository _invoicesRepository;
        public CustomersRepository(IInvoicesRepository invoicesRepository)
        {
            _invoicesRepository = invoicesRepository;
        }

        public async Task<IEnumerable<Customer>> CreateObjects(Customer customer)
        {
            await Task.Run(() => _customers.Add(customer));
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

        public Task<Customer> EditProfile(int id, Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> GetByIdCustomer(int id)
        {
            return await Task.Run(() => _customers.SingleOrDefault(c => c.Id == id));
        }

        public async Task<IEnumerable<InvoiceDto>> GetInvoices(int id)
        {
            var invoices = await _invoicesRepository.ExposedInvoices();
            var invoicesCustomer = await Task.Run(() => invoices.Where(i => i.Id == id));
            return invoicesCustomer;
        }
    }
}
