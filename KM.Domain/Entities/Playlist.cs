using System.ComponentModel.DataAnnotations.Schema;

namespace KM.Domain.Entities
{
    public class Playlist : BaseEntity
    {
        public required string Name { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string? PublicId { get; set; }
        public int PlayCount { get; set; }
        public bool IsPublic { get; set; } = true;
        // nav
        public string UserId { get; set; } = "";
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; } = [];
        public List<LikePlaylist> LikePlaylists { get; set; } = [];
    }
}
