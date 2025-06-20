using Music.Core.DTOs.Genres;
using Music.Core.DTOs.Singers;

namespace Music.Core.DTOs.Songs
{
    public class SongDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUrl { get; set; }
        public required string SongUrl { get; set; }
        public required string Introduction { get; set; }
        public required string Lyric { get; set; }
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset Updated { get; set; }
        public List<SingerDto> Singers { get; set; } = [];
        public List<GenreDto> Genres { get; set; } = [];
        public bool IsVip { get; set; }
    }
}
