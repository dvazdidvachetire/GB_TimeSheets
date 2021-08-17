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
    public class ContractsRepository : IContractsRepository
    {
        private IList<Contract> _contracts = new List<Contract>();
        private IList<ContractDto> _contractsDto = new List<ContractDto>();
        private readonly ITasksRepository _tasksRepository;
        private readonly ICustomersRepository _customersRepository;

        public ContractsRepository(ITasksRepository tasksRepository,
            ICustomersRepository customersRepository)
        {
            _tasksRepository = tasksRepository;
            _customersRepository = customersRepository;
        }

        private async Task<ContractDto> Map(Contract contract)
        {
            var contractDto = await Task.Run(async () => new ContractDto
            {
                Id = contract.Id,
                NumberContract = contract.NumberContract,
                Customer = await _customersRepository.GetObject(contract.CustomerId),
                Tasks = await _tasksRepository.GetByIdTasks(contract.Id)
            });

            return contractDto;
        }

        public async Task<IEnumerable<Contract>> CreateContract(Contract contract)
        {
            await Task.Run(() => _contracts.Add(contract));
            await Task.Run(async () => _contractsDto.Add(await Map(contract)));
            return _contracts;
        } 

        public Task<IEnumerable<ContractDto>> GetObjects(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContractDto>> GetChangesObjects(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ContractDto>> GetAllChangesObjects()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContractDto>> GetAllObjects()
        {
            return await Task.Run(() => _contractsDto);
        }
    }
}
