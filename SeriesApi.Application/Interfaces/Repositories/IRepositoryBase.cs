namespace SeriesApi.Application.Interfaces.Repositories;

public interface IRepositoryBase<T>
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T episode);
    Task Delete(Guid id);
    Task SaveChangesAsync();
}