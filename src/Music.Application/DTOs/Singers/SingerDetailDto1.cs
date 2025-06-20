using Music.Application.DTOs.Songs;
using Music.Application.Utilities;

namespace Music.Application.DTOs.Singers
{
    public class SingerDetailDto1 : SingerDto
    {
        public PagedList<SongHaveLikeDto> SongList { get; set; }
    }
}
