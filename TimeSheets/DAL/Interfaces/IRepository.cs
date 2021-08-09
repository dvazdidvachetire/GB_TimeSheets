using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T>
    {
        Task AddObjects(T objects);
        Task<List<T>> GetAllObjects();
        Task<T> ChangeObjects(T objects);
        Task<List<T>> DeleteObjects(string name);
    }
}
