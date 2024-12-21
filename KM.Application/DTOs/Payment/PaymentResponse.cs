namespace KM.Application.DTOs.Payment
{
    public class PaymentResponse
    {
        public int OrderInfo { get; set; } // set VipPackageId is OrderInfo
        public string ResponseCode { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
    }
}
