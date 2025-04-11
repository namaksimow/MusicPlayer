namespace MusicPlayer.Domain.Interfaces;

public interface ISongSetRepository
{
    public List<int> GetSongsFromSelection(int selectionId);
}