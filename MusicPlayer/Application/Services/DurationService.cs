﻿using MusicPlayer.Domain.Interfaces;
using NAudio.Wave;

namespace MusicPlayer.Application.Services;

public class DurationService : IDurationService
{
    public int GetDuration(string filePath)
    {
        using var reader = new MediaFoundationReader(filePath);
        return (int)reader.TotalTime.TotalSeconds;
    }
}