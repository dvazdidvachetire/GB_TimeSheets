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

namespace TimeSheets.DAL.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly DbContextRepository _context;

        public TimeSheetRepository(DbContextRepository context)
        {
            _context = context;
        }

        public async Task<bool> CreateObjects(TimeSheet timeSheet)
        {
            try
            {
                await _context.AddAsync(timeSheet);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<IReadOnlyList<TimeSheet>> GetObjects()
        {
            try
            {
                return await _context.TimeSheets.Where(t => t.IsDeleted == false).ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return default;
            }
        }

        public Task<bool> UpdateObjects(int id, TimeSheet timeSheet)
        {
            return null;
        }

        public Task<bool> DeleteObjects(int id)
        {
            return null;
        }
    }
}
