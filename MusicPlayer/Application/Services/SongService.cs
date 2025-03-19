using MusicPlayer.DataBase.Models;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class SongService : ISongService 
{
    private readonly IFileStorageService _fileStorage;
    private readonly IDurationService _metadataService;
    private readonly ILyricsService _lyricsService;
    private readonly ITagService _tagService;
    private readonly ISongRepository _songRepository;

    public SongService(IFileStorageService fileStorage, IDurationService metadataService, 
        ILyricsService lyricsService, ITagService tagService, 
        ISongRepository songRepository)
    {
        _fileStorage = fileStorage;
        _metadataService = metadataService;
        _lyricsService = lyricsService;
        _tagService = tagService;
        _songRepository = songRepository;
    }

    public async Task AddSong(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        (string artist, string title) = ParseFileName(filePath);
        Console.WriteLine("qwerqwer");
        Console.WriteLine(artist);
        Console.WriteLine(title);
        
        /*string newFilePath = _fileStorage.SaveFile(filePath);
        int duration = _metadataService.GetDuration(newFilePath);
        string? lyrics = await _lyricsService.GetLyrics(artist, title);
        var tags = await _tagService.GetTags(artist, title);

        Song song = new Song(title, duration, lyrics);
        */

        /*await _songRepository.AddAsync(song);*/
    }

    private (string artist, string title) ParseFileName(string fileName)
    {
        string[] artistAndTrack = fileName.Split('-');
        return (artistAndTrack[0], artistAndTrack[1]);
    }
}