namespace MusicPlayer.Domain.Interfaces;

public interface ITagService
{
    Task<List<string>> GetTags(string artist, string track);
}