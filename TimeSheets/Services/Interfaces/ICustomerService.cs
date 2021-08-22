using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<bool> RegisterCustomer(Customer customer);
        Task<IReadOnlyList<Customer>> GetCustomers();
        Task<ContractDto> GetContractCustomer(int id, int idC);
        Task<IReadOnlyList<Contract>> GetContractsCustomer(int id);
        Task<InvoiceDto> GetInvoiceCustomer(int id, int idI);
        Task<IReadOnlyList<Invoice>> GetInvoicesCustomer(int id);
        Task<bool> ChangeCustomer(int id, Customer customer);
        Task<bool> DeleteCustomer(int id);
    }
}
