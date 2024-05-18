using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    public sealed class InvoicesRepository : IInvoicesRepository
    {
        private readonly DbContextRepository _context;

        public InvoicesRepository(DbContextRepository context)
        {
            _context = context;
        }

        public Task<bool> CreateObjectsAsync(Invoice obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Invoice>> GetObjectsAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectsAsync<Id>(Id id, Invoice obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
