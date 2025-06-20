using Music.Application.DTOs.Songs;
using Music.Application.Utilities;

namespace Music.Application.DTOs.Singers
{
    public class SingerDetailDto : SingerDto
    {
        public PagedList<SongDto> SongList { get; set; }
    }
}
