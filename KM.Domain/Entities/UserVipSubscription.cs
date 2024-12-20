using System.ComponentModel.DataAnnotations.Schema;

namespace KM.Domain.Entities
{
    public class UserVipSubscription : BaseEntity
    {
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; }
        //nav
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        public required string UserId { get; set; }
        public VipPackage? VipPackage { get; set; }
        public int VipPackageId { get; set; }
    }
}
