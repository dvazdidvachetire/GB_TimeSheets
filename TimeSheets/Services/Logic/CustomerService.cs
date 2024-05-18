using System.Collections.Generic;
using System.Linq;
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
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public CustomerService(ICustomersRepository customersRepository,
            IContractsRepository contractsRepository,
            IInvoicesRepository invoicesRepository,
            IJobRepository jobRepository,
            ITimeSheetRepository timeSheetRepository,
            IEmployeesRepository employeesRepository)
        {
            _customersRepository = customersRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
            _jobRepository = jobRepository;
            _timeSheetRepository = timeSheetRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<bool> RegisterCustomer(Customer customer)
        {
            return await _customersRepository.CreateObjectsAsync(customer);
        }

        public async Task<IReadOnlyList<Customer>> GetCustomers()
        {
            return await _customersRepository.GetObjectsAsync();
        }

        public async Task<ContractDto> GetContractCustomer(int id)
        {
            var contracts = await _contractsRepository.GetObjectsAsync();
            var customers = await _customersRepository.GetObjectsAsync();

            var mapper = await MapperConfiguration();

            var contractsWithCustomers = await Task.Run(() => contracts.Join(customers,
                c => c.CustomerIdC,
                c => c.Id,
                (contract, customer) =>
                {
                    contract.Customer = customer;
                    return Task.Run(() => mapper.Map(contract, contract)).GetAwaiter().GetResult();
                }
            ));

            var jobs = await _jobRepository.GetObjectsAsync();

            return await Task.Run(() => contractsWithCustomers.GroupJoin(jobs,
                c => c.Id,
                j => j.CustomerIdJ,
                (contract, js) =>
                {
                    var result = Task.Run(() => mapper.Map<ContractDto>(contract)).GetAwaiter().GetResult();
                    result.Jobs = js;
                    return result;
                }).SingleOrDefault(c => c.Id == id));
        }

        public async Task<IReadOnlyList<Contract>> GetContracts(int id)
        {
            var contracts = await _contractsRepository.GetObjectsAsync();
            return await Task.Run(() => contracts.Where(c => c.CustomerIdC == id).ToList());
        }

        public async Task<InvoiceDto> GetInvoiceCustomer(int id)
        {
            var invoices = await _invoicesRepository.GetObjectsAsync();
            var customers = await GetCustomers();
            var jobs = await _jobRepository.GetObjectsAsync();
            var timeSheets = await _timeSheetRepository.GetObjectsAsync();
            var employees = await _employeesRepository.GetObjectsAsync();

            var mapper = await MapperConfiguration();

            var timeSheetsWithEmployees = await Task.Run(() => timeSheets.Join(employees,
                t => t.EmployeeIdT,
                e => e.Id,
                (ts, empl) =>
                {
                    ts.Employee = empl;
                    return Task.Run(() => mapper.Map<TimeSheetDto>(ts)).GetAwaiter().GetResult();
                }));

            var invoicesWithCustomers = await Task.Run(() => invoices.Join(customers,
                i => i.CustomerIdI,
                c => c.Id,
                (invoice, customer) =>
                {
                    invoice.Customer = customer;
                    return Task.Run(() => mapper.Map(invoice, invoice))
                        .GetAwaiter()
                        .GetResult();
                }));

            var jobsWithTimeSheets = await Task.Run(() => jobs.GroupJoin(timeSheetsWithEmployees,
                j => j.Id,
                c => c.JobIdT,
                (job, ts)
                    =>
                {
                    var dto = Task.Run(() => mapper.Map<JobCustomerDto>(job)).GetAwaiter().GetResult();
                    dto.TimeSheets = ts.ToList();
                    return dto;
                }));

            return await Task.Run(() => invoicesWithCustomers.GroupJoin(jobsWithTimeSheets,
                i => i.CustomerIdI,
                j => j.CustomerIdJ,
                (invoice, jobs) =>
                {
                    var dto = Task.Run(() => mapper.Map<InvoiceDto>(invoice)).GetAwaiter().GetResult();
                    dto.Jobs = jobs.ToList();
                    dto.TotalSum = Task.Run(() => dto.Jobs.Select(j => j.Amount).Sum()).GetAwaiter().GetResult();
                    return dto;
                }).SingleOrDefault(i => i.Id == id));
        }

        public async Task<IReadOnlyList<Invoice>> GetInvoices(int id)
        {
            var invoices = await _invoicesRepository.GetObjectsAsync();
            return await Task.Run(() => invoices.Where(i => i.CustomerIdI == id).ToList());
        }

        public async Task<bool> ChangeCustomer(int id, Customer customer)
        {
            return await _customersRepository.UpdateObjectsAsync(id, customer);
        }

        public async Task<bool> DeleteCustomer(int id)
        {
            return await _customersRepository.DeleteObjectsAsync(id);
        }

        private async Task<IMapper> MapperConfiguration()
        {
            var mc = await Task.Run(() => new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Contract, ContractDto>()
                    .ForMember(dest => dest.CustomerFullName, act => act.MapFrom(src => src.Customer.FullName));
                cfg.CreateMap<Invoice, InvoiceDto>()
                    .ForMember(dest => dest.CustomerFullName, act => act.MapFrom(src => src.Customer.FullName));
                cfg.CreateMap<TimeSheet, TimeSheetDto>()
                    .ForMember(dest => dest.EmployeeName, act => act.MapFrom(src => src.Employee.FullName));
                cfg.CreateMap<Job, JobCustomerDto>();
            }));
            return mc.CreateMapper();
        }
    }
}
