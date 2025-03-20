using MusicPlayer.DataBase.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IGenreRepository
{
    void Add(List<string> tags);
}