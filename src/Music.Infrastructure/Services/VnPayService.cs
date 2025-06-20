using Music.Infrastructure.Intterfaces;
using Music.Infrastructure.Configuration;
using Music.Infrastructure.Ultilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Music.Core.Entities;
using Music.Core.DTOs.Payment;
using Music.Core.Repositories;
using Music.Core.Service.Interfaces;

namespace Music.Infrastructure.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly VNPayConfig _config;
        private readonly IUnitOfWork _unit;
        private readonly IVipPackageService _vipPackageService;

        public VnPayService(IOptions<VNPayConfig> config, IUnitOfWork unit, IVipPackageService vipPackageService)
        {
            var vnpayConfig = config.Value;
            _config = vnpayConfig;
            _unit = unit;
            _vipPackageService = vipPackageService;
        }
        public string CreatePaymentUrl(PaymentDto dto, HttpContext context)
        {
            var timeZoneById = TimeZoneInfo.FindSystemTimeZoneById(_config.TimeZoneId);
            var timeNow = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZoneById);
            var tick = DateTime.Now.Ticks.ToString();
            var pay = new VnPayLibrary();
            var urlCallBack = _config.ReturnUrl;

            pay.AddRequestData("vnp_Version", _config.Version);
            pay.AddRequestData("vnp_Command", _config.Command);
            pay.AddRequestData("vnp_TmnCode", _config.TmnCode);
            pay.AddRequestData("vnp_Amount", ((int)dto.SelectedPlan.PriceSell * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _config.CurrCode);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _config.Locale);
            pay.AddRequestData("vnp_OrderInfo", $"{dto.SelectedPlan.Id}");
            pay.AddRequestData("vnp_OrderType", "order");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_config.BaseUrl, _config.HashSecret);

            return paymentUrl;
        }

        public async Task<Transaction?> HandlePayment(PaymentResponse res)
        {
            if (res.ResponseCode == "00")
            {
                var vipPackage = await _vipPackageService.GetAsync(vp => vp.Id == res.OrderInfo);
                var userSubscriptions = await _unit.UserVipSubscription.GetAllAsync(uvs => uvs.UserId == res.UserId);

                DateTimeOffset newEndDate;

                // get những gói vip chưa hết hạn
                var activeSubscriptions = userSubscriptions.Where(uvs => uvs.EndDate >= DateTime.Now).ToList();

                if (activeSubscriptions.Any())
                {
                    newEndDate = activeSubscriptions.Max(uvs => uvs.EndDate).AddDays(vipPackage.DurationDay);
                }
                else
                {
                    newEndDate = DateTime.Now.AddDays(vipPackage.DurationDay);
                }

                var userVipScription = new Transaction
                {
                    UserId = res.UserId,
                    StartDate = DateTime.Now,
                    EndDate = newEndDate,
                    Price = vipPackage.PriceSell,
                    PlanId = vipPackage.Id
                };

                await _unit.UserVipSubscription.AddAsync(userVipScription);
                if (await _unit.CompleteAsync())
                {
                    var dataReturn = await _unit.UserVipSubscription.GetAsync(uvs => uvs.Id == userVipScription.Id);
                    return dataReturn;
                }
            }

            return null;
        }
    }
}
