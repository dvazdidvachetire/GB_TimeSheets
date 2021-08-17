using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> CreateObjects(T obj);
        Task<IEnumerable<T>> GetObjects();
        Task<IEnumerable<T>> UpdateObjects(int id, T obj);
        Task<IEnumerable<T>> DeleteObjects(int id);
    }
}
