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
        public SortedDictionary<int, Contract> AddObjects(Contract objects, int parameter)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Contract> GetAllObjects()
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Contract> ChangeObjects(Contract obj, int parameter)
        {
            throw new NotImplementedException();
        }

        public SortedDictionary<int, Contract> DeleteObjects(int parameter)
        {
            throw new NotImplementedException();
        }
    }
}
