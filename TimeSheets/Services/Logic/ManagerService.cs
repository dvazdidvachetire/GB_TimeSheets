using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories;
using TimeSheets.DTO;
using TimeSheets.Services.Interfaces;

namespace TimeSheets.Services.Logic
{
    public class ManagerService : IManagerService
    {
        private readonly IJobRepository _jobRepository;
        private readonly IContractsRepository _contractsRepository;
        private readonly IInvoicesRepository _invoicesRepository;
        private readonly ICustomersRepository _customersRepository;
        private readonly ITimeSheetRepository _timeSheetRepository;
        private readonly IEmployeesRepository _employeesRepository;

        public ManagerService(IJobRepository jobRepository,
            IContractsRepository contractsRepository,
            IInvoicesRepository invoicesRepository,
            ICustomersRepository customersRepository,
            ITimeSheetRepository timeSheetRepository,
            IEmployeesRepository employeesRepository)
        {
            _jobRepository = jobRepository;
            _contractsRepository = contractsRepository;
            _invoicesRepository = invoicesRepository;
            _customersRepository = customersRepository;
            _timeSheetRepository = timeSheetRepository;
            _employeesRepository = employeesRepository;
        }

        public async Task<bool> CreateJob(Job job)
        {
            return await _jobRepository.CreateObjects(job);
        }

        public async Task<bool> CreateContract(Contract contract)
        {
            return await _contractsRepository.CreateObjects(contract);
        }

        public async Task<bool> CreateInvoice(Invoice invoice)
        {
            return await _invoicesRepository.CreateObjects(invoice);
        }

        public async Task<IReadOnlyList<Contract>> GetContracts()
        {
            return await _contractsRepository.GetObjects();
        }

        public async Task<IReadOnlyList<Invoice>> GetInvoices()
        {
            return await _invoicesRepository.GetObjects();
        }

        public async Task<ContractDto> GetContractCustomer(int id)
        {
            var contracts = await GetContracts();
            var customers = await _customersRepository.GetObjects();

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

            var jobs = await _jobRepository.GetObjects();

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

        public async Task<InvoiceDto> GetInvoiceCustomer(int id)
        {
            var invoices = await GetInvoices();
            var customers = await _customersRepository.GetObjects();
            var jobs = await _jobRepository.GetObjects();
            var timeSheets = await _timeSheetRepository.GetObjects();
            var employees = await _employeesRepository.GetObjects();

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
