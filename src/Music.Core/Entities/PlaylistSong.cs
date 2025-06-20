﻿namespace Music.Core.Entities
{
    public class PlaylistSong
    {
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public int SongId { get; set; }
        public Song? Song { get; set; }
        public PlaylistSong(int playlistId, int songId)
        {
            PlaylistId = playlistId;
            SongId = songId;
        }
    }
}
