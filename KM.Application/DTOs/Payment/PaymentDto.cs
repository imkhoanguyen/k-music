using KM.Domain.Entities;

namespace KM.Application.DTOs.Payment
{
    public class PaymentDto
    {
        public required VipPackage SelectedPackage { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}
