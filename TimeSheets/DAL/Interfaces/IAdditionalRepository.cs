using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.DAL.Interfaces
{
    public interface IAdditionalRepository<T, TD>
    {
        Task<IEnumerable<T>> CreateObjects(T obj);
        Task<IEnumerable<T>> GetObjects(int id);
        Task<IEnumerable<T>> GetAllObjects();
        Task<IEnumerable<TD>> GetChangesObjects(int id);
        Task<IEnumerable<TD>> GetAllChangesObjects();
    }
}
