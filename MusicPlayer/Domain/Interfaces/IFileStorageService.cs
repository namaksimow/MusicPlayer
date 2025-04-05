namespace MusicPlayer.Domain.Interfaces;

public interface IFileStorageService
{
    string SaveFile(string filePath);   
    void DeleteFile(string fileName);
}