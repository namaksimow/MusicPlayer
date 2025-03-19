namespace MusicPlayer.DataBase.Models;

public class Performer
{
    public int Id { get; set; }
    
    public string? Name { get; set; }

    public string? UpperName { get; set; }

    public Performer(string name)
    {
        Name = name;
        UpperName = name.ToUpper();
    }
}