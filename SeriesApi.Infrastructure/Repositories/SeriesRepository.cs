using Microsoft.EntityFrameworkCore;
using SeriesApi.Application.Interfaces.Repositories;
using SeriesApi.Domain.Entities;
using SeriesApi.Infrastructure.Data;

namespace SeriesApi.Infrastructure.Repositories;

public class SeriesRepository(ApplicationDbContext _context) : ISeriesRepository
{
    public async Task<IEnumerable<Series>> GetAllAsync()
    {
        return await _context.Series
            .Include(s => s.Seasons)
                .ThenInclude(se => se.Episodes)
            .ToListAsync();
    }

    public async Task<Series?> GetByIdAsync(Guid id)
    {
        return await _context.Series
            .Include(s => s.Seasons)
                .ThenInclude(se => se.Episodes)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Series series)
    {
        await _context.Series.AddAsync(series);
    }

    public async Task Delete(Guid id)
    {
        var series = await GetByIdAsync(id);

        if (series == null)
        {
            return;
        }

        _context.Series.Remove(series);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
