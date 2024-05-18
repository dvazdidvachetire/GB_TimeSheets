using TimeSheets.DAL.Interfaces;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Repositories.Context;

namespace TimeSheets.DAL.Repositories
{
    public sealed class EmployeesRepository : IEmployeesRepository
    {
        private readonly DbContextRepository _context;

        public EmployeesRepository(DbContextRepository context)
        {
            _context = context;
        }

        public Task<bool> CreateObjectsAsync(Employee obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Employee>> GetObjectsAsync(CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateObjectsAsync<Id>(Id id, Employee obj, CancellationToken cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
