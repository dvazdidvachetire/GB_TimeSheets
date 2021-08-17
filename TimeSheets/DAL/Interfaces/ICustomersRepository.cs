using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Interfaces
{
    public interface ICustomersRepository : IRepository<Customer>
    {
        Task<Customer> EditProfile(int id, Customer customer);
        Task<Customer> GetByIdCustomer(int id);
        Task<IEnumerable<InvoiceDto>> GetInvoices(int id);
    }
}
