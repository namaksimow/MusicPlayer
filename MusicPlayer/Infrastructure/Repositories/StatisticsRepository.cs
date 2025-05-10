using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Domain.Models;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class StatisticsRepository : IStatisticsRepository
{
    private readonly ApplicationContext _context;
    private readonly ISongRepository _songRepository;
    
    public StatisticsRepository(ApplicationContext context,  ISongRepository songRepository)
    {
        _songRepository = songRepository;
        _context = context;
    }

    public void Add(int userId, string song, DateTime date)
    {
        int songId = _songRepository.GetSongId(song);
        var utcDate = DateTime.SpecifyKind(date, DateTimeKind.Utc);
        Statistics stat =  new Statistics(userId, songId, utcDate);
        _context.Statistics.Add(stat);
        _context.SaveChanges();
    }
}