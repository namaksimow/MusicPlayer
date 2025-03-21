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