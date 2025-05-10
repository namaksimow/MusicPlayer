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
    private readonly ISongSetRepository _songSetRepository;
    private readonly ISelectionRepository _selectionRepository;
    private readonly IJoinRepository _joinRepository;
    private readonly IUserSetsRepository _userSetsRepository;
    private readonly IUserRepository _userRepository;

    private int _userId;

    string CurrentSong { get; set; }

    public SongService(IFileStorageService fileStorage, IDurationService durationService, 
        ILyricsService lyricsService, ITagService tagService, 
        ISongRepository songRepository, IGenreRepository genreRepository,
        IPerformerRepository performerRepository, IGenreSetRepository genreSetRepository,
        IPerformerSetRepository performerSetRepository,  ISongSetRepository songSetRepository,
        ISelectionRepository selectionRepository,  IJoinRepository joinRepository,
        IUserSetsRepository userSetsRepository, IUserRepository userRepository)
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
        _songSetRepository = songSetRepository;
        _selectionRepository = selectionRepository;
        _joinRepository = joinRepository;
        _userSetsRepository = userSetsRepository;
        _userRepository = userRepository;
    }
    
    public void SetCurrentSong(string song)
    {
        CurrentSong = song;
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
    /// <param name="userId"></param>
    public async Task<(int, int)> AddSong(string filePath, int userId)
    {
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        
        (string artist, string title) = ParseFileName(fileName);
        
        // проверка есть ли такая песня в бд
        if (_songRepository.Contains(title))
        {
            // если песня есть, значит её хочет добавить другой пользователь
            bool isUserHaveSong = _joinRepository.IsUserHaveSongByPerformer(userId, title, artist);
            
            if (isUserHaveSong == false) // если у другого пользователя нет такой песни
            {
                int songId = _songRepository.GetSongId(title);
                int songDuration = _songRepository.GetSongDuration(title);
                _userSetsRepository.AddUserSet(userId, songId);
                return (songId, songDuration);
            }
            
            return (-1, 0); // пользователь хочет добавить песню, которую уже добавлял
        }
        
        // Если песня ещё ни разу не была добавлена, то добавляем в папку и в бд
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
        _userSetsRepository.AddUserSet(userId, song.Id);
        return (song.Id, duration);
    }

    /// <summary>
    /// Удалить трек
    /// </summary>
    /// <param name="fileName">Название песни</param>
    /// <param name="playlist">Название плейлиста</param>
    /// <param name="userId"></param>
    public void DeleteSong(string fileName, string playlist, int userId)
    {
        // Название трека без его расширения, по нему будем искать записи в БД
        string title = GetSongTitle(Path.GetFileNameWithoutExtension(fileName));
        
        var song = _songRepository.Find(title);
        int selectionId = _selectionRepository.GetSelectionId(playlist, userId);

        Console.WriteLine(selectionId);
        Console.WriteLine(song.Id);
        
        if (playlist == "Загруженные")
        {
            int countSameSong = _joinRepository.GetCountSameSong(song.Id);

            if (countSameSong == 1)
            {
                /*_fileStorage.DeleteFile(fileName);    
                _performerSetRepository.DeleteSongFromPerformer(song.Id);
                _genreSetRepository.DeleteSongFromGenre(song.Id);*/
                _songSetRepository.DeleteSongSetBySongId(song.Id);
                _selectionRepository.ChangeSelectionDuration(selectionId, -song.Duration);
                _userSetsRepository.DeleteUserSet(userId, song.Id);
                _songRepository.Delete(song.Id);
            }
            else
            {
                _userSetsRepository.DeleteUserSet(userId, song.Id);
                _songSetRepository.DeleteSongSetBySongIdSelectionId(song.Id, selectionId);
                _selectionRepository.ChangeSelectionDuration(selectionId, -song.Duration);    
            }
        }
        else
        {
            _userSetsRepository.DeleteUserSet(userId, song.Id);
            _songSetRepository.DeleteSongSetBySongIdSelectionId(song.Id, selectionId);
            _selectionRepository.ChangeSelectionDuration(selectionId, -song.Duration);
        }
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