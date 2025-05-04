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

    public int GetSongDuration(string title)
    {
        var song = _context.Songs.FirstOrDefault(s => s.Title == title);
        return song!.Duration;
    }
    
    /// <summary>
    /// Удалить песню
    /// </summary>
    /// <param name="songId">Айди песни для удаления</param>
    public void Delete(int songId)
    {
        var song = _context.Songs.Find(songId);
        _context.Songs.Remove(song);
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Найти песню
    /// </summary>
    /// <param name="title">Название песни для поиска</param>
    /// <returns></returns>
    public Song Find(string title)
    {
        return _context.Songs.FirstOrDefault(s => s.UpperTitle == title.ToUpper())!;
    }
    
    /// <summary>
    /// Добавить песню
    /// </summary>
    /// <param name="entity">Объект с данными песни</param>
    public async Task Add(Song entity)
    {
        _context.Songs.Add(entity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Содержит ли песню
    /// </summary>
    /// <param name="title">Название песни для поиска</param>
    /// <returns></returns>
    public bool Contains(string title)
    {
        return _context.Songs.Any(s => s.UpperTitle == title.ToUpper());
    }

    public int GetSongId(string title)
    {
        var song = _context.Songs.FirstOrDefault(s => s.Title == title);
        return song!.Id;
    }
}