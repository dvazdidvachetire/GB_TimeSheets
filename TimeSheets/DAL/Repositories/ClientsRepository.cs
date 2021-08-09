using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        public Task AddObjects(Client objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public Task<Client> ChangeObjects(Client objects)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> DeleteObjects(string name)
        {
            throw new NotImplementedException();
        }
    }
}
