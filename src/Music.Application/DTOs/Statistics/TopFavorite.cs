using Music.Application.DTOs.Playlists;
using Music.Application.DTOs.Singers;
using Music.Application.DTOs.Songs;

namespace Music.Application.DTOs.Statistics
{
    public class TopFavorite
    {
        public IEnumerable<SongDto> SongList { get; set; } = [];
        public IEnumerable<PlaylistDto> PlaylistList { get; set; } = [];
        public IEnumerable<SingerDto> SingerList { get; set; } = [];
    }
}
