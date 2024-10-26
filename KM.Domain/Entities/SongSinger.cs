namespace KM.Domain.Entities
{
    public class SongSinger
    {
        public int SongId { get; set; }
        public Song? Song { get; set; }
        public int SingerId { get; set; }
        public Singer? Singer { get; set; }

        public SongSinger(int songId, int singerId)
        {
            SongId = songId;
            SingerId = singerId;
        }
    }
}
