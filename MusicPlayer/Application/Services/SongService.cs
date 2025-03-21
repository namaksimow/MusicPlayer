using MusicPlayer.Domain.Models;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class SongService : ISongService 
{
    private readonly IFileStorageService _fileStorage;
    private readonly IDurationService _durationService;
    private readonly ILyricsService _lyricsService;
    private readonly ITagService _tagService;
    private readonly ISongRepository _songRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPerformerRepository _performerRepository;
    private readonly IGenreSetRepository _genreSetRepository;
    private readonly IPerformerSetRepository _performerSetRepository;

    public SongService(IFileStorageService fileStorage, IDurationService durationService, 
        ILyricsService lyricsService, ITagService tagService, 
        ISongRepository songRepository, IGenreRepository genreRepository,
        IPerformerRepository performerRepository, IGenreSetRepository genreSetRepository,
        IPerformerSetRepository performerSetRepository)
    {
        _fileStorage = fileStorage;
        _durationService = durationService;
        _lyricsService = lyricsService;
        _tagService = tagService;
        _songRepository = songRepository;
        _genreRepository = genreRepository;
        _performerRepository = performerRepository;
        _genreSetRepository = genreSetRepository;
        _performerSetRepository = performerSetRepository;
    }

    public async Task AddSong(string filePath)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        (string artist, string title) = ParseFileName(fileName);

        if (!_songRepository.Contains(title))
        {
            string newFilePath = _fileStorage.SaveFile(filePath);
            int duration = _durationService.GetDuration(newFilePath);
            string lyrics = await _lyricsService.GetLyrics(artist, title);
            
            var tags = await _tagService.GetTags(artist, title);
            await _genreRepository.Add(tags);
        
            Song song = new Song(title, duration, lyrics);
            await _songRepository.Add(song);
            
            Performer? performerExist = _performerRepository.Exist(artist);
            if (performerExist == null)
            {
                await _performerRepository.Add(new Performer(artist));   
                performerExist = _performerRepository.Exist(artist);
            }
            
            await _genreSetRepository.Add(tags,  song.Id);
            
            await _performerSetRepository.Add(performerExist!.Id, song.Id);
        }
    }

    private (string artist, string title) ParseFileName(string fileName)
    {
        string[] artistAndTrack = fileName.Split('-');
        return (artistAndTrack[0], artistAndTrack[1]);
    }
}