using GeniusAPI;
using GeniusAPI.Models;
using Microsoft.Extensions.Logging;
using NAudio.Wave;
using Newtonsoft.Json.Linq;
using MusicPlayer.DataBase.Models;
using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;


namespace MusicPlayer;

public partial class MainForm : Form
{
    private readonly ISongService _songService;
    
    public MainForm(ISongService songService)
    {
        _songService = songService;
        InitializeComponent();
    }

    private async void btnMainFormUpload_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            await _songService.AddSong(openFileDialog.FileName);
        }
    }    
}