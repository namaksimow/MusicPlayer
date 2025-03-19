namespace MusicPlayer.DataBase.Models;

public class Song
{
    public int Id { get; set; }
    
    public string? Title { get; set; }
    
    public int Duration { get; set; }

    public string? Lyrics { get; set; }
    
    public string? UpperTitle { get; set; }

    public Song(string title, int duration, string lyrics)
    {
        Title = title;
        UpperTitle = title.ToUpper();
        Duration = duration;
        Lyrics = lyrics;
    }
}