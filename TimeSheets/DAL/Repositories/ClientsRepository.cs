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
        public SortedDictionary<int, Client> AddObjects(Client objects, int parameter)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Client> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Client> ChangeObjects(Client obj, int parameter)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Client> DeleteObjects(int parameter)
        {
            throw new NotImplementedException();
        }
    }
}
