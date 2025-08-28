using SeriesApi.Domain.Entities;

namespace SeriesApi.Application.Interfaces;

public interface ISeriesRepository
{
    Task<IEnumerable<Series>> GetAllAsync();
    Task<Series?> GetByIdAsync(Guid id);
    Task AddAsync(Series series);
    void Delete(Series series);
    Task SaveChangesAsync();
}
