namespace MusicPlayer.Domain.Models;

public class UserSet
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int SongId { get; set; }

    public UserSet(int userId, int songId)
    {
        UserId = userId;
        SongId = songId;
    }
}