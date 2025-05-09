using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    private int currentUserId { get; set; }

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public int GetCurrentUserId()
    {
        return currentUserId;
    }
    
    public int GetId(string login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == login);
        return user!.Id;
    }
    
    public void Add(string name, string password, string passwordHash)
    {
        User user = new User(name, password, passwordHash);
        _context.Users.Add(user);
        _context.SaveChanges();
    }
    
    public bool GetUser(string name)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == name);
        if (user == null)
        {
            return false;
        }
        
        return true;
    }

    public string GetPasswordByLogin(string login)
    {
        return _context.Users.FirstOrDefault(u => u.Name == login)!.PasswordHash!;
    }
}