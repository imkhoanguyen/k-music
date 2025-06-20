using Microsoft.AspNetCore.Identity;
using Music.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities
{
    public class AppUser : IdentityUser
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public string? ImgUrl { get; set; }
        public string? PublicId { get; set; }
    }
}
