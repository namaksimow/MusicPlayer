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
    /// Handle to control condition to stop track
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
    /// Get list of songs from folder
    /// </summary>
    /// <returns></returns>
    public List<string> LoadPlaylist()
    {
        DirectoryInfo dinfo = new DirectoryInfo(Path);
        FileInfo[] files = dinfo.GetFiles("*.mp3");
        return files.Select(f => f.Name).ToList();
    }

    /// <summary>
    /// Start play track
    /// </summary>
    /// <param name="songToPlay">name of file in folder</param>
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
    /// Delete track from device
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
    /// Pause or resume current track
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
    /// Change volume of track
    /// </summary>
    /// <param name="volume"></param>
    public void VolumeChange(float volume)
    {
        _outputDevice.Volume = volume;
    }

    /// <summary>
    /// Rewind track
    /// </summary>
    /// <param name="trackbarValue">current value of trackBar</param>
    public void Rewind(int trackbarValue)
    {
        if (_audioFile != null)
        {
            long pos = _audioFile.Length * (trackbarValue + 1) / 11;
            _audioFile.Position = pos;
        }
    }

    /// <summary>
    /// Change index of current song in listBox
    /// </summary>
    /// <param name="newDisplayIndex">index of new song</param>
    public void ChangeDisplayIndex(int newDisplayIndex)
    {
        _dispIndex = newDisplayIndex;
    }

    /// <summary>
    /// Get index of current song in listBox
    /// </summary>
    /// <returns></returns>
    public int GetDisplayIndex()
    {
        return _dispIndex;
    }

    /// <summary>
    /// Start playing next track
    /// </summary>
    /// <param name="listBoxCount">count of songs in listBox</param>
    /// <returns></returns>
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
    /// Start playing previous track
    /// </summary>
    /// <param name="listBoxCount">count of song in listBox</param>
    /// <returns></returns>
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