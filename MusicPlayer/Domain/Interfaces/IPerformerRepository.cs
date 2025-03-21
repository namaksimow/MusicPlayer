using MusicPlayer.Domain.Models;

namespace MusicPlayer.Domain.Interfaces;

public interface IPerformerRepository
{
    public Task Add(Performer entity);
    public Performer? Exist(string name);
}