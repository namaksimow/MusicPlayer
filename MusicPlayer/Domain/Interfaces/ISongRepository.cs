using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISongRepository
{
    public int GetSongDuration(string title);
    
    Task Add(Song entity);
    
    Song Find(string title);
    
    bool Contains(string title);
    
    void Delete(int songId);

    int GetSongId(string title);
}