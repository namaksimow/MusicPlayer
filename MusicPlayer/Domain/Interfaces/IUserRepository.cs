using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IUserRepository
{
    public List<string> GetUsersName();
    
    public int GetUserRole(string login);
    
    public int GetId(string login);
    
    public void Add(string name, string password, string passwordHash, int isAdmin);
    
    public string GetPasswordByLogin(string login);
    
    public bool GetUser(string name);
}