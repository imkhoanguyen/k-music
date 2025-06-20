using Music.Core.Entities.Abstracts;
using Music.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities
{
    public class Song : EntityAuditBase<int>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string? PublicImgId { get; set; }
        public string? SongUrl { get; set; }
        public string? PublicSongId { get; set; }
        [Required]
        public  string Introduction { get; set; } = string.Empty;
        [Required]
        public  string Lyric { get; set; } = string.Empty;
        public bool IsVip { get; set; } = false;
        public SongType SongType { get; set; } = SongType.Default;
        //nav
        public List<SongGenre> SongGenres { get; set; } = [];
        public List<SongSinger> SongSingers { get; set; } = [];
        public List<LikeSong> LikeSongs { get; set; } = [];
        public List<PlaylistSong> PlaylistSongs { get; set; } = [];
    }
}
