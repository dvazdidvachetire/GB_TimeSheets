using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;

namespace TimeSheets.Services.Interfaces
{
    public interface IManagerService
    {
        Task<IEnumerable<Job>> CreateJob(Job job);
        Task<IEnumerable<Contract>> CreateContract(Contract contract);
        Task<IEnumerable<Invoice>> CreateInvoice(Invoice invoice);
        Task<IEnumerable<Contract>> GetContracts();
        Task<IEnumerable<Invoice>> GetInvoices();
        Task<IEnumerable<ContractDto>> GetContractsCustomer(int id);
        Task<IEnumerable<InvoiceDto>> GetInvoicesCustomer(int id);
    }
}
