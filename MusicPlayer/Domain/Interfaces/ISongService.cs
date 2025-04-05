namespace MusicPlayer.Domain.Interfaces;

public interface ISongService
{
    Task AddSong(string filePath);

    public string GetSongName(string fileName);
    
    public void DeleteSong(string fileName);
}