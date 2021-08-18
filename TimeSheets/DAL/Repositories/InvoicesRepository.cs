using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Repositories
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
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Invoice>> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
