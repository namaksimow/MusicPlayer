namespace MusicPlayer.Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? NormalizedName { get; set; }

    public string? Password { get; set; }

    public string? PasswordHash { get; set; }
    
    public int IsAdmin { get; set; }
    
    public User(string name, string password, string passwordHash, int isAdmin)
    {
        Name = name;
        NormalizedName = name.ToUpper();
        Password = password;
        PasswordHash = passwordHash;
        IsAdmin = isAdmin;
    }
}