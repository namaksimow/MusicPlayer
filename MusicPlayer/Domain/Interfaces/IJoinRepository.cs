namespace MusicPlayer.Domain.Interfaces;

public interface IJoinRepository
{
    public List<int> GetSongDurationBySongTitle(List<int> songs);
    
    public List<string> GetGenresByUserId(int userId);
    
    public List<string> GetPerformersByUserId(int userId);
    
    public int GetCountSameSong(int songId);
    
    public bool IsUserHaveSongByPerformer(int userId, string songsTitle, string performerName);
    
    public List<int> GetSongsIdByGenrePerformerListDurationFromAndTo(
        int selectionId, int minDuration,
        int maxDuration, List<string> genres,
        List<string> performers);
    
    public List<int> GetSongsIdByGenrePerformerListDurationFrom(
        int selectionId, int minDuration,
        List<string> genres, List<string> performers);
    
    public List<int> GetSongsIdByGenrePerformerListDurationTo(
        int selectionId, int maxDuration,
        List<string> genres, List<string> performers);
    
    public List<int> GetSongsIdByGenrePerformerList(
        int selectionId, List<string> genres,
        List<string> performers);
    
    public List<int> GetSongsIdByGenreListDurationFromAndTo(int selectionId, int minDuration,
        int maxDuration, List<string> genres);
    
    public List<int> GetSongsIdByGenreListDurationFrom(int selectionId, int minDuration,
        List<string> genres);
    
    public List<int> GetSongsIdByGenreListDurationTo(int selectionId, int maxDuration,
        List<string> genres);
    
    public List<int> GetSongsIdByGenreList(int selectionId, List<string> genres);
    
    public List<int> GetSongsIdByPerformerListDurationFromAndTo(int selectionId, int minDuration,
        int maxDuration, List<string> performers);
    
    public List<int> GetSongsIdByPerformerListDurationFrom(int selectionId, int minDuration, 
        List<string> performers);
    
    public List<int> GetSongsIdByPerformerListDurationTo(int selectionId, int maxDuration, 
        List<string> performers);
    
    public List<int> GetSongsIdByPerformerList(int selectionId, List<string> performers);
    
    public List<int> GetSongsIdByDurationFromAndTo(int selectionId, int minDuration, int maxDuration);
    
    public List<int> GetSongsIdByDurationFrom(int selectionId, int minDuration);
    
    public List<int> GetSongsIdByDurationTo(int selectionId, int maxDuration);
    
    public List<string> GetSongsByGenrePerformerListDurationToAndFrom(
        int selectionId, int minDuration,
        int maxDuration, List<string> genres,
        List<string> performers);
    
    public List<string> GetSongsByGenrePerformerListDurationFrom(int selectionId, int minDuration, List<string> genres,
        List<string> performers);
    
    public List<string> GetSongsByGenrePerformerListDurationTo(int selectionId, int maxDuration, List<string> genres,
        List<string> performers);
    
    public List<string> GetSongsByGenrePerformerList(int selectionId, List<string> genres, List<string> performers);
    
    public List<string> GetSongsByGenreListDurationToAndFrom(int selectionId, int minDuration, int maxDuration,
        List<string> genres);
    
    public List<string> GetSongsByGenreListDurationFrom(int selectionId, int minDuration, List<string> genres);
    
    public List<string> GetSongsByGenreListDurationTo(int selectionId, int maxDuration, List<string> genres);
    
    public List<string> GetSongsByGenreList(int selectionId, List<string> genres);
    
    public List<string> GetSongsByPerformerListDurationToAndFrom(int selectionId, int minDuration, int maxDuration,
        List<string> performers);
    
    public List<string> GetSongsByPerformerListDurationFrom(int selectionId, int minDuration, List<string> performers);
    
    public List<string> GetSongsByPerformerListDurationTo(int selectionId, int maxDuration, List<string> performers);
    
    public List<string> GetSongsByPerformerList(int selectionId, List<string> performers);
    
    public List<string> GetSongsByDurationToAndFrom(int selectionId, int minDuration, int maxDuration);
    
    public List<string> GetSongsByDurationFrom(int selectionId, int minDuration);
    
    public List<string> GetSongsByDurationTo(int selectionId, int maxDuration);
    
    public List<string> GetSongsByDurationDescending(int selectionId);
    
    public List<string> GetSongsByDurationAscending(int selectionId);
    
    public List<string> GetSongsByPerformerDescending(int selectionId);
    
    public List<string> GetSongsByPerformerAscending(int selectionId);
    
    List<string> GetSongsBySelectionId(int selectionId, int userId);
}