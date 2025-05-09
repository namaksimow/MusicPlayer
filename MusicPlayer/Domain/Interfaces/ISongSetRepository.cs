namespace MusicPlayer.Domain.Interfaces;

public interface ISongSetRepository
{
    public void DeleteSongSetBySongIdSelectionId(int songId, int selectionId);
    
    public void DeleteSongSetBySongId(int songId);
    
    public void DeleteSongSetBySelectionId(int selectionId);
    
    public void AddSongSet(int selectionId, int songId);

    public void AddSongToDownloadedPlaylist(int songId, int songDuration ,int selectionId);
}