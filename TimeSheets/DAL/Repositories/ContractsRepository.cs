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
        private readonly IList<Contract> _contracts = new List<Contract>();
        private readonly IEmployeesRepository _repositoryEmployees;
        private readonly IClientsRepository _repositoryClients;
        public IList<ContractDto> ContractDtos { get; set; } = new List<ContractDto>();

        public ContractsRepository(IEmployeesRepository repositoryEmployees, IClientsRepository repositoryClients)
        {
            _repositoryEmployees = repositoryEmployees;
            _repositoryClients = repositoryClients;
        }

        public IEnumerable<Contract> AddObjects(Contract contract)
        {
            try
            {
                var client = _repositoryClients.GetAllObjects().SingleOrDefault(c => c.Id == contract.IdClient);

                var employees = new List<Employee>();

                foreach (var idEmpl in contract.IdEmployee)
                {
                    employees.Add(_repositoryEmployees.GetAllObjects().SingleOrDefault(e => e.Id == idEmpl));
                }

                _contracts.Add(new Contract
                {
                    NumberContract = contract.NumberContract,
                    Client = client,
                    Employees = employees,
                    TypeJob = contract.TypeJob,
                    QuantityJob = contract.QuantityJob,
                    Price = contract.Price,
                });

                foreach (var cont in _contracts)
                {
                    ContractDtos.Add(new ContractDto
                    {
                        NumberContract = cont.NumberContract,
                        Client = cont.Client,
                        Employees = cont.Employees,
                        TypeJob = cont.TypeJob,
                        QuantityJob = cont.QuantityJob,
                        Price = cont.Price
                    });
                }
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return _contracts;
        }

        public IEnumerable<Contract> GetAllObjects()
        {
            return default;
        }

        public IEnumerable<Contract> ChangeObjects(Contract contract)
        {
            for (int i = 0; i < _contracts.Count; i++)
            {
                if (_contracts[i].Id == contract.Id)
                {
                    _contracts[i] = contract;
                }
            }

            foreach (var cont in _contracts)
            {
                ContractDtos.Add(new ContractDto
                {
                    NumberContract = cont.NumberContract,
                    Client = cont.Client,
                    Employees = cont.Employees,
                    TypeJob = cont.TypeJob,
                    QuantityJob = cont.QuantityJob,
                    Price = cont.Price
                });
            }

            return default;
        }

        public IEnumerable<Contract> DeleteObjects(int id)
        {
            for (int i = 0; i < _contracts.Count; i++)
            {
                if (id == _contracts[i].Id)
                {
                    _contracts.RemoveAt(i);
                    ContractDtos.RemoveAt(i);
                }
            }
            return default;
        }
    }
}
