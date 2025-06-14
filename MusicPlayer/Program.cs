using GeniusAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicPlayer.Application.Services;
using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Infrastructure.Repositories;
using MusicPlayer.UI.Forms;
using ApplicationContext = MusicPlayer.Infrastructure.Data.ApplicationContext;  

namespace MusicPlayer;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = ConfigureServices();
        using var serviceProvider = services.BuildServiceProvider();
            
        var regAndAuth = serviceProvider.GetService<RegAndAuth>();
        var result = regAndAuth.ShowDialog();
        int role = regAndAuth.Role;
        
        if (result == DialogResult.OK && role == 0)
        {
            var main = serviceProvider.GetRequiredService<Main>();
            System.Windows.Forms.Application.Run(main);    
        }
        else if (role == 1)
        {
            var admin = serviceProvider.GetRequiredService<Admin>();
            System.Windows.Forms.Application.Run(admin);
        }
    }
    
    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(":)"));

        services.AddScoped<Admin>();
        services.AddScoped<RegAndAuth>();
        services.AddScoped<ISongService, SongService>();
        services.AddSingleton<GeniusClient>(provider =>
        {
            string accessToken = "y20k-ih6uzRLeiNsq0QLFb8Tl5b8ySYHY_re7E8InIc3oFBjMh-_mavWHPaHv3Gg";
            return new GeniusClient(accessToken);
        });
        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddScoped<IDurationService, DurationService>();
        services.AddScoped<ILyricsService, LyricsService>();
        services.AddScoped<ITagService, TagService>();
        services.AddScoped<ISongRepository, SongRepository>();
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<IPerformerRepository, PerformerRepository>();
        services.AddScoped<IGenreSetRepository, GenreSetRepository>();
        services.AddScoped<IPerformerSetRepository, PerformerSetRepository>();
        services.AddScoped<IPlaylistService, PlaylistService>();
        services.AddScoped<ISelectionRepository, SelectionRepository>();
        services.AddScoped<IJoinRepository, JoinRepository>();
        services.AddScoped<ISongSetRepository, SongSetRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUserSetsRepository, UserSetsRepository>();
        services.AddScoped<IStatisticsRepository, StatisticsRepository>();
        services.AddScoped<Main>();

        return services;
    }
}