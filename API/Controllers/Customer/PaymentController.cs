using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Payment;
using KM.Domain.Entities;
using KM.Infrastructure.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    public class PaymentController : BaseApiController
    {
        private readonly IVnPayService _vnPayService;

        public PaymentController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost]
        public IActionResult CreatePaymentUrl(VipPackage entity)
        {
            var paymentDto = new PaymentDto
            {
                SelectedPackage = entity,
                UserId = User.GetUserId()
            };

            var url = _vnPayService.CreatePaymentUrl(paymentDto, HttpContext);

            return new JsonResult(url);
        }

        [HttpPost("return")]
        public async Task<ActionResult<UserVipSubscription>> PaymentReturn(PaymentResponse res)
        {
            res.UserId = User.GetUserId();
            var entity = await _vnPayService.HandlePayment(res);

            return Ok(entity);
        }
    }
}
