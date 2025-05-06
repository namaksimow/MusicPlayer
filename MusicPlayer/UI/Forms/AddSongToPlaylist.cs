using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class AddSongToPlaylist : Form
{
    private readonly ISelectionRepository _selectionRepository;
    private readonly ISongSetRepository _songSetRepository;
    private readonly ISongRepository _songRepository;
    private readonly ISongService _songService;

    private string _song;
    
    public AddSongToPlaylist(string song, ISelectionRepository selectionRepository, ISongService songService,
        ISongSetRepository songSetRepository, ISongRepository songRepository)
    {
        _song = song;
        _songService = songService;
        _selectionRepository = selectionRepository;
        _songSetRepository = songSetRepository;
        _songRepository = songRepository;
        InitializeComponent();
        LoadPlaylist();
    }

    private void LoadPlaylist()
    {
        List<string> playlists = _selectionRepository.GetAllSelections();
        listBoxASTPPlaylistPick.Items.AddRange(playlists.ToArray());
    }

    private void listBoxASTPPlaylistPick_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPlaylist = listBoxASTPPlaylistPick.IndexFromPoint(e.Location);

        if (indexPlaylist != -1)
        {
            string playlist = listBoxASTPPlaylistPick.Items[indexPlaylist].ToString()!;
            listBoxASTPPlaylistChosen.Items.Add(playlist);
            listBoxASTPPlaylistPick.Items.Remove(playlist);
        }
    }
    
    private void listBoxASTPPlaylistChosen_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPlaylist = listBoxASTPPlaylistChosen.IndexFromPoint(e.Location);

        if (indexPlaylist != -1)
        {
            string playlist = listBoxASTPPlaylistChosen.Items[indexPlaylist].ToString()!;
            listBoxASTPPlaylistChosen.Items.Remove(playlist);
            listBoxASTPPlaylistPick.Items.Add(playlist);
        }
    }

    private void buttonASTPAdd_Click(object sender, EventArgs e)
    {
        int playlistCount = listBoxASTPPlaylistChosen.Items.Count;
        for (int i = 0; i < playlistCount; i++)
        {
            string playlist = listBoxASTPPlaylistChosen.Items[i].ToString()!;
            string song = _song;
            
            string songWithOutExtension = song.Substring(0, song.Length - 4);
            int selectionId = _selectionRepository.GetSelectionId(playlist);
            (string artist, string title) = _songService.ParseFileName(songWithOutExtension);
            int songId = _songRepository.GetSongId(title);
            int songDuration = _songRepository.GetSongDuration(title);
            
            _selectionRepository.ChangeSelectionDuration(selectionId, songDuration);
            _songSetRepository.AddSongSet(selectionId, songId);
            Close();
        }
    }
}