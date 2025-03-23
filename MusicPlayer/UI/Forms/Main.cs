using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    
    private WaveOutEvent outputDevice;
    private AudioFileReader audioFile;
    
    private string currentSong = "";
    
    public Main(ISongService songService, IPlaylistService playlistService)
    {
        _songService = songService;
        _playlistService = playlistService;
        InitializeComponent();
        LoadPlaylist();
    }

    private async void btnMainUpload_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            await _songService.AddSong(openFileDialog.FileName);
        }
    }
    
    private void listBoxMain_SelectedIndexChanged(object sender, EventArgs e)
    {
        int dispIndex = listBoxMain.SelectedIndex;
        if (dispIndex != -1)
        {
            currentSong = listBoxMain.Items[dispIndex].ToString();    
        }
    }

    private void LoadPlaylist()
    {
        List<string> songs = _playlistService.LoadPlaylist();
        listBoxMain.Items.AddRange(songs.ToArray());
    }

    private void btnMainPlay_Click(object sender, EventArgs e)
    {
        if (outputDevice == null)
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OnPlaybackStopped;
        }
        if (audioFile == null)
        {
            string path = @"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks";
            string song = $"{path}\\{currentSong}";
            Console.WriteLine(song);
            audioFile = new AudioFileReader(song);
            outputDevice.Init(audioFile);
        }
        outputDevice.Play();
    }

    private void btnMainStop_Click(object sender, EventArgs e)
    {
        outputDevice?.Stop();
    }
    
    private void OnPlaybackStopped(object sender, StoppedEventArgs args)
    {
        outputDevice.Dispose();
        outputDevice = null;
        audioFile.Dispose();
        audioFile = null;
    }
}