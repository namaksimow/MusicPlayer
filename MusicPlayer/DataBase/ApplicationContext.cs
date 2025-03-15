using MusicPlayer.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicPlayer.DataBase;

public class ApplicationContext : DbContext
{
    private string _connectionString 
        = "UserId=postgres;Password=aASDnqn1k_02;Host=localhost;Port=5434;Database=MusicSelection;";
    
    public DbSet<Song> Songs { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserSet> UserSets { get; set; } = null!;
    public DbSet<SongSet> SongSets { get; set; } = null!;
    public DbSet<Selection> Selections { get; set; } = null!;
    public DbSet<Performer> Performers { get; set; } = null!;
    public DbSet<PerformerSet> PerformerSets { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<GenreSet> GenreSets { get; set; } = null!;
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}