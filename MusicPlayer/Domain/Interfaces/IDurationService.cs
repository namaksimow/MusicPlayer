namespace MusicPlayer.Domain.Interfaces;

public interface IDurationService
{
    int GetDuration(string filePath);
}