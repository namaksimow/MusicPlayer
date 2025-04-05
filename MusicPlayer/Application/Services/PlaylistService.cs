using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.Application.Services;

public class PlaylistService : IPlaylistService
{
    private const string Path = @"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks";

    private readonly WaveOutEvent _outputDevice = new();
    private AudioFileReader? _audioFile;
    private int _dispIndex = -1;
    
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
    
    public PlaylistService()
    {
        _outputDevice.PlaybackStopped += OnPlaybackStopped!;
    }
    
    /// <summary>
    /// Получить список треков в папке
    /// </summary>
    /// <returns></returns>
    public List<string> LoadPlaylist()
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
        if (_dispIndex == -1)
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
    /// <param name="newDisplayIndex">Индекс в listBox новой песни</param>
    public void ChangeDisplayIndex(int newDisplayIndex)
    {
        _dispIndex = newDisplayIndex;
    }

    /// <summary>
    /// Получить индекс песни, которая сейчас играет
    /// </summary>
    /// <returns>Индекс текущего трека</returns>
    public int GetDisplayIndex()
    {
        return _dispIndex;
    }

    /// <summary>
    /// Начать произведение трека, когда текущий трек заканчивается, то должен включиться следующий по списку
    /// </summary>
    /// <param name="listBoxCount">Количество песен в listBox</param>
    /// <returns>Индекс текущего трека</returns>
    public int NextTrack(int listBoxCount)
    {
        if (_dispIndex == -1)
        {
            return -1;
        }
        
        _dispIndex += 1;
        
        if (_dispIndex == listBoxCount)
        {
            _dispIndex = 0;
            return _dispIndex;
        }
        
        return _dispIndex;
    }

    /// <summary>
    /// Начать воспроизведение предыдущего трека
    /// </summary>
    /// <param name="listBoxCount">Количество песен в listBox</param>
    /// <returns>Индекс текущего трека</returns>
    public int PreviousTrack(int listBoxCount)
    {
        if (_dispIndex == -1)
        {
            return - 1;
        }
        
        _dispIndex -= 1;
        
        if (_dispIndex == -1)
        {
            _dispIndex = listBoxCount - 1;
            return _dispIndex;
        }
        
        return _dispIndex;
    }
}