using KM.Application.DTOs.Songs;
using KM.Application.Utilities;

namespace KM.Application.DTOs.Singers
{
    public class SingerDetailDto : SingerDto
    {
        public PagedList<SongDto> SongList { get; set; }
    }
}
