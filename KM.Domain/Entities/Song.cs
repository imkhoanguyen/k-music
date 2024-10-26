namespace KM.Domain.Entities
{
    public class Song : BaseEntity
    {
        public required string Name { get; set; }
        public string? ImgUrl { get; set; }
        public string? PublicImgId { get; set; }
        public string? SongUrl { get; set; }
        public string? PublicSongId { get; set; }
        public required string Introduction { get; set; }
        public required string Lyric { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public bool IsVip { get; set; } = false;
        //nav
        public List<SongGenre> SongGenres { get; set; } = [];
        public List<SongSinger> SongSingers { get; set; } = [];
        public List<LikeSong> LikeSongs { get; set; } = [];
        public List<PlaylistSong> PlaylistSongs { get; set; } = [];
    }
}
