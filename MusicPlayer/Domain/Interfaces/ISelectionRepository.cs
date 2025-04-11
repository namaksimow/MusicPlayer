using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISelectionRepository
{
    public List<Selection> GetAllSelections();
    
    public Selection GetSelection(string selectionName);
}