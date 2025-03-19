using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class FileStorageService : IFileStorageService
{
    private const string SaveDirectory = "C:\\notSystem\\vcs\\MusicPlayer\\MusicPlayer\\Tracks";

    public string SaveFile(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        string fileSavePath = Path.Combine(SaveDirectory, fileName);
        File.Copy(filePath, fileSavePath);
        return fileSavePath;
    }
}