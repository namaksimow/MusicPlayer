using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    
    public Main(ISongService songService)
    {
        _songService = songService;
        InitializeComponent();
    }

    private async void btnMainUpload_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            await _songService.AddSong(openFileDialog.FileName);
        }
    }
}