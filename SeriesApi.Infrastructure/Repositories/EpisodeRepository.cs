using Microsoft.EntityFrameworkCore;
using SeriesApi.Application.Interfaces.Repositories;
using SeriesApi.Domain.Entities;
using SeriesApi.Infrastructure.Data;

namespace SeriesApi.Infrastructure.Repositories;

public class EpisodeRepository(ApplicationDbContext _context) : IEpisodeRepository
{
    public async Task<IEnumerable<Episode>> GetAllAsync()
    {
        return await _context.Episodes.ToListAsync();
    }

    public async Task<Episode?> GetByIdAsync(Guid id)
    {
        return await _context.Episodes.FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Episode episode)
    {
        await _context.Episodes.AddAsync(episode);
    }

    public async Task Delete(Guid id)
    {
        var episode = await GetByIdAsync(id);

        if (episode == null)
        {
            return;
        }

        _context.Episodes.Remove(episode);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
