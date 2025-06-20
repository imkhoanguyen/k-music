using Music.Core.DTOs.Songs;

namespace Music.Core.DTOs.Playlists
{
    public class PlaylistDetailDto1 : PlaylistDto
    {
        public List<SongHaveLikeDto> SongList { get; set; } = [];
    }
}
