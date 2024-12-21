using API.Extensions;
using KM.Application.DTOs.Payment;
using KM.Application.Interfaces;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
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
                UserId = ClaimsPrincipleExtensions.GetUserId(User)
            };

            var url = _vnPayService.CreatePaymentUrl(paymentDto, HttpContext);

            return new JsonResult(url);
        }

        [HttpPost("return")]
        public async Task<ActionResult<UserVipSubscription>> PaymentReturn(PaymentResponse res)
        {
            res.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var entity = await _vnPayService.HandlePayment(res);

            return Ok(entity);
        }
    }
}
