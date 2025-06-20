namespace Music.Core.DTOs.Accounts
{
    public class QuickViewPlaylistRequest
    {
        public int SongId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
