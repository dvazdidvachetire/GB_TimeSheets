using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    public class ContractsRepository : IContractsRepository
    {
        public Task AddObjects(Contract objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contract>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<Contract> ChangeObjects(Contract objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contract>> DeleteObjects(string name)
        {
            throw new NotImplementedException();
        }
    }
}
