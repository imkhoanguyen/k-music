﻿namespace Music.Core.DTOs.Songs
{
    public class RandomSongRequest
    {
        public IEnumerable<int> GenreIdList { get; set; } = [];
        public IEnumerable<int> SingerIdList { get; set; } = [];
    }
}
