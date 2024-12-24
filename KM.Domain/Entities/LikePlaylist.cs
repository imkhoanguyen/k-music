using System.ComponentModel.DataAnnotations.Schema;

namespace KM.Domain.Entities
{
    public class LikePlaylist 
    {
        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
