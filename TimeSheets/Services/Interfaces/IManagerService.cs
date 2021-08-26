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
        Task<bool> CreateJob(Job job);
        Task<bool> CreateContract(Contract contract);
        Task<bool> CreateInvoice(Invoice invoice);
        Task<IReadOnlyList<Contract>> GetContracts();
        Task<IReadOnlyList<Invoice>> GetInvoices();
        Task<ContractDto> GetContractCustomer(int id);
        Task<InvoiceDto> GetInvoiceCustomer(int id);
    }
}
