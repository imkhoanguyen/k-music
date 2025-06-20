using Music.Core.DTOs.Songs;

namespace Music.Core.DTOs.Playlists
{
    public class PlaylistDetailDto : PlaylistDto
    {
        public List<SongDto> SongList { get; set; } = [];
    }
}
