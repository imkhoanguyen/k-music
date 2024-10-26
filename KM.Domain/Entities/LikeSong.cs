namespace KM.Domain.Entities
{
    public class LikeSong
    {
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int SongId { get; set; }
        public Song? Song { get; set; }
    }
}
