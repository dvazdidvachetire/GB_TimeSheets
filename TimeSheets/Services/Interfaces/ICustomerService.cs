using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;

namespace TimeSheets.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> RegisterCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetCustomers();
        Task<ContractDto> GetContractCustomer(int id, int idC);
        Task<IEnumerable<ContractDto>> GetContractsCustomer(int id);
        Task<InvoiceDto> GetInvoiceCustomer(int id, int idI);
        Task<IEnumerable<InvoiceDto>> GetInvoicesCustomer(int id);
        Task<IEnumerable<Customer>> ChangeCustomer(int id, Customer customer);
        Task<IEnumerable<Customer>> DeleteCustomer(int id);
    }
}
