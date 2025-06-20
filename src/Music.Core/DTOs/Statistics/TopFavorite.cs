using Music.Core.DTOs.Playlists;
using Music.Core.DTOs.Singers;
using Music.Core.DTOs.Songs;

namespace Music.Core.DTOs.Statistics
{
    public class TopFavorite
    {
        public IEnumerable<SongDto> SongList { get; set; } = [];
        public IEnumerable<PlaylistDto> PlaylistList { get; set; } = [];
        public IEnumerable<SingerDto> SingerList { get; set; } = [];
    }
}
