namespace MusicPlayer.DataBase.Models;

public class PerformerSet
{
    public int Id { get; set; }
    
    public int PerformerId { get; set; }
    
    public int SongId { get; set; }

    public PerformerSet(int performerId, int songId)
    {
        PerformerId = performerId;
        SongId = songId;
    }
}