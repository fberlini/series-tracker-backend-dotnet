using SeriesApi.Domain.Entities;

namespace SeriesApi.Application.Interfaces.Services;

public interface ISeriesService
{
    Task<IEnumerable<Series>> GetAllAsync();
    Task<Series?> GetByIdAsync(Guid id);
    Task<Series> CreateAsync(Series series);
    Task<bool> UpdateAsync(Guid id, string newTitle);
    Task<bool> DeleteAsync(Guid id);
}
