using Music.Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Core.Entities
{
    public class Playlist : EntityAuditBase<int>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string? ImgUrl { get; set; }
        public string? PublicId { get; set; }
        public bool IsPublic { get; set; } = true;
        // nav
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; } = [];
        public List<LikePlaylist> LikePlaylists { get; set; } = [];
    }
}
