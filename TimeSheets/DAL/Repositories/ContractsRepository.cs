using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> CreateObjects(Contract contract)
        {
            try
            {
                await _context.AddAsync(contract);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.Write($"Ошибка! Ошибка! {e.Message}");
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyList<Contract>> GetObjects()
        {
            try
            {
                return await _context.Contracts.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public Task<bool> UpdateObjects(int id, Contract contract)
        {
            return null;
        }

        public Task<bool> DeleteObjects(int id)
        {
            return null;
        }
    }
}
