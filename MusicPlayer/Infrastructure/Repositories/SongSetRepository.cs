using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class SongSetRepository :  ISongSetRepository
{
    private readonly ApplicationContext _context;

    public SongSetRepository(ApplicationContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Удалить песни зи плейлиста
    /// </summary>
    /// <param name="selectionId">Айди плейлиста</param>
    public void DeleteSongSet(int selectionId)
    {
        var songSet = _context.SongSets.Where(s => s.SelectionId == selectionId).ToList();
        foreach (var set in songSet)
        {
            _context.SongSets.Remove(set);
        }
        _context.SaveChanges();
    }

    public void AddSongSet(int selectionId, int songId)
    {
        SongSet songSet = new SongSet(selectionId, songId);
        _context.SongSets.Add(songSet);
        _context.SaveChanges();
    }

    public void AddSongToDownloadedPlaylist(int songId, int selectionId = 2)
    {
        SongSet songSet = new SongSet(selectionId, songId);
        _context.SongSets.Add(songSet);
        _context.SaveChanges();
    }
}