using Music.Core.DTOs.Songs;
using Music.Core.Utilities;

namespace Music.Core.DTOs.Singers
{
    public class SingerDetailDto : SingerDto
    {
        public PagedList<SongDto> SongList { get; set; }
    }
}
