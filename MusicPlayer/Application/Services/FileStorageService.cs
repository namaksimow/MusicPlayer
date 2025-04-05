using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class FileStorageService : IFileStorageService
{
    private const string SaveDirectory = "C:\\notSystem\\vcs\\MusicPlayer\\MusicPlayer\\Tracks";

    /// <summary>
    /// Сохранить файл
    /// </summary>
    /// <param name="filePath">Путь до файла из места загрузки</param>
    /// <returns>Строку для добавления файла в папку</returns>
    public string SaveFile(string filePath)
    {
        string fileName = Path.GetFileName(filePath);
        string fileSavePath = Path.Combine(SaveDirectory, fileName);
        File.Copy(filePath, fileSavePath);
        return fileSavePath;
    }

    /// <summary>
    /// Удалить файл папки
    /// </summary>
    /// <param name="fileName">Имя файла</param>
    public void DeleteFile(string fileName)
    {
        string filePath = Path.Combine(SaveDirectory, fileName);
        File.Delete(filePath);
    }
}