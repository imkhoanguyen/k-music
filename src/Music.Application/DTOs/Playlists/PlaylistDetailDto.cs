using Music.Application.DTOs.Songs;

namespace Music.Application.DTOs.Playlists
{
    public class PlaylistDetailDto : PlaylistDto
    {
        public List<SongDto> SongList { get; set; } = [];
    }
}
