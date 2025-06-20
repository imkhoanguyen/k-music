using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Core.Entities
{
    public class LikeSong
    {
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public int SongId { get; set; }
        public Song? Song { get; set; }
    }
}
