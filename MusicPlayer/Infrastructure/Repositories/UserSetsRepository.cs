using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class UserSetsRepository : IUserSetsRepository
{
    private readonly ApplicationContext _context;

    public UserSetsRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void AddUserSet(int userId, int songId)
    {
        UserSet userSet = new UserSet(userId, songId);
        _context.UserSets.Add(userSet);
        _context.SaveChanges();
    }

    public void DeleteUserSet(int userId, int songId)
    {
        var userSet = _context.UserSets.FirstOrDefault(u => u.UserId == userId && u.SongId == songId);
        _context.UserSets.Remove(userSet!);
        _context.SaveChanges();
    }
}