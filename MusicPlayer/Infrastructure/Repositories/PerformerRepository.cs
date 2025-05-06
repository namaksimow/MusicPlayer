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

    public List<string> GetPerformers()
    {
        return _context.Performers.Select(p => p.Name).ToList()!;
    }
    
    /// <summary>
    /// Добавить исполнителя
    /// </summary>
    /// <param name="entity">Объект с данными исполнителя</param>
    public async Task Add(Performer entity)
    {
        if (!Contains(entity.UpperName))
        {
            _context.Performers.Add(entity);
            await _context.SaveChangesAsync();    
        }
    }
    
    /// <summary>
    /// Существует ли данный исполнитель
    /// </summary>
    /// <param name="name">Название исполнителя для поиска</param>
    /// <returns>Null, если пользователя нет.
    /// Объект, если пользователь существует</returns>
    public Performer? Exist(string name)
    {
        return _context.Performers.FirstOrDefault(p => p.UpperName == name.ToUpper());
    }

    /// <summary>
    /// Существует ли такой пользователь
    /// </summary>
    /// <param name="name">Имя пользователя для поиска</param>
    /// <returns>False, если пользователя нет.
    /// True, если пользователь существует</returns>
    private bool Contains(string name)
    {
        return _context.Performers.Any(p => p.UpperName == name.ToUpper());
    }
}