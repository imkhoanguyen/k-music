namespace KM.Domain.Entities
{
    public class Genre : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        //nav
        public List<SongGenre> SongGenres { get; set; } = [];
    }
}
