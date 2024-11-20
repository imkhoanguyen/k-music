namespace KM.Application.DTOs.Playlists
{
    public class PlaylistDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public required string ImgUrl { get; set; }
        public int PlayCount { get; set; }
        public bool IsPublic { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
