namespace MusicPlayer.Domain.Interfaces;

public interface IUserSetsRepository
{
    public void DeleteUserSet(int userId, int songId);
    
    public void AddUserSet(int userId, int songId);
}