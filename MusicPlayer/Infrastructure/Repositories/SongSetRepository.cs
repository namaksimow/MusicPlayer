using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class SongSetRepository :  ISongSetRepository
{
    private readonly ApplicationContext _context;
    private readonly ISelectionRepository _selectionRepository;
    
    public SongSetRepository(ApplicationContext context, ISelectionRepository selectionRepository)
    {
        _context = context;
        _selectionRepository = selectionRepository;
    }

    public void DeleteSongSetBySongIdSelectionId(int songId, int selectionId)
    {
        SongSet songSet = _context.SongSets.FirstOrDefault(s => s.SongId == songId && s.SelectionId == selectionId)!;
        _context.SongSets.Remove(songSet);
        _context.SaveChanges();
    }
    
    public void DeleteSongSetBySongId(int songId)
    {
        var songSet = _context.SongSets.Where(s => s.SongId == songId).ToList();
        foreach (var set in songSet)
        {
            _context.SongSets.Remove(set);
        }
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Удалить песни из плейлиста
    /// </summary>
    /// <param name="selectionId">Айди плейлиста</param>
    public void DeleteSongSetBySelectionId(int selectionId)
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

    public void AddSongToDownloadedPlaylist(int songId, int songDuration ,int selectionId = 2)
    {
        SongSet songSet = new SongSet(selectionId, songId);
        _selectionRepository.ChangeSelectionDuration(selectionId, songDuration);
        _context.SongSets.Add(songSet);
        _context.SaveChanges();
    }
}