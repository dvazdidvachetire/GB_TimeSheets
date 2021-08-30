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
        
        public async Task<bool> CreateObjects(Contract contract)
        {
            try
            {
                await _context.AddAsync(contract);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write($"Ошибка! Ошибка! {e.Message}");
                return false;
            }
        }

        public async Task<IReadOnlyList<Contract>> GetObjects()
        {
            try
            {
                return await _context.Contracts.Where(c => c.IsDelete == false).ToListAsync();
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
