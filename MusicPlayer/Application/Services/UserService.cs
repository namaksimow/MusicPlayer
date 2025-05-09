using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class UserService : IUserService
{
    private int UserId { get; set; }

    public int GetId()
    {
        return UserId;
    }

    public void SetId(int id)
    {
        UserId = id;
    }
}