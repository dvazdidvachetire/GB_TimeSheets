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
    public class InvoicesRepository : IInvoicesRepository
    {
        private IList<Invoice> _invoices = new List<Invoice>();
        private IList<InvoiceDto> _invoicesDtos = new List<InvoiceDto>();
        private readonly ICustomersRepository _customersRepository;
        private readonly IJobRepository _tasksRepository;
        public InvoicesRepository(ICustomersRepository customersRepository,
            IJobRepository tasksRepository)
        {
            _customersRepository = customersRepository;
            _tasksRepository = tasksRepository;
        }

        private async Task<InvoiceDto> Map(Invoice invoice)
        {
            var tasks = await _tasksRepository.GetCompletedTasksById(invoice.CustomerId);
            var totalSum = await Task.Run(() => tasks.Select(t => t.Amount).Sum());

            return await Task.Run(async () => new InvoiceDto
            {
                Id = invoice.Id,
                Customer = await _customersRepository.GetByIdCustomer(invoice.CustomerId),
                Tasks = tasks,
                TotalSum = totalSum
            });
        }

        public async Task<IEnumerable<Invoice>> CreateObjects(Invoice invoice)
        {
             await Task.Run(() => _invoices.Add(invoice));
             await Task.Run(async () => _invoicesDtos.Add(await Map(invoice)));
             return _invoices;
        }

        public async Task<IEnumerable<Invoice>> GetObjects()
        {
            return await Task.Run(() => _invoices);
        }

        public Task<IEnumerable<Invoice>> UpdateObjects(int id, Invoice invoice)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InvoiceDto>> ExposedInvoices()
        {
            return await Task.Run(() => _invoicesDtos);
        }
    }
}
