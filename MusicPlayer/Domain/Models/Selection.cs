namespace MusicPlayer.Domain.Models;

public class Selection
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public int UserId { get; set; }
    
    public int Duration { get; set; }

    public Selection(string name, int userId)
    {
        Name = name;
        UserId = userId;
    }
}