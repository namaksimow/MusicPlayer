namespace MusicPlayer.Domain.Interfaces;

public interface IJoinRepository
{
    public List<string> GetSongsByGenrePerformerListDurationToAndFrom(int selectionId, int minDuration, int maxDuration,
        List<string> genres, List<string> performers);
    
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
    
    List<string> GetSongsBySelectionId(int selectionId);
}