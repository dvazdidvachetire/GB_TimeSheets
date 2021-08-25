using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IContractsRepository _contractsRepository;
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly IJobRepository _jobRepository;

        public CustomerService(ICustomersRepository customersRepository,
            IContractsRepository contractsRepository,
            IInvoicesRepository invoicesRepository,
            IJobRepository jobRepository)
        {
            _customersRepository = customersRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
            _jobRepository = jobRepository;
        }

        public async Task<bool> RegisterCustomer(Customer customer)
        {
            return await _customersRepository.CreateObjects(customer);
        }

        public async Task<IReadOnlyList<Customer>> GetCustomers()
        {
            return await _customersRepository.GetObjects();
        }

        public async Task<ContractDto> GetContractCustomer(int id, int idC)
        {
            var contracts = await GetContractsCustomer(id);
            var contract = await Task.Run(() => contracts.SingleOrDefault(c => c.Id == idC));

            var customers = await _customersRepository.GetObjects();
            var customer = await Task.Run(() => customers.SingleOrDefault(c => c.Id == id));

            var jobs = await _jobRepository.GetObjects();
            //var jobsCustomer = await Task.Run(() => jobs.Where(j => j.Customer.Id == id));

            var mc = await Task.Run( () => new MapperConfiguration(cfg => cfg.CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.Customer, act => act.MapFrom(src => customer))));
            var mapper = mc.CreateMapper();

            return await Task.Run(() => mapper.Map<ContractDto>(contract));
        }

        public async Task<IReadOnlyList<Contract>> GetContractsCustomer(int id)
        {
            var contracts = await _contractsRepository.GetObjects();
            return await Task.Run(() => contracts.Where(c => c.CustomerIdC == id).ToList());
        }

        public async Task<InvoiceDto> GetInvoiceCustomer(int id, int idI)
        {
            //var invoices = await GetInvoicesCustomer(id);
            //var invoice = await Task.Run(() => invoices.SingleOrDefault(i => i.Id == idI));
            //return invoice;
            return null;
        }

        public async Task<IReadOnlyList<Invoice>> GetInvoicesCustomer(int id)
        {
            var invoices = await _invoicesRepository.GetObjects();
            return await Task.Run(() => invoices.Where(i => i.CustomerIdI == id).ToList());
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
