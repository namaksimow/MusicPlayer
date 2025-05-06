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

    public List<string> GetSongsByGenrePerformerListDurationToAndFrom(int selectionId, int minDuration, int maxDuration,
        List<string> genres, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration && song.Duration <= maxDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenrePerformerListDurationFrom(int selectionId, int minDuration, List<string> genres, 
        List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenrePerformerListDurationTo(int selectionId, int maxDuration, List<string> genres, 
        List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration <= maxDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenrePerformerList(int selectionId, List<string> genres, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenreListDurationToAndFrom(int selectionId, int minDuration, int maxDuration, List<string> genres)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration && song.Duration <= maxDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenreListDurationFrom(int selectionId, int minDuration, List<string> genres)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenreListDurationTo(int selectionId, int maxDuration, List<string> genres)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration <= maxDuration
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByGenreList(int selectionId, List<string> genres)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join genreSet in _context.GenreSets on song.Id equals genreSet.SongId
            join genre in _context.Genres on genreSet.GenreId equals genre.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where genres.Contains(genre.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByPerformerListDurationToAndFrom(int selectionId, int minDuration, int maxDuration,
        List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration && song.Duration <= maxDuration
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByPerformerListDurationFrom(int selectionId, int minDuration, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByPerformerListDurationTo(int selectionId, int maxDuration, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration <= maxDuration
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByPerformerList(int selectionId, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets on song.Id equals performerSet.SongId
            join performer in _context.Performers on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)  
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();

        return result;
    }
    
    public List<string> GetSongsByDurationToAndFrom(int selectionId, int minDuration, int maxDuration)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration && song.Duration <= maxDuration
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
    
    public List<string> GetSongsByDurationFrom(int selectionId, int minDuration)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration
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
    
    public List<string> GetSongsByDurationTo(int selectionId, int maxDuration)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration <= maxDuration
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
    
    public List<string> GetSongsByDurationDescending(int selectionId)
    {        
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            orderby song.Duration descending
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
    
    public List<string> GetSongsByDurationAscending(int selectionId)
    {        
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            orderby song.Duration  
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
    
    public List<string> GetSongsByPerformerDescending(int selectionId)
    {        
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            orderby performer.Name descending 
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
    
    public List<string> GetSongsByPerformerAscending(int selectionId)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
                orderby performer.Name
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
    
    /// <summary>
    /// Получение всех песен из какого-либо плейлиста
    /// </summary>
    /// <param name="selectionId">Айди плейлиста</param>
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