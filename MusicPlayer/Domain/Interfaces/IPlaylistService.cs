using MusicPlayer.UI.Forms;

namespace MusicPlayer.Domain.Interfaces;

public interface IPlaylistService
{
    public List<string> LoadPlaylist();
}