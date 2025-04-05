using MusicPlayer.Domain.Interfaces;
using Newtonsoft.Json.Linq;

namespace MusicPlayer.Application.Services;

public class TagService : ITagService
{
    private readonly string _apiKey = "e1ee6c709f10d650910e0efe472d70e4";

    public async Task<List<string>> GetTags(string artist, string title)
    {
        List<string> artistTags = await GetArtistTags(artist);
        List<string> trackTags = await GetTrackTags(artist, title);
        List<string> tags = await DefineTrackTags(trackTags, artistTags);
        
        return tags;
    }

    /// <summary>
    /// Получить жанры у артиста
    /// </summary>
    /// <param name="artist">Имя артиста</param>
    /// <returns>Список жанров</returns>
    public async Task<List<string>> GetArtistTags(string artist)
    {
        string url = $"https://ws.audioscrobbler.com/2.0/?method=artist.getTopTags&artist={Uri.EscapeDataString(artist)}&api_key={_apiKey}&format=json";
        return await FetchTags(url);
    }

    /// <summary>
    /// Получить жанры
    /// </summary>
    /// <param name="artist">Имя артиста</param>
    /// <param name="title">Название песни</param>
    /// <returns>Список общих жанров</returns>
    public async Task<List<string>> GetTrackTags(string artist, string title)
    {
        string url = $"http://ws.audioscrobbler.com/2.0/?method=track.gettoptags&artist={Uri.EscapeDataString(artist)}&track={Uri.EscapeDataString(title)}&api_key={_apiKey}&format=json";
        
        return await FetchTags(url);
    }
    
    /// <summary>
    /// Поиск жанров
    /// </summary>
    /// <param name="url">Api ссылка</param>
    /// <returns></returns>
    private async Task<List<string>> FetchTags(string url)
    {
        using HttpClient client = new HttpClient();
        
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();

        string json = await response.Content.ReadAsStringAsync();
        JObject parsedJson = JObject.Parse(json);
        
        JToken? tags = parsedJson["toptags"]?["tag"];
        
        if (tags != null && tags.HasValues)
        {
            // Отбираем только популярные теги. Будем считать тег популярным,
            // если у него свойство count больше или равно 50 
            List<string> popularTags = tags
                .Where(tag => (int?)tag["count"] >= 50)
                .Select(tag => (string)tag["name"])
                .ToList();

            return popularTags;
        }

        return null;
    }

    /// <summary>
    /// Определяем общие теги 
    /// </summary>
    /// <param name="trackTags">Список тегов для артиста</param>
    /// <param name="artistTags">Список тегов для песни</param>
    /// <returns></returns>
    private async Task<List<string>> DefineTrackTags(List<string> trackTags, List<string> artistTags)
    {
        // Если один из списков null, то для песни дадим теги не null списка
        if (trackTags == null)
        {
            return artistTags;
        }

        if (artistTags == null)
        {
            return trackTags;
        }
        
        if (artistTags != null)
        {
            List<string> tags = artistTags.Intersect(trackTags).ToList();
            
            // Если список общих тегов не пустой
            if (tags.Count != 0)
            {
                return tags;
            }
            
            return artistTags;
        }

        return null;
    }
}