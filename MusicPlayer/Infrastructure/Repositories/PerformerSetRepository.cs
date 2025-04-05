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

    /// <summary>
    /// Удалить песню у исполнителя
    /// </summary>
    /// <param name="songId">Айди песни для удаления</param>
    public void DeleteSongFromPerformer(int songId)
    {
        var performerSet = _context.PerformerSets.FirstOrDefault(ps => ps.SongId == songId);
        _context.PerformerSets.Remove(performerSet!);
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Добавить песню к исполнителю
    /// </summary>
    /// <param name="performerId"></param>
    /// <param name="songId"></param>
    public async Task Add(int performerId, int songId)
    {
        _context.PerformerSets.Add(new PerformerSet(performerId, songId));
        await _context.SaveChangesAsync();
    }
}