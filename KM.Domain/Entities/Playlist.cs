namespace KM.Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public required string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public required string ImgUrl { get; set; }
        public string? PublicId { get; set; }
        public int PlayCount { get; set; }
        public bool IsPublic { get; set; } = true;
        // nav
        public string UserId { get; set; } = "";
        public AppUser? AppUser { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; } = [];
        public List<LikePlaylist> LikePlaylists { get; set; } = [];
    }
}
