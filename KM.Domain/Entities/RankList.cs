namespace KM.Domain.Entities
{
    public class RankList : BaseEntity
    {
        public int Score { get; set; }
        //nav
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
