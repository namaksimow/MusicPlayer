using GeniusAPI;
using GeniusAPI.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MusicPlayer.Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.Application.Services;

public class LyricsService :  ILyricsService
{
    private const string AccessTokenGenius = "RcTKjFhgR62TD47uH9kHvtGAD66fCJx-5bFYY1LgO7WjjtI4Bjg7IR1itoHeN_aG";
    private readonly GeniusClient _geniusClient;
    
    public LyricsService()
    {
        GeniusClient geniusClient = new GeniusClient(AccessTokenGenius);
        _geniusClient = geniusClient;
    }
    
    /// <summary>
    /// Получить текст песни. Скорее всего для русских песен будет плохо искать текст
    /// </summary>
    /// <param name="artist">Имя артиста</param>
    /// <param name="title">Название песни</param>
    /// <returns>Строку с текстом, либо текст не найден</returns>
    public async Task<string> GetLyrics(string artist, string title)
    {
        string lyrics = await GetLyricsGenius(_geniusClient, artist, title);
        return lyrics;
    }

    private async Task<string> GetLyricsGenius(GeniusClient client, string artist, string title)
    {
        GeniusTrackInfo? trackInfo = await client.GetTrackInfoAsync(title, artist);

        if (trackInfo != null)
        {
            string? lyrics = trackInfo.Lyrics;
            return lyrics;
        }
        
        return null;
    }

    private async Task<string> GetLyricsOvh(string artist, string title)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"https://api.lyrics.ovh/v1/{Uri.EscapeDataString(artist)}/{Uri.EscapeDataString(title)}";

            HttpResponseMessage response = await client.GetAsync(url);
                
            if (!response.IsSuccessStatusCode)
                return "Текст не найден";
                
            string json = await response.Content.ReadAsStringAsync();
            JObject data = JObject.Parse(json);
            return data["lyrics"]?.ToString();
        }
    }
    
}