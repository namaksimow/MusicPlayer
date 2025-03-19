using GeniusAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicPlayer.Application.Services;
using MusicPlayer.Domain.Interfaces;
using MusicPlayer.Infrastructure.Repositories;
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
            
        var mainForm = serviceProvider.GetRequiredService<MainForm>();
        System.Windows.Forms.Application.Run(mainForm);
    }
    
    private static IServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql("UserId=postgres;Password=aASDnqn1k_02;Host=localhost;Port=5434;Database=MusicSelection;"));

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
        services.AddScoped<MainForm>();

        return services;
    }
}