namespace MusicPlayer.Domain.Interfaces;

public interface ISongService
{
    Task<(int, int)> AddSong(string filePath, int userId);

    public string GetSongName(string fileName);

    public void DeleteSong(string fileName, string playlist, int userId);
    
    public string GetLyrics(string fileName);

    public void SetCurrentSong(string song);
    
    public string GetSongTitle(string fileName);

    public (string artist, string title) ParseFileName(string fileName);
}