using KM.Application.DTOs.Songs;

namespace KM.Application.DTOs.Playlists
{
    public class PlaylistDetailDto1 : PlaylistDto
    {
        public List<SongHaveLikeDto> SongList { get; set; } = [];
    }
}
