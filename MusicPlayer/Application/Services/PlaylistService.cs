using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using NAudio.Wave;

namespace MusicPlayer.Application.Services;

public class PlaylistService : IPlaylistService
{
    private const string Path = @"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks";

    private readonly WaveOutEvent _outputDevice = new();
    
    private AudioFileReader? _audioFile;
    
    private int _currentSongIndex = -1;
    private int IndexCurrentPlaylist { get; set; } = -1;
    private int IndexQueue { get; set; } = -1;
    
    private List<string> CurrentPlaylist;
    
    public PlaylistService()
    {
        _outputDevice.PlaybackStopped += OnPlaybackStopped!;
    }

    /// <summary>
    /// Получить плейлиста, который играет в очереди
    /// </summary>
    /// <returns></returns>
    public int GetCurrentQueueIndex()
    {
        return IndexQueue;
    }
    
    /// <summary>
    /// Установить текущую играющую очередь
    /// </summary>
    /// <param name="queue"></param>
    public void SetCurrentQueueIndex(int queue)
    {
        IndexQueue = queue;
    }
    
    /// <summary>
    /// Установить текущий играющий плейлист
    /// </summary>
    /// <param name="playlist"></param>
    public void SetCurrentPlaylist(List<string> playlist)
    {
        CurrentPlaylist = playlist;
    }

    /// <summary>
    /// Получить текущий играющий плейлист
    /// </summary>
    /// <returns></returns>
    public List<string> GetCurrentPlaylist()
    {
        return CurrentPlaylist;
    }
    
    /// <summary>
    /// Обработка при остановке трека. Трек может остановиться 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        if (_audioFile != null)
        {
            _audioFile.Position = 0;
            _outputDevice.Play();
        }
    }

    /// <summary>
    /// Установить номер последнего открытого плейлиста
    /// </summary>
    /// <param name="playlist"></param>
    public void SetCurrentPlaylistId(int playlist)
    {
        IndexCurrentPlaylist = playlist;
    }

    /// <summary>
    /// Получить текущий номер открытого плейлиста
    /// </summary>
    /// <returns></returns>
    public int GetCurrentPlaylistId()
    {
        return IndexCurrentPlaylist;
    }

    /// <summary>
    /// Получить список треков в папке
    /// </summary>
    /// <returns></returns>
    public List<string> LoadUploadTracks()
    {
        DirectoryInfo dinfo = new DirectoryInfo(Path);
        FileInfo[] files = dinfo.GetFiles("*.mp3");
        return files.Select(f => f.Name).ToList();
    }

    /// <summary>
    /// Начать произведение трека
    /// </summary>
    /// <param name="songToPlay">Название файла в папке</param>
    public void PlayTrack(string songToPlay)
    {
        string song = System.IO.Path.Combine(Path, songToPlay);
        
        if (_audioFile == null)
        {
            _audioFile = new AudioFileReader(song);
        }
        
        _outputDevice.Init(_audioFile);
        _outputDevice.Play();
    }
    
    /// <summary>
    /// Удалить трек из проигрывающего девайса
    /// </summary>
    public void DisposeWave()
    {
        if (_audioFile != null)
        {
            _audioFile.Dispose();
            _audioFile = null;   
        }
        _outputDevice.Stop();
    }

    /// <summary>
    /// Остановить или продолжить воспроизведение трека
    /// </summary>
    public void PauseResume()
    {
        if (_currentSongIndex == -1)
        {
            return;
        }
        
        if (_outputDevice.PlaybackState == PlaybackState.Playing)
        {
            _outputDevice.Pause();
        }

        else if (_outputDevice.PlaybackState == PlaybackState.Paused)
        {
            _outputDevice.Play();
        }
    }
    
    /// <summary>
    /// Изменить громкость трека
    /// </summary>
    /// <param name="volume">Значение громкости</param>
    public void VolumeChange(float volume)
    {
        _outputDevice.Volume = volume;
    }

    /// <summary>
    /// Перемотка трека
    /// </summary>
    /// <param name="trackbarValue">Текущее значение на трекбаре</param>
    public void Rewind(int trackbarValue)
    {
        if (_audioFile != null)
        {
            long pos = _audioFile.Length * (trackbarValue + 1) / 1001;
            _audioFile.Position = pos;
        }
    }

    /// <summary>
    /// Изменить номер текущей песни, которая играет
    /// </summary>
    /// <param name="indexTrack">Индекс в listBoxTrack новой песни</param>
    /// <param name="indexQueue">Индекс в listBoxQueue новой песни</param>
    public void ChangeCurrentSongIndex(int indexTrack, int indexQueue)
    {
        // Так как песню мы можем выбрать как из загруженного плейлиста, так и из загруженной очереди
        if (indexTrack == -1)
        {
            _currentSongIndex = indexQueue;    
        }
        else
        {
            _currentSongIndex = indexTrack;    
        }
    }

    /// <summary>
    /// Получить индекс песни, которая сейчас играет
    /// </summary>
    /// <returns>Индекс текущего трека</returns>
    public int GetCurrentSongIndex()
    {
        return _currentSongIndex;
    }

    /// <summary>
    /// Начать произведение трека, когда текущий трек заканчивается, то должен включиться следующий по списку
    /// </summary>
    /// <param name="listBoxCount">Количество песен в listBox</param>
    /// <returns>Индекс текущего трека</returns>
    public int NextTrack(int listBoxCount)
    {
        if (_currentSongIndex == -1)
        {
            return -1;
        }
        
        _currentSongIndex += 1;
        
        if (_currentSongIndex == listBoxCount)
        {
            _currentSongIndex = 0;
            return _currentSongIndex;
        }
        
        return _currentSongIndex;
    }

    /// <summary>
    /// Начать воспроизведение предыдущего трека
    /// </summary>
    /// <param name="listBoxCount">Количество песен в listBox</param>
    /// <returns>Индекс текущего трека</returns>
    public int PreviousTrack(int listBoxCount)
    {
        if (_currentSongIndex == -1)
        {
            return - 1;
        }
        
        _currentSongIndex -= 1;
        
        if (_currentSongIndex == -1)
        {
            _currentSongIndex = listBoxCount - 1;
            return _currentSongIndex;
        }
        
        return _currentSongIndex;
    }
}