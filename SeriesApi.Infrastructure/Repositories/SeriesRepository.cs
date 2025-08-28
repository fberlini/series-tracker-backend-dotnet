using Microsoft.EntityFrameworkCore;
using SeriesApi.Application.Interfaces;
using SeriesApi.Domain.Entities;
using SeriesApi.Infrastructure.Data;

namespace SeriesApi.Infrastructure.Repositories;

public class SeriesRepository : ISeriesRepository
{
    private readonly ApplicationDbContext _context;

    public SeriesRepository(ApplicationDbContext context)
    {
        _context = context;
    }

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

    public void Delete(Series series)
    {
        _context.Series.Remove(series);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
