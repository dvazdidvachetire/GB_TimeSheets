using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    public sealed class CustomersRepository : ICustomersRepository
    {
        private readonly DbContextRepository _context;

        public CustomersRepository(DbContextRepository context)
        {
            _context = context;
        }

        public Task<bool> CreateObjectsAsync(Customer obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Customer>> GetObjectsAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectsAsync<Id>(Id id, Customer obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
