using MusicPlayer.Domain.Models;
using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class SongRepository : ISongRepository
{
    private readonly ApplicationContext _context;

    public SongRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Add(Song entity)
    {
        _context.Songs.Add(entity);
        await _context.SaveChangesAsync();
    }

    public bool Contains(string title)
    {
        return _context.Songs.Any(s => s.UpperTitle == title.ToUpper());
    }
}