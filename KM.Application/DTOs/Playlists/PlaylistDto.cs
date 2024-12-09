namespace KM.Application.DTOs.Playlists
{
    public class PlaylistDto
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required DateTime Created { get; set; }
        public required DateTime Updated { get; set; }
        public required string ImgUrl { get; set; }
        public required int PlayCount { get; set; }
        public required bool IsPublic { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
