using MusicPlayer.Domain.Interfaces;
using MusicPlayer.UI.Forms;

namespace MusicPlayer.Application.Services;

public class PlaylistService : IPlaylistService
{
    public List<string> LoadPlaylist()
    {
        DirectoryInfo dinfo = new DirectoryInfo(@"C:\notSystem\vcs\MusicPlayer\MusicPlayer\Tracks");
        FileInfo[] files = dinfo.GetFiles("*.mp3");
        return files.Select(f => f.Name).ToList();
    }
}