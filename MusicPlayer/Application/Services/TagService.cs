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

    public async Task<List<string>> GetArtistTags(string artist)
    {
        string url = $"https://ws.audioscrobbler.com/2.0/?method=artist.getTopTags&artist={Uri.EscapeDataString(artist)}&api_key={_apiKey}&format=json";
        return await FetchTags(url);
    }

    public async Task<List<string>> GetTrackTags(string artist, string title)
    {
        string url = $"http://ws.audioscrobbler.com/2.0/?method=track.gettoptags&artist={Uri.EscapeDataString(artist)}&track={Uri.EscapeDataString(title)}&api_key={_apiKey}&format=json";
        
        return await FetchTags(url);
    }
    
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
            List<string> popularTags = tags
                .Where(tag => (int?)tag["count"] >= 50)
                .Select(tag => (string)tag["name"])
                .ToList();

            return popularTags;
        }

        return null;
    }

    private async Task<List<string>> DefineTrackTags(List<string> trackTags, List<string> artistTags)
    {
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
            
            if (tags.Count != 0)
            {
                return tags;
            }
            
            return artistTags;
        }

        return null;
    }
}