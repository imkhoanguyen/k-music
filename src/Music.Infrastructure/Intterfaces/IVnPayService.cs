using Microsoft.AspNetCore.Http;
using Music.Core.Entities;
using Music.Core.DTOs.Payment;

namespace Music.Infrastructure.Intterfaces
{
    public interface IVnPayService
    {
        string CreatePaymentUrl(PaymentDto dto, HttpContext context);
        Task<Transaction?> HandlePayment(PaymentResponse res);
    }
}
