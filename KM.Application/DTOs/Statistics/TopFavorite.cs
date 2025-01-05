using KM.Application.DTOs.Playlists;
using KM.Application.DTOs.Singers;
using KM.Application.DTOs.Songs;

namespace KM.Application.DTOs.Statistics
{
    public class TopFavorite
    {
        public IEnumerable<SongDto> SongList { get; set; } = [];
        public IEnumerable<PlaylistDto> PlaylistList { get; set; } = [];
        public IEnumerable<SingerDto> SingerList { get; set; } = [];
    }
}
