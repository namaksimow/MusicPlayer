using MusicPlayer.DataBase.Models;
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

    public void Add(List<string> tags)
    {
        foreach (var tag in tags)
        {
            if (!Contains(tag))
            {
                _context.Genres.Add(new Genre(tag));    
            }
            
            _context.SaveChanges();    
        }
    }

    private bool Contains(string name)
    {
        return _context.Genres.Any(g => g.Name == name);
    }
}