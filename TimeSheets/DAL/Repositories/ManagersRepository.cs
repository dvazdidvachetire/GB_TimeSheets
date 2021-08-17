using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DTO;
using Task = System.Threading.Tasks.Task;

namespace TimeSheets.DAL.Repositories
{
    public class ManagersRepository : IManagerRepository
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IContractsRepository _contractsRepository;
        private readonly ICustomersRepository _customersRepository;

        public ManagersRepository(ITasksRepository tasksRepository,
            IContractsRepository contractsRepository,
            ICustomersRepository customersRepository)
        {
            _tasksRepository = tasksRepository;
            _contractsRepository = contractsRepository;
            _customersRepository = customersRepository;
        }

        public async Task<IEnumerable<Models.Task>> CreateTask(Models.Task task)
        {
            return await _tasksRepository.CreateObjects(task);
        }

        public async Task<IEnumerable<ContractDto>> CreateContract(Contract contract)
        {
            return await _contractsRepository.CreateContract(contract);
        }

        public async Task<ContractDto> GetByIdContract(int id, int idC)
        {
            var contracts = await GetByIdContracts(id);
            var contract = await Task.Run(() => contracts.SingleOrDefault(c => c.Id == idC));
            return contract;
        }

        public async Task<IEnumerable<ContractDto>> GetByIdContracts(int id)
        {
            var contracts = await _contractsRepository.GetAllContracts();
            var customerContracts = await Task.Run(() => contracts.Where(c => c.Customer.Id == id));
            return customerContracts;
        }

        public async Task<IEnumerable<ContractDto>> GetAllContracts()
        {
            return await Task.Run(() => _contractsRepository.GetAllContracts());
        }
    }
}
