using Music.Domain.Entities;

namespace Music.Application.DTOs.Payment
{
    public class PaymentDto
    {
        public required Plan SelectedPackage { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
