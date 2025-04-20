using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISelectionRepository
{
    public List<string> GetAllSelections();
    
    public Selection GetSelection(string selectionName);

    public int GetSelectionId(string name);

    public void DeleteSelection(string name);
}