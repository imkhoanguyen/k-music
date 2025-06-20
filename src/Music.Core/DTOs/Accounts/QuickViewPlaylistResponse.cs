namespace Music.Core.DTOs.Accounts
{
    public class QuickViewPlaylistResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string ImgUrl { get; set; }
        public bool HaveSong { get; set; } = false;
        public bool IsPublic { get; set; } = false;
    }
}
