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
        private readonly SortedDictionary<int, Contract> _contracts = new SortedDictionary<int, Contract>();
        private readonly IEmployeesRepository _repositoryEmployees;
        private readonly IClientsRepository _repositoryClients;

        public ContractsRepository(IEmployeesRepository repositoryEmployees, IClientsRepository repositoryClients)
        {
            _repositoryEmployees = repositoryEmployees;
            _repositoryClients = repositoryClients;
        }

        public SortedDictionary<int, Contract> AddObjects(Contract contract, int id)
        {
            try
            {
                var client = _repositoryClients.GetAllObjects()[contract.IdClient];

                var employees = new SortedDictionary<int, Employee>();

                foreach (var idEmpl in contract.IdEmployee)
                {
                    employees.Add(idEmpl, _repositoryEmployees.GetAllObjects()[idEmpl]);
                }

                _contracts.Add(id, new Contract
                {
                    NumberContract = contract.NumberContract,
                    Client = client,
                    Employees = employees,
                    TypeJob = contract.TypeJob,
                    QuantityJob = contract.QuantityJob,
                    Price = contract.Price,
                });
            }
            catch (Exception e)
            {
                Debug.Write(e);
            }

            return _contracts;
        }

        public SortedDictionary<int, Contract> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Contract> ChangeObjects(Contract obj, int parameter)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Contract> DeleteObjects(int parameter)
        {
            throw new NotImplementedException();
        }
    }
}
