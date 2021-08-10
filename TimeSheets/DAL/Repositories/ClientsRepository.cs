using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;

namespace TimeSheets.DAL.Repositories
{
    public class ClientsRepository : IClientsRepository
    {
        private IList<Client> _clients = new List<Client>();

        public IEnumerable<Client> AddObjects(Client client)
        {
            try
            {
                _clients.Add(client);
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            
            return _clients;
        }

        public IEnumerable<Client> GetAllObjects()
        {
            return _clients;
        }

        public IEnumerable<Client> ChangeObjects(Client client)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (_clients[i].Id == client.Id)
                {
                    _clients[i] = client;
                }
            }

            return _clients;
        }

        public IEnumerable<Client> DeleteObjects(int id)
        {
            for (int i = 0; i < _clients.Count; i++)
            {
                if (id == _clients[i].Id)
                {
                    _clients.RemoveAt(i);
                }
            }

            return _clients;
        }
    }
}
