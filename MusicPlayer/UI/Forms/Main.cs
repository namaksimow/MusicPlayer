using Microsoft.VisualBasic.ApplicationServices;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Main : Form
{
    private readonly ISongService _songService;
    private readonly IPlaylistService _playlistService;
    private readonly IJoinRepository _joinRepository;
    private readonly ISelectionRepository _selectionRepository;
    private readonly ISongSetRepository _songSetRepository;
    private readonly ISongRepository _songRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPerformerRepository _performerRepository;
    private readonly IStatisticsRepository _statisticsRepository;

    private string _song;

    private bool _isFiltered = false;

    private readonly int _userId; 
    
    public Main(ISongService songService, IPlaylistService playlistService, IJoinRepository joinRepository,
        ISelectionRepository selectionRepository, ISongSetRepository songSetRepository,
        ISongRepository songRepository,  IGenreRepository genreRepository,  IPerformerRepository performerRepository,
        IUserService userService, IStatisticsRepository statisticsRepository)
    {
        _songService = songService;
        _playlistService = playlistService;
        _joinRepository = joinRepository;
        _selectionRepository = selectionRepository;
        _songSetRepository = songSetRepository;
        _songRepository = songRepository;
        _genreRepository = genreRepository;
        _performerRepository = performerRepository;
        _userId = userService.GetId();
        _statisticsRepository = statisticsRepository;
        InitializeComponent();
        LoadAllPlaylist();
    }

    /// <summary>
    /// Загрузить все плейлисты
    /// </summary>
    private void LoadAllPlaylist()
    {
        List<string> playlist = _selectionRepository.GetAllSelections(_userId);
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
            (int songId, int songDuration) = await _songService.AddSong(openFileDialog.FileName, _userId);

            if (songId == -1)
            {
                MessageBox.Show(@$"У вас уже добавлена эта песня");
                return;
            }
            
            string songName = _songService.GetSongName(openFileDialog.FileName);

            int downloadedId = _selectionRepository.GetSelectionId("Загруженные", _userId);
            _songSetRepository.AddSongToDownloadedPlaylist(songId, songDuration, downloadedId);
            int playlistId = _playlistService.GetCurrentPlaylistId();
            if (playlistId == 0)
            {
                listBoxMainTracks.Items.Add(songName);    
            }
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
                
                string lyrics = _songService.GetLyrics(song); // текст песни
                int currentSong = _playlistService.GetCurrentSongIndex(); // номер играющей песни
                List<string> playlist = listBoxMainTracks.Items.Cast<string>().ToList(); // набор песен из плейлиста
                int playlistIndex = _playlistService.GetCurrentPlaylistId(); // номер плейлиста
                int currentQueueIndex = _playlistService.GetCurrentQueueIndex(); // номер играющей очереди
                DateTime timeNow = DateTime.Now;
                
                string songTitle = _songService.GetSongTitle(Path.GetFileNameWithoutExtension(song));
                
                if (currentSong == -1) // песни ещё не выбирались
                {
                    _songService.SetCurrentSong(song);
                    _statisticsRepository.Add(_userId, songTitle, timeNow);
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack, indexQueue);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
                    listBoxMainQueue.Items.AddRange(playlist.ToArray());
                }
                
                else if (currentQueueIndex != playlistIndex && indexTrack != -1 || _isFiltered) // Трек из другого плейлиста
                {
                    _songService.SetCurrentSong(song);
                    _statisticsRepository.Add(_userId, songTitle, timeNow);
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack, indexQueue);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
                    listBoxMainQueue.Items.Clear();
                    listBoxMainQueue.Items.AddRange(playlist.ToArray());
                    _isFiltered = false;
                }
                
                else if (currentSong == indexTrack || currentSong == indexQueue)
                // Тот же трек из того же плейлиста или очереди
                {
                    _playlistService.PauseResume();
                }
                else  // Другой трек из той же очереди
                {
                    _songService.SetCurrentSong(song);
                    _statisticsRepository.Add(_userId, songTitle, timeNow);
                    _playlistService.DisposeWave();
                    _playlistService.PlayTrack(song);
                    textBoxMainLyrics.Text = lyrics;
                    _playlistService.ChangeCurrentSongIndex(indexTrack, indexQueue);
                    _playlistService.SetCurrentQueueIndex(playlistIndex);
                }
            }
            
            else if (e.Button == MouseButtons.Right)
            {
                listBoxMainTracks.ContextMenuStrip = contextMenuStripMainSongEdit;
                string song;
                if (indexTrack != -1)
                {
                    song = listBoxMainTracks.Items[indexTrack].ToString()!;    
                }
                else
                {
                    song = listBoxMainQueue.Items[indexQueue].ToString()!;
                }
                _song = song;
            }
        }
        else // Контекстное меню для взаимодействия с песней
        {
            listBoxMainTracks.ContextMenuStrip = null;
        }
    }
    
    /// <summary>
    /// Удаление песни из плейлиста, если песня в кастомном плейлисте, то должна удаляться только из него, а если из
    /// Downloaded, то уже тогда из всех плейлистов и все записи с этой песней из БД
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuSongDeleteClick(object sender, EventArgs e)
    {
        int index = listBoxMainTracks.SelectedIndex;
        if (index != -1)
        {
            string song = listBoxMainTracks.Items[index].ToString()!;
            string playlist = _playlistService.GetCurrentPlaylist(); // плейлист, из которого мы удаляем трек

            _playlistService.DisposeWave();
            _songService.DeleteSong(song, playlist, _userId);
            listBoxMainTracks.Items.Remove(song);
            listBoxMainQueue.Items.Remove(song);
            textBoxMainLyrics.Text = "";
        }
    }

    /// <summary>
    /// Добавить песню в плейлист
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void ToolStripMenuSongAddToPlaylistClick(object sender, EventArgs e)
    {
        AddSongToPlaylist form = new AddSongToPlaylist(_song, _selectionRepository, _songService, _songSetRepository,
            _songRepository, _userId);
        form.ShowDialog();
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
        AddPlaylist form = new AddPlaylist(_selectionRepository, _joinRepository, _songSetRepository, _genreRepository,
            _performerRepository, _userId);
        form.ShowDialog();
        string playlist = form.GetPlaylistName();
        if (playlist != null)
        {
            listBoxMainPlaylists.Items.Add(playlist);    
        }
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
                int selectionId = _selectionRepository.GetSelectionId(playlist, _userId);
                List<string> songs = _joinRepository.GetSongsBySelectionId(selectionId, _userId);
                
                _playlistService.SetPlaylistSongs(songs);
                _playlistService.SetCurrentPlaylistId(index);
                _playlistService.SetCurrentPlaylist(playlist);
                listBoxMainTracks.Items.AddRange(songs.ToArray());
            } // Загрузка песен из плейлиста
            
            else if (e.Button == MouseButtons.Right)
            {
                listBoxMainPlaylists.ContextMenuStrip = contextMenuStripMainPlaylistEdit;
            } // Контекстное меню для взаимодействия с плейлистом
        }
        else 
        {
            listBoxMainPlaylists.ContextMenuStrip = null;
        } // если курсор не на плейлисте, то не нужно вызывать меню
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
            int selectionId = _selectionRepository.GetSelectionId(playlist, _userId);
            
            _songSetRepository.DeleteSongSetBySelectionId(selectionId);
            listBoxMainPlaylists.Items.Remove(playlist);
            _selectionRepository.DeleteSelection(playlist);
            _playlistService.SetCurrentPlaylistId(-1);
        }
    }

    private void btnMainFilter_Click(object sender, EventArgs e)
    {
        bool playlistOpen = listBoxMainTracks.Items.Count > 0;
        List<string> songs = listBoxMainTracks.Items.Cast<string>().ToList();
        
        if (playlistOpen)
        {
            Filter form = new Filter(_playlistService.GetCurrentPlaylist(), songs, _selectionRepository,
                _joinRepository, _genreRepository, _performerRepository, _userId);
            form.ShowDialog();
            
            List<string> filteredSongs = form.GetFilterSongs();
            
            _isFiltered = true;
            listBoxMainTracks.Items.Clear();
            listBoxMainTracks.Items.AddRange(filteredSongs.ToArray());
        }
        else
        {
            MessageBox.Show(@"Нельзя применить фильтры к пустому плейлисту");   
        }
    }

    private void btnMainGetStat_Click(object sender, EventArgs e)
    {
        GetStatistics form = new GetStatistics(_userId, _joinRepository);
        form.ShowDialog();
    }
}