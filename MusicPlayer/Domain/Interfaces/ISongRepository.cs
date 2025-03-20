using MusicPlayer.DataBase.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISongRepository
{
    void Add(Song entity);
    bool Contains(string title);
}