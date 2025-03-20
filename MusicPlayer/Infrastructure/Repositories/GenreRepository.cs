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
            _context.Genres.Add(new Genre(tag));
            _context.SaveChanges();    
        }
    }
}