using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeSheets.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> CreateObjects(T obj);
        Task<IEnumerable<T>> GetObjects();
        Task<IEnumerable<T>> UpdateObjects(int id, T obj);
        Task<IEnumerable<T>> DeleteObjects(int id);
    }
}
