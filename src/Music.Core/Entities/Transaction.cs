using Music.Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Music.Core.Entities
{
    public class Transaction : EntityAuditBase<int>
    {
        public decimal Price { get; set; }
        public DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset EndDate { get; set; }
        //nav
        [ForeignKey("UserId")]
        public AppUser? AppUser { get; set; }
        [Required]
        public string UserId { get; set; } = string.Empty;
        public Plan? Plan { get; set; }
        public int PlanId { get; set; }
    }
}
