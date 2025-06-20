using Music.Application.DTOs.Genres;
using Music.Application.DTOs.Singers;

namespace Music.Application.DTOs.Songs
{
    public class SongDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUrl { get; set; }
        public required string SongUrl { get; set; }
        public required string Introduction { get; set; }
        public required string Lyric { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public List<SingerDto> Singers { get; set; } = [];
        public List<GenreDto> Genres { get; set; } = [];
        public bool IsVip { get; set; }
    }
}
