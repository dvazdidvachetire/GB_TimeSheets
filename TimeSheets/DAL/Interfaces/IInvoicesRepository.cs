using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.Responses.DTO;

namespace TimeSheets.DAL.Interfaces
{
    public interface IInvoicesRepository
    {
        IEnumerable<InvoiceDto> CreateInvoice(Invoice invoice);
        InvoiceDto GetInvoice(int id);
        IEnumerable<InvoiceDto> GetAllInvoices();
        IEnumerable<InvoiceDto> DeleteInvoice(int id);
    }
}
