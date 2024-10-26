using KM.Domain.Enum;

namespace KM.Domain.Entities
{
    public class Singer : BaseEntity
    {
        public required string Name { get; set; }
        public Gender Gender { get; set; }
        public required string Introduction { get; set; }
        public required string Location { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public string? PublicId { get; set; }
        //nav
        public List<SongSinger> SongSingers { get; set; } = [];
        public List<Follower> Followers { get; set; } = [];
    }
}
