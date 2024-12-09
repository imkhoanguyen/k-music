using KM.Application.DTOs.Songs;

namespace KM.Application.DTOs.Playlists
{
    public class PlaylistDetailDto : PlaylistDto
    {
        IEnumerable<SongDto> SongList { get; set; } = [];
    }
}
