using Music.Core.Entities.Abstracts;
using Music.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities
{
    public class Singer : EntityAuditBase<int>
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        [Required]
        public string Introduction { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        public string ImgUrl { get; set; } = string.Empty;
        public string? PublicId { get; set; }
        //nav
        public List<SongSinger> SongSingers { get; set; } = [];
    }
}
