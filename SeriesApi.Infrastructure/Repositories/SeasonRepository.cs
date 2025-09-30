using Microsoft.EntityFrameworkCore;
using SeriesApi.Application.Interfaces.Repositories;
using SeriesApi.Domain.Entities;
using SeriesApi.Infrastructure.Data;

namespace SeriesApi.Infrastructure.Repositories;

public class SeasonRepository(ApplicationDbContext _context) : ISeasonRepository
{
    public async Task<IEnumerable<Season>> GetAllAsync()
    {
        return await _context.Seasons
            .Include(s => s.Series)
            .ToListAsync();
    }

    public async Task<Season?> GetByIdAsync(Guid id)
    {
        return await _context.Seasons
            .Include(s => s.Series)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Season season)
    {
        await _context.Seasons.AddAsync(season);
    }

    public async Task Delete(Guid id)
    {
        var season = await GetByIdAsync(id);

        if (season == null)
        {
            return;
        }

        _context.Seasons.Remove(season);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
