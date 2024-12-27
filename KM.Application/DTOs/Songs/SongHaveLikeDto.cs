namespace KM.Application.DTOs.Songs
{
    public class SongHaveLikeDto : SongDto
    {
        public bool Liked { get; set; } = false;
    }
}
