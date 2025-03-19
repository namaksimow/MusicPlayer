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

    public async Task AddAsync(Song entity)
    {
        _context.Songs.Add(entity);
        await _context.SaveChangesAsync();
    }
}