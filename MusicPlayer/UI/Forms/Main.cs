using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    
    private readonly WaveOutEvent _outputDevice = new();
    private AudioFileReader? _audioFile;
    
    private int _dispIndex = -1;
    
    public Main(ISongService songService, IPlaylistService playlistService)
    {
        _songService = songService;
        _playlistService = playlistService;
        InitializeComponent();
        LoadPlaylist();
        _outputDevice.PlaybackStopped += OnPlaybackStopped!;
    }

    /// <summary>
    /// Adding song to playlist
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnMainUpload_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            await _songService.AddSong(openFileDialog.FileName);
        }
    }
    
    private void listBoxMain_MouseDown(object sender, MouseEventArgs e)
    {
        int index = listBoxMain.IndexFromPoint(e.Location);

        if (index != -1)
        {
            string song = listBoxMain.Items[index].ToString()!;

            if (_dispIndex == -1)
            {
                PlayTrack(song);
                _dispIndex = index;
                return;
            }
            
            // Если играет тот же трек, то нужно приостановить трек
            // Если начинает играть другой трек, то надо "удалить" старый трек
            if (_dispIndex == index)
            {
                PauseResume();
            }
            else
            {
                DisposeWave();
                PlayTrack(song);
                _dispIndex = index;
            }
        }
    }
    
    /// <summary>
    /// Loading song from folder
    /// </summary>
    private void LoadPlaylist()
    {
        List<string> songs = _playlistService.LoadPlaylist();
        listBoxMain.Items.AddRange(songs.ToArray());
    }
    
    private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        if (_audioFile != null)
        {
            _audioFile.Position = 0;
            _outputDevice.Play();
            Console.WriteLine(_dispIndex);
            if (_audioFile != null)
            {
                Console.WriteLine();
            }    
        }
    }

    /// <summary>
    /// Change volume of playing track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarMainVolume_Scroll(object sender, EventArgs e)
    {
        _outputDevice.Volume = trackBarMainVolume.Value / 100f;
    }

    private void PlayTrack(string songToPlay)
    {
        string path = @"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks";
        string song = Path.Combine(path, songToPlay);
        
        if (_audioFile == null)
        {
            _audioFile = new AudioFileReader(song);
        }
        
        _outputDevice.Init(_audioFile);
        _outputDevice.Play();
    }

    private void PauseResume()
    {
        if (_outputDevice.PlaybackState == PlaybackState.Playing)
        {
            _outputDevice.Pause();
        }

        else if (_outputDevice.PlaybackState == PlaybackState.Paused)
        {
            _outputDevice.Play();
        }
    }
    
    private void DisposeWave()
    {
        if (_audioFile != null)
        {
            _audioFile.Dispose();
            _audioFile = null;   
        }
        _outputDevice.Stop();
    }

    /// <summary>
    /// Change position of track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarMainRewind_Scroll(object sender, EventArgs e)
    {
        if (_audioFile != null)
        {
            long pos = _audioFile.Length * (trackBarMainRewind.Value + 1) / 11;
            _audioFile.Position = pos;    
        }
    }

    private void btnMainPlayPause_Click(object sender, EventArgs e)
    {
        if (_dispIndex == -1)
        {
            return;
        }
        
        if (_outputDevice.PlaybackState == PlaybackState.Playing)
        {
            _outputDevice.Pause();
            btnMainPlayPause.Text = "Play";
        }

        else if (_outputDevice.PlaybackState == PlaybackState.Paused)
        {
            _outputDevice.Play();
            btnMainPlayPause.Text = "Pause";
        }
    }

    /// <summary>
    /// Next track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainNext_Click(object sender, EventArgs e)
    {
        if (_dispIndex == -1)
        {
            return;
        }

        _dispIndex += 1;
        if (_dispIndex == listBoxMain.Items.Count)
        {
            _dispIndex = 0;
        }
        
        string song = listBoxMain.Items[_dispIndex].ToString()!;
        DisposeWave();
        PlayTrack(song);
    }

    /// <summary>
    /// Previous track
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainPrev_Click(object sender, EventArgs e)
    {
        if (_dispIndex == -1)
        {
            return;
        }

        _dispIndex -= 1;
        if (_dispIndex == -1)
        {
            _dispIndex = listBoxMain.Items.Count - 1;
        }
        
        string song = listBoxMain.Items[_dispIndex].ToString()!;
        DisposeWave();
        PlayTrack(song);
    }
}