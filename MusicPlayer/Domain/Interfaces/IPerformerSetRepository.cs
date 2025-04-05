namespace MusicPlayer.Domain.Interfaces;

public interface IPerformerSetRepository
{
    Task Add(int performerId, int songId);
    void DeleteSongFromPerformer(int songId);
}