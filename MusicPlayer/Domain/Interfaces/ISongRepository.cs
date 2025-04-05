using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISongRepository
{
    Task Add(Song entity);
    Song Find(string title);
    bool Contains(string title);
    void Delete(int songId);
}