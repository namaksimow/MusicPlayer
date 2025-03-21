using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISongRepository
{
    Task Add(Song entity);
    bool Contains(string title);
}