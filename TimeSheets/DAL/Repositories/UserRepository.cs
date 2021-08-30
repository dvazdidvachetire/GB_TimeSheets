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
    public sealed class UserRepository : IUserRepository
    {
        private readonly DbContextRepository _context;

        public UserRepository(DbContextRepository context)
        {
            _context = context;
        }

        public async Task<bool> CreateObjects(User user)
        {
            try
            {
                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
        }

        public async Task<IReadOnlyList<User>> GetObjects()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return null;
            }
        }

        public Task<bool> UpdateObjects(int id, User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjects(int id)
        {
            throw new NotImplementedException();
        }
    }
}
