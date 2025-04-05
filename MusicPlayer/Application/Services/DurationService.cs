using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.Application.Services;

public class DurationService : IDurationService
{
    /// <summary>
    /// Получить длительность файла
    /// </summary>
    /// <param name="filePath">Путь до файла</param>
    /// <returns>Число в секундах</returns>
    public int GetDuration(string filePath)
    {
        using var reader = new MediaFoundationReader(filePath);
        return (int)reader.TotalTime.TotalSeconds;
    }
}