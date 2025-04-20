namespace MusicPlayer.Domain.Interfaces;

public interface IPlaylistService
{    
    public List<string> GetCurrentPlaylist();
    
    public void SetCurrentPlaylistId(int playlist);
    
    public void PlayTrack(string songToPlay);

    public void DisposeWave();
    
    public void PauseResume();

    public void VolumeChange(float volume);

    public void Rewind(int trackBarValue);
    
    public void ChangeCurrentSongIndex(int currentSong);

    public void SetCurrentPlaylist(List<string> playlist);

    public void SetCurrentQueueIndex(int queue);
    
    public int GetCurrentQueueIndex();
    
    public int GetCurrentSongIndex();
    
    public int NextTrack(int listBoxCount);
    
    public int PreviousTrack(int listBoxCount);
    
    public int GetCurrentPlaylistId();
}