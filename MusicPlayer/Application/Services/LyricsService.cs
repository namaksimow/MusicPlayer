using GeniusAPI;
using MusicPlayer.Domain.Interfaces;

namespace MusicPlayer.Application.Services;

public class LyricsService :  ILyricsService
{
    private readonly GeniusClient _geniusClient;

    public LyricsService(GeniusClient geniusClient)
    {
        _geniusClient = geniusClient;
    }

    public async Task<string?> GetLyrics(string artist, string title)
    {
        var trackInfo = await _geniusClient.GetTrackInfoAsync(artist, title);

        if (trackInfo != null)
        {
            string? lyrics = trackInfo.Lyrics;

            if (lyrics != null)
            {
                return lyrics;
            }
        }

        return "Song`s lyrics not found";
    }
}