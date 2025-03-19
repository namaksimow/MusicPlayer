namespace MusicPlayer.Domain.Interfaces;

public interface ILyricsService
{
    Task<string?> GetLyrics(string track, string artist);
}