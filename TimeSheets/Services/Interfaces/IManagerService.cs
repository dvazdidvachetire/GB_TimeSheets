using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.Services.Interfaces
{
    public interface IManagerService
    {
        Task<bool> CreateJob(int id, Job job);
        Task<bool> CreateContract(Contract contract);
        Task<bool> CreateInvoice(Invoice invoice);
        Task<IEnumerable<Contract>> GetContracts();
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<IEnumerable<ContractDto>> GetContractsCustomer(int id);
        Task<IEnumerable<InvoiceDto>> GetInvoicesCustomer(int id);
    }
}
