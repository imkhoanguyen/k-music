namespace Music.Core.DTOs.Singers
{
    public class SingerDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Gender { get; set; }
        public required string Introduction { get; set; }
        public required string Location { get; set; }
        public required string ImgUrl { get; set; }
    }
}
