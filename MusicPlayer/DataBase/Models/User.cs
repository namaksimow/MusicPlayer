namespace MusicPlayer.DataBase.Models;

public class User
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? NormalizedName { get; set; }

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }
    
    public User(string name, string password, string passwordHash)
    {
        Name = name;
        NormalizedName = name.ToUpper();
        Password = password;
        PasswordHash = passwordHash;
    }
}