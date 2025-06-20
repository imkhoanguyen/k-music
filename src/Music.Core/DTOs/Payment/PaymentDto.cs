using Music.Core.Entities;

namespace Music.Core.DTOs.Payment
{
    public class PaymentDto
    {
        public required Plan SelectedPlan { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
