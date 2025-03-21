using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IGenreRepository
{
    Task Add(List<string> tags);
}