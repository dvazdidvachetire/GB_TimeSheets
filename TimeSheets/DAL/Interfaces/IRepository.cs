using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task CreateObjects(T obj);
        Task<T> GetObject(int id);
        Task UpdateObject(int id, T obj);
        Task DeleteObject(int id);
    }
}
