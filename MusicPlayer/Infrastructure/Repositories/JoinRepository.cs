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

    public List<int> GetSongDurationBySongTitle(List<int> songs)
    {
        var result = (
            from song in _context.Songs
            where songs.Contains(song.Id)
            select song.Duration
        ).ToList();
        
        return result;
    }
    
    public List<string> GetGenresByUserId(int userId)
    {
        var result = (
            from users in _context.Users
            join userSet in  _context.UserSets on users.Id equals userSet.UserId
            join songs in _context.Songs on userSet.SongId equals songs.Id
            join genreSet in _context.GenreSets on songs.Id equals genreSet.SongId
            join genres in _context.Genres on genreSet.GenreId equals genres.Id
            where users.Id == userId
            select new
            {
                genres.Name
            }
        ).Select(p => p.Name).ToList();

        return result;
    }
    
    public List<string> GetPerformersByUserId(int userId)
    {
        var result = (
            from users in _context.Users
            join userSet in  _context.UserSets on users.Id equals userSet.UserId
            join songs in _context.Songs on userSet.SongId equals songs.Id
            join performerSet in _context.PerformerSets on songs.Id equals performerSet.SongId
            join performers in _context.Performers on performerSet.PerformerId equals performers.Id
            where users.Id == userId
            select new
            {
                performers.Name
            }
        ).Select(p => p.Name).ToList();

        return result;
    }
    
    public int GetCountSameSong(int songId)
    {
        var result = (
            from songSet in _context.SongSets
            join performerSet in _context.PerformerSets on  songSet.SongId equals performerSet.SongId
            where songSet.SongId == songId
            select new
            {
                performerSet.PerformerId,
                performerSet.SongId,
            }
            ).Select(ps => ps.SongId).ToList();
        
        return result.Count;
    }
    
    public bool IsUserHaveSongByPerformer(int userId, string songsTitle, string performerName)
    {
        var result = (
            from userSets in _context.UserSets
            join users in _context.Users on userSets.UserId equals users.Id
            join songs in _context.Songs on userSets.SongId equals songs.Id
            join performerSets in _context.PerformerSets on songs.Id equals performerSets.SongId
            join performers in _context.Performers on performerSets.PerformerId equals performers.Id
            where users.Id == userId && songs.Title == songsTitle && performers.Name == performerName
            select new
            {
                users.Id,
                songs.Title,
                performers.Name,
            }
        ).Select(user => user.Id).ToList();

        if (result.Count == 0)
        {
            return false;
        }

        return true;
    }
    
    public List<int> GetSongsIdByGenrePerformerListDurationFromAndTo(
        int selectionId, int minDuration, 
        int maxDuration, List<string> genres,
        List<string> performers)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenrePerformerListDurationFrom(
        int selectionId, int minDuration, 
        List<string> genres, List<string> performers)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenrePerformerListDurationTo(
        int selectionId, int maxDuration, 
        List<string> genres, List<string> performers)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenrePerformerList(
        int selectionId, List<string> genres,
        List<string> performers)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenreListDurationFromAndTo(int selectionId, int minDuration,
        int maxDuration, List<string> genres)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenreListDurationFrom(int selectionId, int minDuration, List<string> genres)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenreListDurationTo(int selectionId, int maxDuration, List<string> genres)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByGenreList(int selectionId, List<string> genres)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByPerformerListDurationFromAndTo(int selectionId, int minDuration,
        int maxDuration, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs on songSet.SongId equals song.Id
            where song.Duration >= minDuration && song.Duration <= maxDuration
            join performerSet in _context.PerformerSets on song.Id equals performerSet.SongId
            join performer in _context.Performers on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)  
            select new
            {
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByPerformerListDurationFrom(int selectionId, int minDuration, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs on songSet.SongId equals song.Id
            where song.Duration >= minDuration
            join performerSet in _context.PerformerSets on song.Id equals performerSet.SongId
            join performer in _context.Performers on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)  
            select new
            {
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByPerformerListDurationTo(int selectionId, int maxDuration, List<string> performers)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs on songSet.SongId equals song.Id
            where song.Duration <= maxDuration
            join performerSet in _context.PerformerSets on song.Id equals performerSet.SongId
            join performer in _context.Performers on performerSet.PerformerId equals performer.Id
            where performers.Contains(performer.Name)  
            select new
            {
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByPerformerList(int selectionId, List<string> performers)
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
                song.Id
            }
        ).Select(song => song.Id).ToList();

        return result;
    }
    
    public List<int> GetSongsIdByDurationFromAndTo(int selectionId, int minDuration, int maxDuration)
    {
        var result = (
            from songSet in _context.SongSets
            where songSet.SelectionId == selectionId
            join song in _context.Songs
                on songSet.SongId equals song.Id
            where song.Duration >= minDuration &&  song.Duration <= maxDuration
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            select new
            {
                song.Id,
            }
        ).Select(song => song.Id).ToList();
        
        return result;
    }
    
    public List<int> GetSongsIdByDurationFrom(int selectionId, int minDuration)
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
                song.Id,
            }
        ).Select(song => song.Id).ToList();
        
        return result;
    }
    
    public List<int> GetSongsIdByDurationTo(int selectionId, int maxDuration)
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
                song.Id,
            }
        ).Select(song => song.Id).ToList();
        
        return result;
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
    /// <param name="userId"></param>
    /// <returns></returns>
    public List<string> GetSongsBySelectionId(int selectionId, int userId)
    {
        // используем join, чтобы не обращаться к 3 разным таблицам, а обратиться к одной после объединения
        var result = (
            from songSet in _context.SongSets
            join song in _context.Songs
                on songSet.SongId equals song.Id
            join performerSet in _context.PerformerSets
                on songSet.SongId equals performerSet.SongId
            join performer in _context.Performers
                on performerSet.PerformerId equals performer.Id
            join selection in _context.Selections on songSet.SelectionId equals selection.Id
            join user in _context.Users on selection.UserId equals user.Id
            where songSet.SelectionId == selectionId && user.Id == userId
            select new
            {
                song.Title,
                performer.Name
            }
        ).Select(song => song.Name + "-" + song.Title + ".mp3").ToList();
        
        return result;
    }
}