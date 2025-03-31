using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    
    private WaveOutEvent outputDevice = new WaveOutEvent();
    private AudioFileReader audioFile;
    
    private int dispIndex = -1;
    
    public Main(ISongService songService, IPlaylistService playlistService)
    {
        _songService = songService;
        _playlistService = playlistService;
        InitializeComponent();
        LoadPlaylist();
        outputDevice.PlaybackStopped += OnPlaybackStopped;
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

            if (dispIndex == -1)
            {
                PlayTrack(song);
                dispIndex = index;
                return;
            }

            Console.WriteLine($"{dispIndex}: {index}");
            // Если играет тот же трек, то нужно приостановить трек
            // Если начинает играть другой трек, то надо "удалить" старый трек
            if (dispIndex == index)
            {
                PauseResume();
            }
            else
            {
                DisposeWave();
                PlayTrack(song);
                dispIndex = index;
            }
            
            
            Console.WriteLine(dispIndex);
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
        if (audioFile != null)
        {
            audioFile.Position = 0;
            outputDevice.Play();
            Console.WriteLine(dispIndex);
            if (audioFile != null)
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
    private void trackBarMain_Scroll(object sender, EventArgs e)
    {
        if (outputDevice != null) 
        {
            outputDevice.Volume = trackBarMain.Value / 100f;
        }
    }

    private void PlayTrack(string songToPlay)
    {
        string path = @"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks";
        string song = Path.Combine(path, songToPlay);
        
        if (audioFile == null)
        {
            audioFile = new AudioFileReader(song);
        }

        Console.WriteLine($"Инициализация трека {song}");
        outputDevice.Init(audioFile);
        outputDevice.Play();
    }

    private void PauseResume()
    {
        if (outputDevice.PlaybackState == PlaybackState.Playing)
        {
            outputDevice.Pause();
        }

        else if (outputDevice.PlaybackState == PlaybackState.Paused)
        {
            outputDevice.Play();
        }
    }
    
    private void DisposeWave()
    {
        if (audioFile != null)
        {
            audioFile.Dispose();
            audioFile = null;   
        }
        outputDevice.Stop();
    }
}