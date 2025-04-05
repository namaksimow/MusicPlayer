using GeniusAPI;
using MusicPlayer.Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.Application.Services;

public class LyricsService :  ILyricsService
{
    /// <summary>
    /// Получить текст песни. Скорее всего для русских песен будет плохо искать текст
    /// </summary>
    /// <param name="artist">Имя артиста</param>
    /// <param name="title">Название песни</param>
    /// <returns>Строку с текстом, либо текст не найден</returns>
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