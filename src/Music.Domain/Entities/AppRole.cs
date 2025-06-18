using Microsoft.AspNetCore.Identity;

namespace KM.Domain.Entities
{
    public class AppRole : IdentityRole
    {
        public required string Description { get; set; }
    }
}
