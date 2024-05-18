using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    public sealed class ContractsRepository : IContractsRepository
    {
        private readonly DbContextRepository _context;

        public ContractsRepository(DbContextRepository context)
        {
            _context = context;
        }

        public Task<bool> CreateObjectsAsync(Contract obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Contract>> GetObjectsAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectsAsync<Id>(Id id, Contract obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
