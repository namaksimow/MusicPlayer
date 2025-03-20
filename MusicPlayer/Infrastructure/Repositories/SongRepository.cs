using MusicPlayer.DataBase.Models;
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

    public void Add(Song entity)
    {
        _context.Songs.Add(entity);
        _context.SaveChangesAsync();
    }

    public bool Contains(string title)
    {
        return _context.Songs.Any(s => s.Title == title);
    }
}