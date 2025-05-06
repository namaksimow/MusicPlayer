using MusicPlayer.Domain.Models;
using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly ApplicationContext _context;
    
    public GenreRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<string> GetAllGenres()
    {
        return _context.Genres.Select(genre => genre.Name).ToList()!;
    }
    
    /// <summary>
    /// Добавить жанр\жанры
    /// </summary>
    /// <param name="tags">Список жанров у песни</param>
    public async Task Add(List<string> tags)
    {
        foreach (var tag in tags)
        {
            if (!Contains(tag))
            {
                _context.Genres.Add(new Genre(tag));
            }
            
            await _context.SaveChangesAsync();    
        }
    }

    /// <summary>
    /// Есть ли уже такой жанр
    /// </summary>
    /// <param name="name">Название жанра</param>
    /// <returns>False, если жанра нет.
    /// True, если жанр существует</returns>
    private bool Contains(string name)
    {
        return _context.Genres.Any(g => g.Name == name);
    }
}