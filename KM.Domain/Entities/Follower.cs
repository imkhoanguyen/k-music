namespace KM.Domain.Entities
{
    public class Follower
    {
        public required string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int SingerId { get; set; }
        public Singer? Singer { get; set; }
    }
}
