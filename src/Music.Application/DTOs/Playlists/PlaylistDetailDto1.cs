using Music.Application.DTOs.Songs;

namespace Music.Application.DTOs.Playlists
{
    public class PlaylistDetailDto1 : PlaylistDto
    {
        public List<SongHaveLikeDto> SongList { get; set; } = [];
    }
}
