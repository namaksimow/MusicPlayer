namespace MusicPlayer.Domain.Interfaces;

public interface IFileStorageService
{
    string SaveFile(string filePath);   
}