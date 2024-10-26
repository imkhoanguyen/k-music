namespace KM.Domain.Entities
{
    public class LikePlaylist 
    {
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
    }
}
