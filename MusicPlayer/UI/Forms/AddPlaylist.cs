using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class AddPlaylist : Form
{
    private readonly ISelectionRepository _selectionRepository;
    
    public string PlaylistName { get; set; }
    
    public AddPlaylist(ISelectionRepository selectionRepository)
    {
        _selectionRepository = selectionRepository;
        InitializeComponent();
    }

    /// <summary>
    /// Получить имя плейлиста, которое мы добавили 
    /// </summary>
    /// <returns></returns>
    public string GetPlaylistName()
    {
        return PlaylistName;
    }
    
    /// <summary>
    /// Добавить плейлист
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void buttonAPLAdd_Click(object sender, EventArgs e)
    {
        string playlistName = textBoxAPLName.Text;

        if (string.IsNullOrEmpty(playlistName))
        {
            MessageBox.Show("Please enter a playlist name");
            return;
        }
        
        bool isExists = _selectionRepository.Exists(playlistName);
        if (isExists)
        {
            MessageBox.Show("Playlist already exists");
            return;
        }
        
        PlaylistName = playlistName;
        _selectionRepository.AddSelection(playlistName);
        MessageBox.Show("Playlist added");
        Close();   
    }
}