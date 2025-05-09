using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISelectionRepository
{
    public void ChangeSelectionDuration(int selectionId, int duration);
    
    public List<string> GetAllSelections(int userId);

    public Selection GetSelection(string name);

    public int GetSelectionId(string name, int userId);

    public void DeleteSelection(string name);

    public void AddSelection(string name, int userId = 1);

    public bool Exists(string name);
}