namespace MusicPlayer.Domain.Interfaces;

public interface ISongSetRepository
{
    public void DeleteSongSet(int selectionId);

    public void AddSongSet(int selectionId, int songId);

    public void AddSongToDownloadedPlaylist(int songId, int selectionId = 2);
}