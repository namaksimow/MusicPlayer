using MusicPlayer.Domain.Interfaces;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;

namespace MusicPlayer.Infrastructure.Repositories;

public class SongSetRepository :  ISongSetRepository
{
    private readonly ApplicationContext _context;

    public SongSetRepository(ApplicationContext context)
    {
        _context = context;
    }

    public void DeleteSongSet(int selectionId)
    {
        var songSet = _context.SongSets.Where(s => s.SelectionId == selectionId).ToList();
        foreach (var set in songSet)
        {
            _context.SongSets.Remove(set);
        }
        _context.SaveChanges();
    } 
}