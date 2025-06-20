namespace Music.Core.DTOs.Accounts
{
    public class QuickAddSongToPlaylistRequest
    {
        public int SongId { get; set; }
        public int PlaylistId { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
