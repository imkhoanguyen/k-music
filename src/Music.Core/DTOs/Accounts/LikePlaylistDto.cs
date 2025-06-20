namespace Music.Core.DTOs.Accounts
{
    public class LikePlaylistDto
    {
        public string UserId { get; set; } = string.Empty;
        public int PlaylistId { get; set; }
    }
}
