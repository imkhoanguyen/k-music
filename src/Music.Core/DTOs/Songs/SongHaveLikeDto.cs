namespace Music.Core.DTOs.Songs
{
    public class SongHaveLikeDto : SongDto
    {
        public bool Liked { get; set; } = false;
    }
}
