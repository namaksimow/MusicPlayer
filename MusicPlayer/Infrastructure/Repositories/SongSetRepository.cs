namespace MusicPlayer.Infrastructure.Repositories;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

public class SongSetRepository
{
    private readonly ApplicationContext _context;

    public SongSetRepository(ApplicationContext context)
    {
        _context = context;
    }

    public List<int> GetSongsFromSelection(int selectionId)
    {
        List<int> songs = _context.SongSets.Where(ss => ss.SelectionId == selectionId).Select(ss => ss.SongId).ToList();
        return songs;
    }
}