using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IPerformerRepository
{
    public List<string> GetPerformers();
    public Task Add(Performer entity);
    public Performer? Exist(string name);
}