using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IContractsRepository _contractsRepository;
        private readonly IInvoicesRepository _invoicesRepository;

        public CustomerService(ICustomersRepository customersRepository,
            IContractsRepository contractsRepository,
            IInvoicesRepository invoicesRepository)
        {
            _customersRepository = customersRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
        }

        public async Task<bool> RegisterCustomer(Customer customer)
        {
            return await _customersRepository.CreateObjects(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _customersRepository.GetObjects();
        }

        public async Task<ContractDto> GetContractCustomer(int id, int idC)
        {
            var contracts = await GetContractsCustomer(id);
            var contract = await Task.Run(() => contracts.SingleOrDefault(c => c.Id == idC));
            return contract;
        }

        public async Task<IEnumerable<ContractDto>> GetContractsCustomer(int id)
        {
            if (_contractsRepository is ContractsRepository contractsRepository)
            {
                var contractsCustomer = await Task.Run(() => contractsRepository.ContractsDto.Where(c => c.Customer.Id == id));
                return contractsCustomer;
            }

            return default;
        }

        public async Task<InvoiceDto> GetInvoiceCustomer(int id, int idI)
        {
            var invoices = await GetInvoicesCustomer(id);
            var invoice = await Task.Run(() => invoices.SingleOrDefault(i => i.Id == idI));
            return invoice;
        }

        public async Task<IEnumerable<InvoiceDto>> GetInvoicesCustomer(int id)
        {
            if (_invoicesRepository is InvoicesRepository invoicesRepository)
            {
                var invoicesCustomer = await Task.Run(() => invoicesRepository.InvoicesDtos.Where(i => i.Customer.Id == id));
                return invoicesCustomer;
            }

            return default;
        }

        public async Task<bool> ChangeCustomer(int id, Customer customer)
        {
            return await _customersRepository.UpdateObjects(id, customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customersRepository.DeleteObjects(id);
        }
    }
}
