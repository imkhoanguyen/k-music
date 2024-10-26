namespace KM.Domain.Entities
{
    public class Comment : BaseEntity 
    {
        public required string Content { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Updated { get; set; }
        //nav
        public int SongId { get; set; }
        public Song? Song { get; set; }
        public int PlaylistId { get; set; }
        public Playlist? Playlist { get; set; }
        public int SingerId { get; set; }
        public Singer? Singer { get; set; }
    }
}
