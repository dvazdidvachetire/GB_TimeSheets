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
        public IList<ContractDto> ContractsDto { get; set; } = new List<ContractDto>();

        public async Task<IEnumerable<Contract>> CreateObjects(Contract contract)
        {
            await Task.Run(() => _contracts.Add(contract));
            return _contracts;
        }

        public async Task<IEnumerable<Contract>> GetObjects()
        {
            return await Task.Run(() => _contracts);
        }

        public Task<IEnumerable<Contract>> UpdateObjects(int id, Contract contract)
        {
            return null;
        }

        public Task<IEnumerable<Contract>> DeleteObjects(int id)
        {
            return null;
        }
    }
}
