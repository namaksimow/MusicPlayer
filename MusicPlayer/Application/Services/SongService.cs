using MusicPlayer.DataBase.Models;
using MusicPlayer.Domain.Interfaces;
using MusicPlayer.UI.Forms;

namespace MusicPlayer.Application.Services;

public class SongService : ISongService 
{
    private readonly IFileStorageService _fileStorage;
    private readonly IDurationService _durationService;
    private readonly ILyricsService _lyricsService;
    private readonly ITagService _tagService;
    private readonly ISongRepository _songRepository;
    private readonly IGenreRepository _genreRepository;

    public SongService(IFileStorageService fileStorage, IDurationService durationService, 
        ILyricsService lyricsService, ITagService tagService, 
        ISongRepository songRepository, IGenreRepository genreRepository)
    {
        _fileStorage = fileStorage;
        _durationService = durationService;
        _lyricsService = lyricsService;
        _tagService = tagService;
        _songRepository = songRepository;
        _genreRepository = genreRepository;
    }

    public async Task AddSong(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        (string artist, string title) = ParseFileName(fileName);

        if (!_songRepository.Contains(title))
        {
            string newFilePath = _fileStorage.SaveFile(filePath);
            int duration = _durationService.GetDuration(newFilePath);
            string? lyrics = await _lyricsService.GetLyrics(artist, title);
            var tags = await _tagService.GetTags(artist, title);
            _genreRepository.Add(tags);
        
            Song song = new Song(title, duration, lyrics);
            _songRepository.Add(song);    
            MessageBox.Show("Song added");
        }
        else
        {
            MessageBox.Show("Song exist");    
        }
    }

    private (string artist, string title) ParseFileName(string fileName)
    {
        string[] artistAndTrack = fileName.Split('-');
        return (artistAndTrack[0], artistAndTrack[1]);
    }
}