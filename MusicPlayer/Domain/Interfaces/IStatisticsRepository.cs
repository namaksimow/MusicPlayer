namespace MusicPlayer.Domain.Interfaces;

public interface IStatisticsRepository
{
    public void Add(int userId, string song, DateTime date);
}