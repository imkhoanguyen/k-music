using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Core.Entities
{
    public class LikeSinger
    {
        public int SingerId { get; set; }
        public Singer? Singer { get; set; }
        public string UserId { get; set; } = string.Empty;
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
    }
}
