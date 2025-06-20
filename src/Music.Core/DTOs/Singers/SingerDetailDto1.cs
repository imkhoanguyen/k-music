using Music.Core.DTOs.Songs;
using Music.Core.Utilities;

namespace Music.Core.DTOs.Singers
{
    public class SingerDetailDto1 : SingerDto
    {
        public PagedList<SongHaveLikeDto> SongList { get; set; }
    }
}
