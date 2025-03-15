namespace MusicPlayer.DataBase.Models;

public class GenreSet
{
    public int Id { get; set; }
    
    public int GenreId { get; set; }
    
    public int SongId { get; set; }

    public GenreSet(int genreId, int songId)
    {
        GenreId = genreId;
        SongId = songId;
    }
}