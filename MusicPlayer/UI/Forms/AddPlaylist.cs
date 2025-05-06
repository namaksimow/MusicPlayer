using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class AddPlaylist : Form
{
    private readonly ISelectionRepository _selectionRepository;
    private readonly IJoinRepository _joinRepository;
    private readonly ISongSetRepository _songSetRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPerformerRepository _performerRepository;
    
    private string PlaylistName { get; set; }
    
    public AddPlaylist(ISelectionRepository selectionRepository, IJoinRepository joinRepository, 
        ISongSetRepository songSetRepository, IGenreRepository genreRepository,
        IPerformerRepository performerRepository)
    {
        _selectionRepository = selectionRepository;
        _joinRepository = joinRepository;
        _songSetRepository = songSetRepository;
        _genreRepository = genreRepository;
        _performerRepository = performerRepository;
        InitializeComponent();
        LoadPerformers();
        LoadGenres();
    }

    private void LoadPerformers()
    {
        List<string> performers = _performerRepository.GetPerformers();
        listBoxAPPickPerformer.Items.AddRange(performers.ToArray());
    }
    
    private void LoadGenres()
    {
        List<string> genres = _genreRepository.GetAllGenres();
        listBoxAPPickGenre.Items.AddRange(genres.ToArray());
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
            MessageBox.Show(@"Пожалуйста, введите название плейлиста");
            return;
        }
        bool isExists = _selectionRepository.Exists(playlistName);
        if (isExists)
        {
            MessageBox.Show(@"У вас уже существует такой плейлист");
            return;
        }
        int durationFrom = int.Parse(textBoxAPDurationFrom.Text);
        int durationTo = int.Parse(textBoxAPDurationTo.Text);
        int countPickedGenres = listBoxAPPickedGenre.Items.Count;
        int countPickedPerformers = listBoxAPPickedPerformer.Items.Count;
        int selectionId = 2; // айди плейлиста со всеми загруженными песнями у каждого пользователя
        List<int> songs = null; // список, в котором будут находиться айди будущих песен для плейлиста
        
        if (countPickedGenres == 0 && countPickedPerformers == 0)
        {
            if (durationFrom == 0 && durationTo == 0)
            {
                songs = null;
            }
            
            else if (durationFrom == 0)
            {
                songs = _joinRepository.GetSongsIdByDurationTo(selectionId, durationTo);
            }

            else if (durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByDurationFrom(selectionId, durationFrom);   
            }

            else 
            {
                songs = _joinRepository.GetSongsIdByDurationFromAndTo(selectionId, durationFrom, durationTo);   
            }
        }
        else if (countPickedGenres == 0)
        {
            List<string> performers = listBoxAPPickedPerformer.Items.Cast<string>().ToList();
            
            if (durationFrom == 0 && durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByPerformerList(selectionId, performers);
            }   
            
            else if (durationFrom == 0)
            {
                songs = _joinRepository.GetSongsIdByPerformerListDurationTo(selectionId, durationTo, performers);
            }
            
            else if (durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByPerformerListDurationFrom(selectionId, durationTo, performers);
            }

            else
            {
                songs = _joinRepository.GetSongsIdByPerformerListDurationFromAndTo(selectionId, durationFrom, 
                    durationTo, performers);   
            }
        }
        else if (countPickedPerformers == 0)
        {
            List<string> genres = listBoxAPPickedGenre.Items.Cast<string>().ToList();
            
            if (durationFrom == 0 && durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByGenreList(selectionId, genres);
            }
            
            else if (durationFrom == 0)
            {
                songs = _joinRepository.GetSongsIdByGenreListDurationTo(selectionId, durationTo, genres);
            }
            
            else if (durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByGenreListDurationFrom(selectionId, durationFrom, genres);   
            }

            else
            {
                songs = _joinRepository.GetSongsIdByGenreListDurationFromAndTo(selectionId, durationFrom,
                    durationTo, genres);
            }
        }
        else
        {
            List<string> performers = listBoxAPPickedPerformer.Items.Cast<string>().ToList();
            List<string> genres = listBoxAPPickedGenre.Items.Cast<string>().ToList();

            if (durationFrom == 0 && durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByGenrePerformerList(selectionId, genres, performers);
            }
            
            else if (durationFrom == 0)
            {
                songs = _joinRepository.GetSongsIdByGenrePerformerListDurationTo(
                    selectionId, durationTo,
                    genres, performers);
            }
            
            else if (durationTo == 0)
            {
                songs = _joinRepository.GetSongsIdByGenrePerformerListDurationFrom(
                    selectionId, durationFrom, 
                    genres, performers);
            }

            else
            {
                songs = _joinRepository.GetSongsIdByGenrePerformerListDurationFromAndTo(
                    selectionId, durationFrom,
                    durationTo, genres,
                    performers);
            }
        }
        
        PlaylistName = playlistName;
        _selectionRepository.AddSelection(playlistName);
        int newSelectionId = _selectionRepository.GetSelectionId(playlistName);
        if (songs != null)
        {
            foreach (int songId in songs)
            {
                _songSetRepository.AddSongSet(newSelectionId, songId);
            }    
        }
        MessageBox.Show(@"Плейлист добавлен");
        Close();   
    }

    private void listBoxAPPickGenre_MouseDown(object sender, MouseEventArgs e)
    {
        int indexGenre = listBoxAPPickGenre.IndexFromPoint(e.Location);

        if (indexGenre != -1)
        {
            string genre = listBoxAPPickGenre.Items[indexGenre].ToString()!;
            listBoxAPPickedGenre.Items.Add(genre);
            listBoxAPPickGenre.Items.Remove(genre);
        }
    }

    private void listBoxAPPickedGenre_MouseDown(object sender, MouseEventArgs e)
    {
        int indexGenre = listBoxAPPickedGenre.IndexFromPoint(e.Location);

        if (indexGenre != -1)
        {
            string genre = listBoxAPPickedGenre.Items[indexGenre].ToString()!;
            listBoxAPPickGenre.Items.Add(genre);
            listBoxAPPickedGenre.Items.Remove(genre);
        }
    }

    private void listBoxAPPickPerformer_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPerformer = listBoxAPPickPerformer.IndexFromPoint(e.Location);

        if (indexPerformer != -1)
        {
            string performer = listBoxAPPickPerformer.Items[indexPerformer].ToString()!;
            listBoxAPPickPerformer.Items.Remove(performer);
            listBoxAPPickedPerformer.Items.Add(performer);
        }
    }

    private void listBoxAPPickedPerformer_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPerformer = listBoxAPPickedPerformer.IndexFromPoint(e.Location);

        if (indexPerformer != -1)
        {
            string performer = listBoxAPPickedPerformer.Items[indexPerformer].ToString()!;
            listBoxAPPickedPerformer.Items.Remove(performer);
            listBoxAPPickPerformer.Items.Add(performer);
        }
    }
}