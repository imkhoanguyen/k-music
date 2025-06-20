namespace Music.Core.Entities
{
    public class SongGenre
    {
        public int SongId { get; set; }
        public Song? Song { get; set; }
        public int GenreId { get; set; }
        public Genre? Genre { get; set; }

        public SongGenre(int songId, int genreId)
        {
            SongId = songId;
            GenreId = genreId;
        }
    }
}
