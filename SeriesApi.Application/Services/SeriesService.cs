using SeriesApi.Application.Interfaces;
using SeriesApi.Domain.Entities;

namespace SeriesApi.Application.Services;

public class SeriesService(ISeriesRepository repository) : ISeriesService
{
    private readonly ISeriesRepository _repository = repository;

    public async Task<IEnumerable<Series>> GetAllAsync() =>
        await _repository.GetAllAsync();

    public async Task<Series?> GetByIdAsync(Guid id) =>
        await _repository.GetByIdAsync(id);

    public async Task<Series> CreateAsync(Series series)
    {
        await _repository.AddAsync(series);
        await _repository.SaveChangesAsync();
        return series;
    }

    public async Task<bool> UpdateAsync(Guid id, string newTitle)
    {
        var series = await _repository.GetByIdAsync(id);
        if (series == null) return false;

        series.Title = newTitle;
        await _repository.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var series = await _repository.GetByIdAsync(id);
        if (series == null) return false;

        _repository.Delete(series);
        await _repository.SaveChangesAsync();
        return true;
    }
}
