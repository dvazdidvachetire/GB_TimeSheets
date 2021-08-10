using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.Responses.DTO;

namespace TimeSheets.DAL.Repositories
{
    public class ContractsRepository : IContractsRepository
    {
        private readonly IList<ContractDto> _contracts = new List<ContractDto>();
        private readonly IEmployeesRepository _repositoryEmployees;
        private readonly IClientsRepository _repositoryClients;

        public ContractsRepository(IEmployeesRepository repositoryEmployees, IClientsRepository repositoryClients)
        {
            _repositoryEmployees = repositoryEmployees;
            _repositoryClients = repositoryClients;
        }

        public IEnumerable<ContractDto> AddContracts(Contract contract)
        {
            try
            {
                var client = _repositoryClients.GetAllObjects().SingleOrDefault(c => c.Id == contract.IdClient);

                var employees = new List<Employee>();

                foreach (var idEmpl in contract.IdEmployee)
                {
                    employees.Add(_repositoryEmployees.GetAllObjects().SingleOrDefault(e => e.Id == idEmpl));
                }

                _contracts.Add(new ContractDto
                {
                    Id = contract.Id,
                    NumberContract = contract.NumberContract,
                    Client = client,
                    Employees = employees,
                    TypeJob = contract.TypeJob,
                    QuantityJob = contract.QuantityJob,
                    Price = contract.Price
                });
                
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return _contracts;
        }

        public ContractDto GetContract(int number)
        {
            var contract = GetAllContracts().SingleOrDefault(c => c.NumberContract == number);
            return contract;
        }

        public IEnumerable<ContractDto> GetAllContracts()
        {
            return _contracts;
        }

        public IEnumerable<ContractDto> DeleteContracts(int id)
        {
            for (int i = 0; i < _contracts.Count; i++)
            {
                if (id == _contracts[i].Id)
                {
                    _contracts.RemoveAt(i);
                }
            }

            return _contracts;
        }
    }
}
