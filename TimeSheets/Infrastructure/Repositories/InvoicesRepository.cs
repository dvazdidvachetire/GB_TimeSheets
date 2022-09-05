using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;
using TimeSheets.Interfaces;

namespace TimeSheets.Infrastructure.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private IList<Invoice> _invoices = new List<Invoice>();
        public IList<InvoiceDto> InvoicesDtos { get; set; } = new List<InvoiceDto>();

        public async Task<IEnumerable<Invoice>> CreateObjects(Invoice invoice)
        {
             await Task.Run(() => _invoices.Add(invoice));
             return _invoices;
        }

        public async Task<IEnumerable<Invoice>> GetObjects()
        {
            return await Task.Run(() => _invoices);
        }

        public Task<IEnumerable<Invoice>> UpdateObjects(int id, Invoice invoice)
        {
            return null;
        }

        public Task<IEnumerable<Invoice>> DeleteObjects(int id)
        {
            return null;
        }
    }
}
