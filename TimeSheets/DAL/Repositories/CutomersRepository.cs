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
    public class CutomersRepository : ICustomersRepository
    {
        private IList<Customer> _clients = new List<Customer>();

        public IEnumerable<Customer> AddObjects(Customer client)
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

        public IEnumerable<Customer> GetAllObjects()
        {
            return _clients;
        }

        public IEnumerable<Customer> ChangeObjects(Customer client)
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

        public IEnumerable<Customer> DeleteObjects(int id)
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
