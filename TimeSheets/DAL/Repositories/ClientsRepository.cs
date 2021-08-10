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
        private SortedDictionary<int, Client> _clients = new SortedDictionary<int, Client>();

        public SortedDictionary<int, Client> AddObjects(Client client, int id)
        {
            _clients.Add(id, client);
            return _clients;
        }

        public SortedDictionary<int, Client> GetAllObjects()
        {
            return _clients;
        }

        public SortedDictionary<int, Client> ChangeObjects(Client client, int id)
        {
            _clients[id] = client;
            return _clients;
        }

        public SortedDictionary<int, Client> DeleteObjects(int id)
        {
            _clients.Remove(id);
            return _clients;
        }
    }
}
