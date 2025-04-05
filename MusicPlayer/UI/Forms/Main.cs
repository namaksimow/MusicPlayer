using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    
    public Main(ISongService songService, IPlaylistService playlistService)
    {
        _songService = songService;
        _playlistService = playlistService;
        InitializeComponent();
        LoadPlaylist();
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
            listBoxMainPlaylist.Items.Add(songName);
        }
    }
    
    /// <summary>
    /// Обработка действий с песнями, пкм - удалить, лкм - выбрать для проигрывания
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void listBoxMain_MouseDown(object sender, MouseEventArgs e)
    {
        int index = listBoxMainPlaylist.IndexFromPoint(e.Location);

        if (index != -1)
        {
            if (e.Button == MouseButtons.Left)
            {
                string song = listBoxMainPlaylist.Items[index].ToString()!;
                string lyrics = _songService.GetLyrics(song);
                int displayIndex = _playlistService.GetDisplayIndex();
                
                if (displayIndex == -1)
                {
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeDisplayIndex(index);
                }
            
                else if (displayIndex == index) // Same track
                {
                    _playlistService.PauseResume();
                }
                else // another track
                {
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeDisplayIndex(index);
                }
            }
            
            else if (e.Button == MouseButtons.Right)
            {
                listBoxMainPlaylist.ContextMenuStrip = contextMenuStripMain;
            }
        }
        else
        {
            listBoxMainPlaylist.ContextMenuStrip = null;
        }
    }
    
    /// <summary>
    /// Удаление песни из плейлиста
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuDelete_Click(object sender, EventArgs e)
    {
        int index = listBoxMainPlaylist.SelectedIndex;
        if (index != -1)
        {
            string song = listBoxMainPlaylist.Items[index].ToString()!;
            _playlistService.DisposeWave();
            _songService.DeleteSong(song);
            listBoxMainPlaylist.Items.Remove(song);
            textBoxMainLyrics.Text = "";
        }
    }
    
    /// <summary>
    /// Загрузка песен из папки
    /// </summary>
    private void LoadPlaylist()
    {
        List<string> songs = _playlistService.LoadPlaylist();
        listBoxMainPlaylist.Items.AddRange(songs.ToArray());
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
        int displayIndex = _playlistService.NextTrack(listBoxMainPlaylist.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainPlaylist.Items[displayIndex].ToString()!;
            string lyrics = _songService.GetLyrics(song);
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
        int displayIndex = _playlistService.PreviousTrack(listBoxMainPlaylist.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainPlaylist.Items[displayIndex].ToString()!;
            string lyrics = _songService.GetLyrics(song);
            _playlistService.DisposeWave();
            _playlistService.PlayTrack(song);    
            textBoxMainLyrics.Text = lyrics;
        }
    }
}