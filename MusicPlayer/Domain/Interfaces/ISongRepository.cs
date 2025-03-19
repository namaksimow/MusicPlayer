using MusicPlayer.DataBase.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface ISongRepository
{
    Task AddAsync(Song entity);
}