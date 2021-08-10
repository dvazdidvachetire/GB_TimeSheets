using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T, in TP>
    {
        IEnumerable<T> AddObjects(T objects);
        IEnumerable<T> GetAllObjects();
        IEnumerable<T> ChangeObjects(T obj);
        IEnumerable<T> DeleteObjects(TP parameter);
    }
}
