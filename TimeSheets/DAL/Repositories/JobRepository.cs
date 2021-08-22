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
    internal sealed class JobRepository : IJobRepository
    {
        public IList<JobDto> JobsDtos { get; set; } = new List<JobDto>();
        private readonly DbContextRepository _context;

        public JobRepository(DbContextRepository context)
        {
            _context = context;
        }

        public async Task<bool> CreateObjects(Job job)
        {
            try
            {
                await _context.AddAsync(job);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Debug.Write($"Error! Error! {e.Message}");
                return false;
            }

            return true;
        }

        public async Task<IReadOnlyList<Job>> GetObjects()
        {
            try
            {
                return await _context.Jobs.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public Task<bool> UpdateObjects(int id, Job job)
        {
            return null;
        }

        public Task<bool> DeleteObjects(int id)
        {
            return null;
        }
    }
}
