using MusicPlayer.Domain.Models;
using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class PerformerRepository : IPerformerRepository
{
    private readonly ApplicationContext _context;

    public PerformerRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task Add(Performer entity)
    {
        if (!Contains(entity.UpperName))
        {
            _context.Performers.Add(entity);
            await _context.SaveChangesAsync();    
        }
    }
    
    public Performer? Exist(string name)
    {
        return _context.Performers.FirstOrDefault(p => p.UpperName == name.ToUpper());
    }

    private bool Contains(string name)
    {
        return _context.Performers.Any(p => p.UpperName == name.ToUpper());
    }
}