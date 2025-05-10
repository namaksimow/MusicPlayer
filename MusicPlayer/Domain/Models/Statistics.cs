namespace MusicPlayer.Domain.Models;

public class Statistics
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public int SongId { get; set; }
    
    public DateTime Date { get; set; }
    
    public Statistics(int userId, int songId, DateTime date)
    {
        UserId = userId;
        SongId = songId;
        Date = date;
    }
}