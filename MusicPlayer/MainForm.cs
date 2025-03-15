using GeniusAPI;
using GeniusAPI.Models;

namespace MusicPlayer;

public partial class MainForm : Form
{
    string _accessToken = "y20k-ih6uzRLeiNsq0QLFb8Tl5b8ySYHY_re7E8InIc3oFBjMh-_mavWHPaHv3Gg";
    string _apiKey = "e1ee6c709f10d650910e0efe472d70e4";
    
    public MainForm()
    {
        InitializeComponent();
    }

    private void btnMainFormUploadFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string saveDirectory = "C:\\notSystem\\vcs\\MusicPlayer\\MusicPlayer\\Tracks";
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            string fileName = Path.GetFileName(openFileDialog.FileName);
            Console.WriteLine(fileName);
            string fileSavePath = Path.Combine(saveDirectory, fileName);
            File.Copy(openFileDialog.FileName, fileSavePath);
        }
    }
    
    public async Task<string> GetLyrics(GeniusClient client, string track, string artist) 
    {
        GeniusTrackInfo? trackInfo = await client.GetTrackInfoAsync(track, artist);

        if (trackInfo != null)
        {
            string? lyrics = trackInfo.Lyrics;
            return lyrics;
        }
        
        return null;
    }

    private async void btnMainFormFindLyrics_Click(object sender, EventArgs e)
    {
        GeniusClient client = new GeniusClient(_accessToken);
        string track = "Disease";
        string artist = "Beartooth";
        
        string lyrics = await GetLyrics(client, track, artist);
        Console.WriteLine(lyrics);
    }
}