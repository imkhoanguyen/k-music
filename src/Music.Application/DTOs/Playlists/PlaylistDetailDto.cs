using KM.Application.DTOs.Songs;

namespace KM.Application.DTOs.Playlists
{
    public class PlaylistDetailDto : PlaylistDto
    {
        public List<SongDto> SongList { get; set; } = [];
    }
}
