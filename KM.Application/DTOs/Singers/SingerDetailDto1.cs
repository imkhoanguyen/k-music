using KM.Application.DTOs.Songs;
using KM.Application.Utilities;

namespace KM.Application.DTOs.Singers
{
    public class SingerDetailDto1 : SingerDto
    {
        public PagedList<SongHaveLikeDto> SongList { get; set; }
    }
}
