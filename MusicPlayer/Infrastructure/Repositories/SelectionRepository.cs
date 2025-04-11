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

    public List<Selection> GetAllSelections()
    {
        return _context.Selections.ToList();
    }

    public Selection GetSelection(string selectionName)
    {
        return _context.Selections.FirstOrDefault(s => s.Name == selectionName)!;
    }
}