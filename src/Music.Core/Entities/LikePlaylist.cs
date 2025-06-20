using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Core.Entities
{
    public class LikePlaylist 
    {
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
