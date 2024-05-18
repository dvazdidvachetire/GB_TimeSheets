namespace TimeSheets.DAL.Interfaces;

public interface IRepository<T>
{
    Task<bool> CreateObjectsAsync(T obj, CancellationToken cancel = default);
    Task<IReadOnlyList<T>> GetObjectsAsync(CancellationToken cancel = default);
    Task<bool> UpdateObjectsAsync<Id>(Id id, T obj, CancellationToken cancel = default);
    Task<bool> DeleteObjectsAsync(int id, CancellationToken cancel = default);
}
