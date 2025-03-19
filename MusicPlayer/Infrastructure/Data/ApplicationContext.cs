using MusicPlayer.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace MusicPlayer.Infrastructure.Data;

public class ApplicationContext : DbContext
{
    private string _connectionString 
        = "UserId=postgres;Password=aASDnqn1k_02;Host=localhost;Port=5434;Database=MusicSelection;";

    public DbSet<Song> Songs { get; set; }
    public DbSet<User> Users { get; set; } 
    public DbSet<UserSet> UserSets { get; set; } 
    public DbSet<SongSet> SongSets { get; set; } 
    public DbSet<Selection> Selections { get; set; }
    public DbSet<Performer> Performers { get; set; } 
    public DbSet<PerformerSet> PerformerSets { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<GenreSet> GenreSets { get; set; }
    
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }
}