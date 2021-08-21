using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;
using TimeSheets.DTO;

namespace TimeSheets.DAL.Repositories
{
    internal sealed class ContractsRepository : IContractsRepository
    {
        private readonly DbContextRepository _context;

        public ContractsRepository(DbContextRepository context)
        {
            _context = context;
        }

        private IList<Contract> _contracts = new List<Contract>();
        public IList<ContractDto> ContractsDto { get; set; } = new List<ContractDto>();

        public async Task<IEnumerable<Contract>> CreateObjects(Contract contract)
        {
            try
            {
                await _context.AddAsync(contract);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.Write($"Ошибка! Ошибка! {e.Message}");
            }

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
