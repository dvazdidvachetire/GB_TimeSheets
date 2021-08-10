using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IRepository<T, in TP>
    {
        SortedDictionary<int, T> AddObjects(T objects, TP parameter);
        SortedDictionary<int, T> GetAllObjects();
        SortedDictionary<int, T> ChangeObjects(T obj, TP parameter);
        SortedDictionary<int, T> DeleteObjects(TP parameter);
    }
}
