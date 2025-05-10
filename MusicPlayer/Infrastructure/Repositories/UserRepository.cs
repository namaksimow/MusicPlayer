using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationContext _context;

    public UserRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<string> GetUsersName()
    {
        return _context.Users.Where(u => u.IsAdmin == 0).Select(u => u.Name).ToList();
    }
    
    public int GetUserRole(string login)
    {
        return _context.Users.FirstOrDefault(u => u.Name == login)!.IsAdmin;
    }
    
    public int GetId(string login)
    {
        var user = _context.Users.FirstOrDefault(u => u.Name == login);
        return user!.Id;
    }
    
    public void Add(string name, string password, string passwordHash, int isAdmin)
    {
        User user = new User(name, password, passwordHash, isAdmin);
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