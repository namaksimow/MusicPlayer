namespace MusicPlayer.Domain.Interfaces;

public interface IJoinRepository
{
    List<string> GetSongsBySelectionId(int selectionId);
}