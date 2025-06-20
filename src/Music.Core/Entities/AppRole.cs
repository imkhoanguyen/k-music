using Microsoft.AspNetCore.Identity;

namespace Music.Core.Entities
{
    public class AppRole : IdentityRole
    {
        public string? Description { get; set; }
    }
}
