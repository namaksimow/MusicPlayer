using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class JoinRepository : IJoinRepository
{
    private readonly ApplicationContext _context;

    public JoinRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Получение всех песен из какого-либо плйелиста
    /// </summary>
    /// <param name="selectionId"></param>
    /// <returns></returns>
    public List<string> GetSongsBySelectionId(int selectionId)
    {
        // используем join, чтобы не обращаться к 3 разным таблицам, а обратиться к одной после объединения
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
}