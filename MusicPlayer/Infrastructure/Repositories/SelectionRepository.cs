using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class SelectionRepository : ISelectionRepository
{
    private readonly ApplicationContext _context;
    
    public SelectionRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    /// <summary>
    /// Получить все плейлисты
    /// </summary>
    /// <returns></returns>
    public List<string> GetAllSelections()
    {
        var selections = _context.Selections.ToList();
        return selections.Select(s => s.Name).ToList()!;
    }

    /// <summary>
    /// Получить плейлист по названию
    /// </summary>
    /// <param name="name">Название плейлиста</param>
    /// <returns></returns>
    public Selection GetSelection(string name)
    {
        return _context.Selections.FirstOrDefault(s => s.Name == name)!;
    }

    /// <summary>
    /// Получить плейлист по айди
    /// </summary>
    /// <param name="name">Название плейлиста</param>
    /// <returns></returns>
    public int GetSelectionId(string name)
    {
        var selection = _context.Selections.FirstOrDefault(s => s.Name == name);
        return selection!.Id;
    }

    /// <summary>
    /// Удалить плейлист 
    /// </summary>
    /// <param name="name">Название плейлиста</param>
    public void DeleteSelection(string name)
    {
        var selection = _context.Selections.FirstOrDefault(s => s.Name == name);
        _context.Selections.Remove(selection!);
        _context.SaveChanges();
    }

    /// <summary>
    /// Добавить плейлист
    /// </summary>
    /// <param name="name">Название плейлиста</param>
    /// <param name="userId">Айли пользователя</param>
    public void AddSelection(string name, int userId = 1)
    {
        // Пока айди пользователя = 1, как пустышка, до реализации регистрации и аутентификации
        Selection selection = new Selection(name, userId);
        _context.Selections.Add(selection);
        _context.SaveChanges();
    }
    
    /// <summary>
    /// Проверить существует ли такой плейлист
    /// </summary>
    /// <param name="name">Название плейлиста</param>
    /// <returns></returns>
    public bool Exists(string name)
    {
        return _context.Selections.Any(s => s.Name == name);
    }
}