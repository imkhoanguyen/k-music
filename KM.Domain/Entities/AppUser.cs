using KM.Domain.Enum;
using Microsoft.AspNetCore.Identity;

namespace KM.Domain.Entities
{
    public class AppUser : IdentityUser
    {
        public Gender Gender { get; set; }
        public string? ImgUrl { get; set; }
        public string? PublicId { get; set; }
        public bool IsVip { get; set; } = false;
        public DateTime? VipExpiryDay { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        //nav
        public int? VipPlanId { get; set; }
        public VipPlan? VipPlan { get; set; }
    }
}
