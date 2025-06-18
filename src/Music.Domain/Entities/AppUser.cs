using Microsoft.AspNetCore.Identity;
using Music.Domain.Enum;

namespace KM.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public required string FullName { get; set; }
        public Gender Gender { get; set; }
        public string? ImgUrl { get; set; }
        public string? PublicId { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
