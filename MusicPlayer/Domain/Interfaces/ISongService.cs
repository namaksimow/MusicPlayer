namespace MusicPlayer.Domain.Interfaces;

public interface ISongService
{
    Task AddSong(string filePath);
}