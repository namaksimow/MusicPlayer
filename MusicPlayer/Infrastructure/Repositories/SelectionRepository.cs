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

    public List<string> GetAllSelections()
    {
        var selections = _context.Selections.ToList();
        return selections.Select(s => s.Name).ToList()!;
    }

    public Selection GetSelection(string selectionName)
    {
        return _context.Selections.FirstOrDefault(s => s.Name == selectionName)!;
    }

    public int GetSelectionId(string name)
    {
        var selection = _context.Selections.FirstOrDefault(s => s.Name == name);
        return selection.Id;
    }

    public void DeleteSelection(string name)
    {
        var selection = _context.Selections.FirstOrDefault(s => s.Name == name);
        _context.Selections.Remove(selection);
        _context.SaveChanges();
    }
}