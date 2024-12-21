using KM.Application.DTOs.Payment;
using KM.Application.Interfaces;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using KM.Infrastructure.Configuration;
using KM.Infrastructure.Ultilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace KM.Infrastructure.Services
{
    public class VnPayService : IVnPayService
    {
        private readonly VNPayConfig _config;
        private readonly IUnitOfWork _unit;
        private readonly IVipPackageService _vipPackageService;

        public VnPayService(IOptions<VNPayConfig> config, IUnitOfWork unit, IVipPackageService vipPackageService)
        {
            var vnpayConfig = new VNPayConfig
            {
                Version = config.Value.Version,
                TmnCode = config.Value.TmnCode,
                HashSecret = config.Value.HashSecret,
                ReturnUrl = config.Value.ReturnUrl,
                BaseUrl = config.Value.BaseUrl,
                Command = config.Value.Command,
                CurrCode = config.Value.CurrCode,
                Locale = config.Value.Locale,
                TimeZoneId = config.Value.TimeZoneId    
            };
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
            pay.AddRequestData("vnp_Amount", ((int)dto.SelectedPackage.PriceSell * 100).ToString());
            pay.AddRequestData("vnp_CreateDate", timeNow.ToString("yyyyMMddHHmmss"));
            pay.AddRequestData("vnp_CurrCode", _config.CurrCode);
            pay.AddRequestData("vnp_IpAddr", pay.GetIpAddress(context));
            pay.AddRequestData("vnp_Locale", _config.Locale);
            pay.AddRequestData("vnp_OrderInfo", $"{dto.SelectedPackage.Id}");
            pay.AddRequestData("vnp_OrderType", "order");
            pay.AddRequestData("vnp_ReturnUrl", urlCallBack);
            pay.AddRequestData("vnp_TxnRef", tick);

            var paymentUrl =
                pay.CreateRequestUrl(_config.BaseUrl, _config.HashSecret);

            return paymentUrl;
        }

        public async Task<UserVipSubscription?> HandlePayment(PaymentResponse res)
        {
            if(res.ResponseCode == "00")
            {
                var vipPackage = await _vipPackageService.GetAsync(vp => vp.Id == res.OrderInfo);
                var userVipScription = new UserVipSubscription
                {
                    UserId = res.UserId,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(vipPackage.DurationDay),
                    Price = vipPackage.PriceSell,
                    VipPackageId = vipPackage.Id
                };

                await _unit.UserVipSubscription.AddAsync(userVipScription);
                if(await _unit.CompleteAsync())
                {
                    var dataReturn = await _unit.UserVipSubscription.GetAsync(uvs => uvs.Id == userVipScription.Id);
                    return dataReturn;
                }
            }

            return null;
        }
    }
}
