namespace MusicPlayer.Domain.Interfaces;

public interface IPlaylistService
{
    public List<string> LoadPlaylist();
    
    public void PlayTrack(string songToPlay);

    public void DisposeWave();
    
    public void PauseResume();

    public void VolumeChange(float volume);

    public void Rewind(int trackBarValue);
    
    public void ChangeDisplayIndex(int newDisplayIndex);

    public int GetDisplayIndex();
    
    public int NextTrack(int listBoxCount);
    
    public int PreviousTrack(int listBoxCount);
}