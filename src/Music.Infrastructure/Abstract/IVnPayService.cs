using KM.Application.DTOs.Payment;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace KM.Infrastructure.Abstract
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentDto dto, HttpContext context);
        Task<UserVipSubscription?> HandlePayment(PaymentResponse res);
    }
}
