using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task<bool> CreateObjects(T obj);
        Task<IReadOnlyList<T>> GetObjects();
        Task<bool> UpdateObjects(int id, T obj);
        Task<bool> DeleteObjects(int id);
    }
}
