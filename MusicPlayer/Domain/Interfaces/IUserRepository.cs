using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IUserRepository
{
    public int GetId(string login);
    
    public void Add(string name, string password, string passwordHash);
    
    public string GetPasswordByLogin(string login);
    
    public bool GetUser(string name);
}