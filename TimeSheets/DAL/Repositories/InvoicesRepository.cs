using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.Responses.DTO;

namespace TimeSheets.DAL.Repositories
{
    public class InvoicesRepository : IInvoicesRepository
    {
        private readonly IContractsRepository _repository;
        private readonly IList<InvoiceDto> _invoices = new List<InvoiceDto>();

        public InvoicesRepository(IContractsRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<InvoiceDto> CreateInvoice(Invoice invoice)
        {
            var contract = _repository.GetContract(invoice.NumberContract);
            var totalPrice = contract.Price * contract.QuantityJob;

            _invoices.Add(new InvoiceDto
            {
                Id = invoice.Id,
                NumberInvoice = invoice.NumberInvoice,
                Contracts = contract,
                TotalPrice = totalPrice
            });

            return _invoices;
        }

        public InvoiceDto GetInvoice(int number)
        {
            var invoice = GetAllInvoices().SingleOrDefault(i => i.NumberInvoice == number);
            return invoice;
        }

        public IEnumerable<InvoiceDto> GetAllInvoices()
        {
            return _invoices;
        }

        public IEnumerable<InvoiceDto> DeleteInvoice(int id)
        {
            for (int i = 0; i < _invoices.Count; i++)
            {
                if (id == _invoices[i].Id)
                {
                    _invoices.RemoveAt(i);
                }
            }

            return _invoices;
        }
    }
}
