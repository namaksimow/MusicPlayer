﻿namespace MusicPlayer.Domain.Interfaces;

public interface IPerformerSetRepository
{
    Task Add(int performerId, int songId);
}