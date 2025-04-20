using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    private readonly IJoinRepository _joinRepository;
    private readonly ISelectionRepository _selectionRepository;
    private readonly ISongSetRepository _songSetRepository;
    
    public Main(ISongService songService, IPlaylistService playlistService, IJoinRepository joinRepository,
        ISelectionRepository selectionRepository, ISongSetRepository songSetRepository)
    {
        _songService = songService;
        _playlistService = playlistService;
        _joinRepository = joinRepository;
        _selectionRepository = selectionRepository;
        _songSetRepository = songSetRepository;
        InitializeComponent();
        LoadAllPlaylist();
    }

    /// <summary>
    /// Загрузить все плейлисты
    /// </summary>
    private void LoadAllPlaylist()
    {
        List<string> playlist = _selectionRepository.GetAllSelections();
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
    private void listBoxTracksOrQueue_MouseDown(object sender, MouseEventArgs e)
    {
        int indexTrack = listBoxMainTracks.IndexFromPoint(e.Location);
        int indexQueue = listBoxMainQueue.IndexFromPoint(e.Location);
        
        if (indexTrack != -1 || indexQueue != -1)
        {
            if (e.Button == MouseButtons.Left) // Выбрать песню для прослушивания
            {
                string song;
                if (indexTrack != -1)
                {
                    song = listBoxMainTracks.Items[indexTrack].ToString()!;    
                }
                else
                {
                    song = listBoxMainQueue.Items[indexQueue].ToString()!;
                }
                
                string lyrics = _songService.GetLyrics(song);
                int currentSong = _playlistService.GetCurrentSongIndex();
                List<string> playlist = _playlistService.GetCurrentPlaylist();
                int playlistIndex = _playlistService.GetCurrentPlaylistId();
                int currentQueueIndex = _playlistService.GetCurrentQueueIndex();
                
                if (currentSong == -1) // песни ещё не выбирались
                {
                    _songService.SetCurrentSong(song);
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
                    listBoxMainQueue.Items.AddRange(playlist.ToArray());
                }
                
                else if (currentQueueIndex != playlistIndex) // Трек из другого плейлиста
                {
                    _songService.SetCurrentSong(song);
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
                    listBoxMainQueue.Items.Clear();
                    listBoxMainQueue.Items.AddRange(playlist.ToArray());
                }
                
                else if (currentSong == indexTrack || currentSong == indexQueue)
                // Тот же трек из того же плейлиста или очереди
                {
                    _playlistService.PauseResume();
                }
                else if (indexQueue != currentQueueIndex) // Другой трек из той же очереди
                {
                    _songService.SetCurrentSong(song);
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
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
        int displayIndex = _playlistService.NextTrack(listBoxMainQueue.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainQueue.Items[displayIndex].ToString()!;
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
        int displayIndex = _playlistService.PreviousTrack(listBoxMainQueue.Items.Count);
        if (displayIndex != -1)
        {
            string song = listBoxMainQueue.Items[displayIndex].ToString()!;
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
                int selectionId = _selectionRepository.GetSelectionId(playlist);
                List<string> songs = _joinRepository.GetSongsBySelectionId(selectionId);
                
                _playlistService.SetCurrentPlaylist(songs);
                _playlistService.SetCurrentPlaylistId(index);
                listBoxMainTracks.Items.AddRange(songs.ToArray());
            }// Загрузка песен из плейлиста
            
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
            int currentPlaylist = _playlistService.GetCurrentPlaylistId();

            if (currentPlaylist == index)
            {
                _playlistService.DisposeWave();
                listBoxMainTracks.Items.Clear();
            }
            
            string playlist = listBoxMainPlaylists.Items[index].ToString()!;
            int selectionId = _selectionRepository.GetSelectionId(playlist);
            
            _songSetRepository.DeleteSongSet(selectionId);
            listBoxMainPlaylists.Items.Remove(playlist);
            _selectionRepository.DeleteSelection(playlist);
            _playlistService.SetCurrentPlaylistId(-1);
        }
    }
}