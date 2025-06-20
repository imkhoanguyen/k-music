using Music.Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities
{
    public class Genre : EntityAuditBase<int>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //nav
        public List<SongGenre> SongGenres { get; set; } = [];
    }
}
