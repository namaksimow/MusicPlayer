using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISelectionRepository
{
    public List<string> GetAllSelections();
    
    public Selection GetSelection(string name);

    public int GetSelectionId(string name);

    public void DeleteSelection(string name);

    public void AddSelection(string name, int userId = 1);

    public bool Exists(string name);
}