namespace MusicPlayer.Domain.Interfaces;

public interface IGenreSetRepository
{
    Task Add(List<string> tags, int songId);
}