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

    string CurrentSong { get; set; }

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
    
    public void SetCurrentSong(string song)
    {
        CurrentSong = song;
    }

    public string GetCurrentSong()
    {
        return CurrentSong;
    }
    
    /// <summary>
    /// Получить текст песни
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns>Текст песни типа string</returns>
    public string GetLyrics(string fileName)
    {
        string artistAndTitle = Path.GetFileNameWithoutExtension(fileName);
        string title = GetSongTitle(artistAndTitle);
        var song = _songRepository.Find(title);
        return song.Lyrics!;
    }
    
    /// <summary>
    /// Добавить трек
    /// </summary>
    /// <param name="filePath">Путь к треку в папке</param>
    public async Task<int> AddSong(string filePath)
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
            
            return song.Id;
        }
        else
        {
            return -1;
        }
    }

    /// <summary>
    /// Удалить трек
    /// </summary>
    /// <param name="fileName"></param>
    public void DeleteSong(string fileName)
    {
        // Название трека без его расширения, по нему будем искать записи в БД
        string title = GetSongTitle(Path.GetFileNameWithoutExtension(fileName)); 
        
        var song = _songRepository.Find(title);
        _performerSetRepository.DeleteSongFromPerformer(song.Id);
        _genreSetRepository.DeleteSongFromGenre(song.Id);
        _songRepository.Delete(song.Id);
        _fileStorage.DeleteFile(fileName);
    }
    
    /// <summary>
    /// Получить название песни
    /// </summary>
    /// <param name="filePath">Путь до файла</param>
    /// <returns>Название трека</returns>
    public string GetSongName(string filePath)
    {
        string[] data = filePath.Split(@"\");
        return data.Last();
    }

    /// <summary>
    /// Получить название песни
    /// </summary>
    /// <param name="fileName">Имя файла с исполнителем и название песни</param>
    /// <returns>Название трека</returns>
    public string GetSongTitle(string fileName)
    {
        string[] data = fileName.Split(@"-");
        return data[1];
    }
    
    /// <summary>
    /// Получить имя исполнителя и название трека из названия файла
    /// </summary>
    /// <param name="fileName">Название файла</param>
    /// <returns>имя артиста и название трека</returns>
    public (string artist, string title) ParseFileName(string fileName)
    {
        string[] artistAndTrack = fileName.Split('-');
        return (artistAndTrack[0], artistAndTrack[1]);
    }
}