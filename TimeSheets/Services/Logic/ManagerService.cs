using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.DTO;
using TimeSheets.Infrastructure.Models;
using TimeSheets.Infrastructure.Repositories;
using TimeSheets.Interfaces;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class ManagerService : IManagerService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IContractsRepository _contractsRepository;
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly ICustomersRepository _customersRepository;

        public ManagerService(IJobRepository jobRepository,
            IContractsRepository contractsRepository,
            IInvoicesRepository invoicesRepository,
            ICustomersRepository customersRepository)
        {
            _jobRepository = jobRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
            _customersRepository = customersRepository;
        }

        public async Task<IEnumerable<Job>> CreateJob(Job job)
        {
            return await _jobRepository.CreateObjects(job);
        }

        public async Task<IEnumerable<Contract>> CreateContract(Contract contract)
        {
            if (_contractsRepository is ContractsRepository repository)
            {
                await Task.Run(async () => repository.ContractsDto.Add(await MapContract(contract)));
            }

            return await _contractsRepository.CreateObjects(contract);
        }

        public async Task<IEnumerable<Invoice>> CreateInvoice(Invoice invoice)
        {
            if (_invoicesRepository is InvoicesRepository repository)
            {
                await Task.Run(async () => repository.InvoicesDtos.Add(await MapInvoice(invoice)));
            }

            return await _invoicesRepository.CreateObjects(invoice);
        }

        public async Task<IEnumerable<Contract>> GetContracts()
        {
            return await _contractsRepository.GetObjects();
        }

        public async Task<IEnumerable<Invoice>> GetInvoices()
        {
            return await _invoicesRepository.GetObjects();
        }

        public async Task<IEnumerable<ContractDto>> GetContractsCustomer(int id)
        {
            if (_contractsRepository is ContractsRepository repository)
            {
                var contracts = await Task.Run(() => repository.ContractsDto.Where(c => c.Id == id));
                return contracts;
            }

            return default;
        }

        public async Task<IEnumerable<InvoiceDto>> GetInvoicesCustomer(int id)
        {
            if (_invoicesRepository is InvoicesRepository repository)
            {
                var invoices = await Task.Run(() => repository.InvoicesDtos.Where(i => i.Id == id));
                return invoices;
            }

            return default;
        }

        private async Task<ContractDto> MapContract(Contract contract)
        {
            var customers = await _customersRepository.GetObjects();
            var customer = await Task.Run(() => customers.SingleOrDefault(c => c.Id == contract.CustomerId));

            var jobs = await _jobRepository.GetObjects();
            var jobsCustomer = await Task.Run(() => jobs.Where(j => j.CustomerId == contract.CustomerId));

            return await Task.Run(() => new ContractDto
            {
                Id = contract.Id,
                NumberContract = contract.NumberContract,
                Customer = customer,
                Jobs = jobsCustomer
            });
        }

        private async Task<InvoiceDto> MapInvoice(Invoice invoice)
        {
            var customers = await _customersRepository.GetObjects();
            var customer = await Task.Run(() => customers.SingleOrDefault(c => c.Id == invoice.CustomerId));

            var jobs = await Task.Run(() => (_jobRepository is JobRepository jobRepository) ? jobRepository.JobsDtos : default);
            var completedJobs = await Task.Run(() => jobs.Where(j => j.CustomerId == invoice.CustomerId));
            var totalSum = completedJobs.Sum(j => j.Amount);

            return await Task.Run(() => new InvoiceDto
            {
                Id = invoice.Id,
                Customer = customer,
                Jobs = completedJobs,
                TotalSum = totalSum
            });
        }
    }
}
