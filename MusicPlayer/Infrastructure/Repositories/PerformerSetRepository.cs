using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class PerformerSetRepository : IPerformerSetRepository
{
    private readonly ApplicationContext _context;

    public PerformerSetRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Add(int performerId, int songId)
    {
        _context.PerformerSets.Add(new PerformerSet(performerId, songId));
        await _context.SaveChangesAsync();
    }
}