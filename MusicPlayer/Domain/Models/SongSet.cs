namespace MusicPlayer.Domain.Models;

public class SongSet
{
    public int Id { get; set; }
    
    public int SelectionId { get; set; }
    
    public int SongId { get; set; }

    public SongSet(int selectionId, int songId)
    {
        SelectionId = selectionId;
        SongId = songId;
    }
}