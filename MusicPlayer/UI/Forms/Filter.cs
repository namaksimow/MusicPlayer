using System.ComponentModel.Design;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.UI.Forms;

public partial class Filter : Form
{
    private readonly string _currentSelection; 
    private readonly ISelectionRepository _selectionRepository;
    private readonly IJoinRepository _joinRepository;
    private readonly IGenreRepository _genreRepository;
    private readonly IPerformerRepository _performerRepository;
    
    private List<string> _songs;
    
    public Filter(string currentSelection, List<string> songs, ISelectionRepository selectionRepository, 
        IJoinRepository joinRepository,  IGenreRepository genreRepository, IPerformerRepository performerRepository)
    {
        _currentSelection = currentSelection;
        _selectionRepository = selectionRepository;
        _joinRepository = joinRepository;
        _genreRepository = genreRepository;
        _performerRepository = performerRepository;
        _songs = songs;
        InitializeComponent();
        LoadGenres();
        LoadPerformers();
    }

    private void LoadPerformers()
    {
        List<string> performers = _performerRepository.GetPerformers();
        listBoxFilterPickPerformer.Items.AddRange(performers.ToArray());
    }
    
    private void LoadGenres()
    {
        List<string> genres = _genreRepository.GetAllGenres();
        listBoxFilterPickGenre.Items.AddRange(genres.ToArray());
    }
    
    public List<string> GetFilterSongs()
    {
        return _songs;
    }
    
    private void lblFilterBySongNameAscending_Click(object sender, EventArgs e)
    {
        _songs = _songs.OrderBy(s => s).ToList();
        Close();
    }

    private void lblFilterBySongNameDescending_Click(object sender, EventArgs e)
    {
        _songs = _songs.OrderByDescending(s => s).ToList();
        Close();
    }

    private void lblFilterClearFilter_Click(object sender, EventArgs e)
    {
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        List<string> songs = _joinRepository.GetSongsBySelectionId(selectionId);
        _songs = songs;
        Close();
    }

    private void lblFilterByPerformerAscending_Click(object sender, EventArgs e)
    {
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        List<string> songs = _joinRepository.GetSongsByPerformerAscending(selectionId);
        _songs = songs;
        Close();
    }

    private void lblFilterByPerformerDescending_Click(object sender, EventArgs e)
    {
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        List<string> songs = _joinRepository.GetSongsByPerformerDescending(selectionId);
        _songs = songs;
        Close();
    }

    private void lblFilterByDurationAscending_Click(object sender, EventArgs e)
    {
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        List<string> songs = _joinRepository.GetSongsByDurationAscending(selectionId);
        _songs = songs;
        Close();
    }


    private void lblFilterByDurationDescending_Click(object sender, EventArgs e)
    {
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        List<string> songs = _joinRepository.GetSongsByDurationDescending(selectionId);
        _songs = songs;
        Close();
    }
    
    private void listBoxFilterPickGenre_MouseDown(object sender, MouseEventArgs e)
    {
        int indexGenre = listBoxFilterPickGenre.IndexFromPoint(e.Location);

        if (indexGenre != -1)
        {
            string genre = listBoxFilterPickGenre.Items[indexGenre].ToString()!;
            listBoxFilterPickedGenre.Items.Add(genre);
            listBoxFilterPickGenre.Items.Remove(genre);
        }
    }

    private void listBoxFilterPickedGenre_MouseDown(object sender, MouseEventArgs e)
    {
        int indexGenre = listBoxFilterPickedGenre.IndexFromPoint(e.Location);

        if (indexGenre != -1)
        {
            string genre = listBoxFilterPickedGenre.Items[indexGenre].ToString()!;
            listBoxFilterPickGenre.Items.Add(genre);
            listBoxFilterPickedGenre.Items.Remove(genre);
        }
    }

    private void listBoxFilterPickPerformer_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPerformer = listBoxFilterPickPerformer.IndexFromPoint(e.Location);

        if (indexPerformer != -1)
        {
            string performer = listBoxFilterPickPerformer.Items[indexPerformer].ToString()!;
            listBoxFilterPickPerformer.Items.Remove(performer);
            listBoxFilterPickedPerformer.Items.Add(performer);
        }
    }

    private void listBoxFilterPickedPerformer_MouseDown(object sender, MouseEventArgs e)
    {
        int indexPerformer = listBoxFilterPickedPerformer.IndexFromPoint(e.Location);

        if (indexPerformer != -1)
        {
            string performer = listBoxFilterPickedPerformer.Items[indexPerformer].ToString()!;
            listBoxFilterPickedPerformer.Items.Remove(performer);
            listBoxFilterPickPerformer.Items.Add(performer);
        }
    }

    private void btnFilterFilter_Click(object sender, EventArgs e)
    {
        // это будут сложные фильтры, которые будут применяться только к изначальным плейлистам
        int durationFrom = int.Parse(textBoxFilterDurationFrom.Text); // минимальная длительность песни
        int durationTo = int.Parse(textBoxFilterDurationTo.Text); // максимальная длительность песни
        int countPickedGenres = listBoxFilterPickedGenre.Items.Count; // количество выбранных жанров
        int countPickedPerformers = listBoxFilterPickedPerformer.Items.Count; // количество выбранных исполнителей
        int selectionId = _selectionRepository.GetSelectionId(_currentSelection);
        
        if (countPickedGenres == 0 && countPickedPerformers == 0) // фильтруем только по длительности
        {
            if (durationFrom == 0 && durationTo == 0) // всё равно на длительность песен, то есть по сути этот блок это
            // плейлист без фильтров
            {
                List<string> songs = _joinRepository.GetSongsBySelectionId(selectionId);
                _songs = songs;
                Close();
            }
            
            else if (durationFrom == 0) // когда мы задаём только максимальную длительность
            {
                List<string> songs = _joinRepository.GetSongsByDurationTo(selectionId, durationTo);
                _songs = songs;
                Close();
            }
            
            else if (durationTo == 0) // когда мы задаём только минимальную длительность
            {
                List<string> songs = _joinRepository.GetSongsByDurationFrom(selectionId, durationFrom);
                _songs = songs;
                Close();
            }

            else // когда мы задаём и максимальную, и минимальную длительность
            {
                List<string> songs = _joinRepository.GetSongsByDurationToAndFrom(selectionId, durationFrom, durationTo);
                _songs = songs;
                Close();
            }
        }
        
        else if (countPickedGenres == 0) // фильтруем по исполнителя и длительности
        {
            List<string> performers = listBoxFilterPickedPerformer.Items.Cast<string>().ToList();
            
            if (durationFrom == 0 && durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByPerformerList(selectionId, performers);
                _songs = songs;
                Close();
            }
            
            else if (durationFrom == 0)
            {
                List<string> songs = _joinRepository.GetSongsByPerformerListDurationTo(selectionId, durationTo,
                    performers);
                _songs = songs;
                Close();
            }
            
            else if (durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByPerformerListDurationFrom(selectionId,
                    durationFrom, performers);
                _songs = songs;
                Close();
            }

            else
            {
                List<string> songs = _joinRepository.GetSongsByPerformerListDurationToAndFrom(selectionId, durationFrom,
                    durationTo, performers);
                _songs = songs;
                Close();
            }
        }
        
        else if (countPickedPerformers == 0) // фильтруем по жанрам и длительности  
        {
            List<string> genres = listBoxFilterPickedGenre.Items.Cast<string>().ToList();
            
            if (durationFrom == 0 && durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByGenreList(selectionId, genres);
                _songs = songs;
                Close();
            }
            
            else if (durationFrom == 0)
            {
                List<string> songs = _joinRepository.GetSongsByGenreListDurationTo(selectionId, durationTo, genres);
                _songs = songs;
                Close();
            }
            
            else if (durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByGenreListDurationFrom(selectionId, durationFrom, genres);
                _songs = songs;
                Close();
            }

            else
            {
                List<string> songs = _joinRepository.GetSongsByGenreListDurationToAndFrom(selectionId, durationFrom,
                    durationTo, genres);
                _songs = songs;
                Close();
            }
        }

        else // когда в фильтрах все три параметра
        {
            List<string> genres = listBoxFilterPickedGenre.Items.Cast<string>().ToList();
            List<string> performers = listBoxFilterPickedPerformer.Items.Cast<string>().ToList();
            
            if (durationFrom == 0 && durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByGenrePerformerList(selectionId, genres, performers);
                _songs = songs;
                Close();
            }

            else if (durationFrom == 0)
            {
                List<string> songs =
                    _joinRepository.GetSongsByGenrePerformerListDurationTo(selectionId, durationTo, genres, performers);
                _songs = songs;
                Close();
            }

            else if (durationTo == 0)
            {
                List<string> songs = _joinRepository.GetSongsByGenrePerformerListDurationFrom(selectionId, durationFrom,
                    genres, performers);
                _songs = songs;
                Close();
            }

            else
            {
                List<string> songs = _joinRepository.GetSongsByGenrePerformerListDurationToAndFrom(selectionId, 
                    durationFrom, durationTo, genres, performers);
                _songs = songs;
                Close();
            }
        }
    }
}