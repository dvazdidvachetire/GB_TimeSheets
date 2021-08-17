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
            return await _tasksRepository.CreateTask(task);
        }

        public async Task<IEnumerable<Contract>> CreateContract(Contract contract)
        {
            return await _contractsRepository.CreateContract(contract);
        }
    }
}
