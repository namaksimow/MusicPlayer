using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IGenreRepository
{
    public List<string> GetAllGenres();
    
    Task Add(List<string> tags);
}