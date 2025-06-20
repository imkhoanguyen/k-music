namespace Music.Core.DTOs.Genres
{
    public class GenreDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}
