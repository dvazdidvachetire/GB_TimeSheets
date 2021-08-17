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
                Customer = await _customersRepository.GetByIdCustomer(contract.CustomerId),
                Tasks = await _tasksRepository.GetTasksById(contract.Id)
            });

            return contractDto;
        }

        public async Task<IEnumerable<ContractDto>> CreateContract(Contract contract)
        {
            await Task.Run(async () => _contractsDto.Add(await Map(contract)));
            return _contractsDto;
        }

        public async Task<IEnumerable<ContractDto>> GetAllContracts()
        {
            return await Task.Run(() => _contractsDto);
        }
    }
}
