using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    private readonly IJoinRepository _joinRepository;
    
    public Main(ISongService songService, IPlaylistService playlistService, IJoinRepository joinRepository)
    {
        _songService = songService;
        _playlistService = playlistService;
        _joinRepository = joinRepository;
        InitializeComponent();
        LoadAllPlaylist();
    }

    private void LoadAllPlaylist()
    {
        List<string> playlist = _playlistService.LoadAllPlaylist();
        listBoxMainPlaylists.Items.AddRange(playlist.ToArray());
    }
    
    /// <summary>
    /// Добавить песню в плейлист
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void btnMainUpload_Click(object sender, EventArgs e)
    {
        using OpenFileDialog openFileDialog = new();
        
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            await _songService.AddSong(openFileDialog.FileName);
            string songName = _songService.GetSongName(openFileDialog.FileName);
            listBoxMainTracks.Items.Add(songName);
        }
    }
    
    /// <summary>
    /// Обработка действий с песнями, пкм - удалить, лкм - выбрать для проигрывания
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listBoxTracks_MouseDown(object sender, MouseEventArgs e)
    {
        int index = listBoxMainTracks.IndexFromPoint(e.Location);

        if (index != -1)
        {
            if (e.Button == MouseButtons.Left) // Выбрать песню для 
            {
                string song = listBoxMainTracks.Items[index].ToString()!;
                string lyrics = _songService.GetLyrics(song);
                int displayIndex = _playlistService.GetDisplayIndex();
                
                if (displayIndex == -1)
                {
                    _songService.SetCurrentSong(song);
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeDisplayIndex(index);
                }
            
                else if (displayIndex == index) // Тот же трек
                {
                    _playlistService.PauseResume();
                }
                else // Другой трек
                {
                    _songService.SetCurrentSong(song);
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeDisplayIndex(index);
                }
            }
            
            else if (e.Button == MouseButtons.Right)
            {
                listBoxMainTracks.ContextMenuStrip = contextMenuStripMainSongEdit;
            }
        }
        else // Контекстное меню для взаимодействия с песней
        {
            listBoxMainTracks.ContextMenuStrip = null;
        }
    }
    
    /// <summary>
    /// Удаление песни из плейлиста
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuSongDeleteClick(object sender, EventArgs e)
    {
        int index = listBoxMainTracks.SelectedIndex;
        if (index != -1)
        {
            string song = listBoxMainTracks.Items[index].ToString()!;
            _playlistService.DisposeWave();
            _songService.DeleteSong(song);
            listBoxMainTracks.Items.Remove(song);
            textBoxMainLyrics.Text = "";
        }
    }
    
    /// <summary>
    /// Изменение громкости трека
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarMainVolume_Scroll(object sender, EventArgs e)
    {
        float volume = trackBarMainVolume.Value / 100f;
        _playlistService.VolumeChange(volume);
    }
    
    /// <summary>
    /// Изменение позиции трека
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void trackBarMainRewind_Scroll(object sender, EventArgs e)
    {
        _playlistService.Rewind(trackBarMainRewind.Value);   
    }

    /// <summary>
    /// Остановить воспроизведение
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainPlayPause_Click(object sender, EventArgs e)
    {
        _playlistService.PauseResume();
    }

    /// <summary>
    /// Выбрать следующий трек
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainNext_Click(object sender, EventArgs e)
    {
        int displayIndex = _playlistService.NextTrack(listBoxMainTracks.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainTracks.Items[displayIndex].ToString()!;
            string lyrics = _songService.GetLyrics(song);
            _songService.SetCurrentSong(song);
            _playlistService.DisposeWave();
            _playlistService.PlayTrack(song);
            textBoxMainLyrics.Text = lyrics;
        }
    }

    /// <summary>
    /// Выбрать предыдущий трек
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainPrev_Click(object sender, EventArgs e)
    {
        int displayIndex = _playlistService.PreviousTrack(listBoxMainTracks.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainTracks.Items[displayIndex].ToString()!;
            string lyrics = _songService.GetLyrics(song);
            _songService.SetCurrentSong(song);
            _playlistService.DisposeWave();
            _playlistService.PlayTrack(song);    
            textBoxMainLyrics.Text = lyrics;
        }
    }

    /// <summary>
    /// Добавить плейлист
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMainAddPlaylist_Click(object sender, EventArgs e)
    {
        AddPlaylist form = new AddPlaylist();
        form.ShowDialog();
    }

    /// <summary>
    /// Обработка действий с плейлистами
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listBoxMainPlaylists_MouseDown(object sender, MouseEventArgs e)
    {
        int index = listBoxMainPlaylists.IndexFromPoint(e.Location);

        if (index != -1)
        {
            if (e.Button == MouseButtons.Left)
            {
                listBoxMainTracks.Items.Clear();
                
                string playlist = listBoxMainPlaylists.Items[index].ToString()!;
                _playlistService.SetCurrentPlaylist(index);
                
                int selectionId = _playlistService.GetSelectionId(playlist);
                Console.WriteLine(selectionId);
                
                List<string> songs = _joinRepository.GetSongsBySelectionId(selectionId);
                
                listBoxMainTracks.Items.AddRange(songs.ToArray());
                
                Console.WriteLine($@"загружаю {playlist}");
                // Загрузка песен из плейлиста
            }
            
            else if (e.Button == MouseButtons.Right)
            {
                listBoxMainPlaylists.ContextMenuStrip = contextMenuStripMainPlaylistEdit;
            }
        }
        else // Контекстное меню для взаимодействия с плейлистом
        {
            listBoxMainPlaylists.ContextMenuStrip = null;
        }
    }

    /// <summary>
    /// Удаление плейлиста
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuPlaylistDeleteClick(object sender, EventArgs e)
    {
        int index = listBoxMainPlaylists.SelectedIndex;
        if (index != -1)
        {
            int currentPlaylist = _playlistService.GetCurrentPlaylist();

            if (currentPlaylist == index)
            {
                _playlistService.DisposeWave();
                listBoxMainTracks.Items.Clear();
            }
            
            string playlist = listBoxMainPlaylists.Items[index].ToString()!;
            listBoxMainPlaylists.Items.Remove(playlist);
            _playlistService.SetCurrentPlaylist(-1);
        }
    }
}