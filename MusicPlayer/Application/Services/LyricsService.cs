using GeniusAPI;
using MusicPlayer.Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.Application.Services;

public class LyricsService :  ILyricsService
{
    public async Task<string> GetLyrics(string artist, string title)
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