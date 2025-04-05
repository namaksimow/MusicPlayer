using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class GenreSetRepository : IGenreSetRepository
{
    private readonly ApplicationContext _context;

    public GenreSetRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Удалить у выбранного жанра песню
    /// </summary>
    /// <param name="songId">Айди песни для удаления</param>
    public void DeleteSongFromGenre(int songId)
    {
        var genreSets = _context.GenreSets.Where(gs => gs.SongId == songId).ToList();

        foreach (var genreSet in genreSets)
        {
            _context.GenreSets.Remove(genreSet);
        }
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Добавить песню к выбранному жанру
    /// </summary>
    /// <param name="tags">Список жанров, которые связаны с песней</param>
    /// <param name="songId">Айди песни</param>
    public async Task Add(List<string> tags, int songId)
    {
        foreach (var tag in tags)
        {
            Genre genre = _context.Genres.FirstOrDefault(g => g.Name == tag)!;
            _context.GenreSets.Add(new GenreSet(genre.Id, songId));
        }
        
        await _context.SaveChangesAsync();
    }
}