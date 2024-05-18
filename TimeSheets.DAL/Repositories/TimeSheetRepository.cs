using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    public class TimeSheetRepository : ITimeSheetRepository
    {
        private readonly DbContextRepository _context;

        public TimeSheetRepository(DbContextRepository context)
        {
            _context = context;
        }

        public Task<bool> CreateObjectsAsync(TimeSheet obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TimeSheet>> GetObjectsAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectsAsync<Id>(Id id, TimeSheet obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
