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
        private readonly IJobRepository _tasksRepository;
        private readonly ICustomersRepository _customersRepository;

        public ContractsRepository(IJobRepository tasksRepository,
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

        public Task<IEnumerable<ContractDto>> CreateContract(Contract contract)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ContractDto>> GetAllContracts()
        {
            return await Task.Run(() => _contractsDto);
        }

        public async Task<IEnumerable<Contract>> CreateObjects(Contract contract)
        {
            await Task.Run(async () => _contractsDto.Add(await Map(contract)));
            return null;
        }

        public Task<IEnumerable<Contract>> GetObjects()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contract>> UpdateObjects(int id, Contract contract)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contract>> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
