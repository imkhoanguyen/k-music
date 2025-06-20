using API.Controllers.Base;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Core.Entities;
using Music.Core.DTOs.Payment;
using Music.Infrastructure.Intterfaces;

namespace API.Controllers.Customer
{
    [Authorize]
    public class PaymentController : BaseApiController
    {
        private readonly IVnPayService _vnPayService;

        public PaymentController(IVnPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        [HttpPost]
        public IActionResult CreatePaymentUrl(Plan entity)
        {
            var paymentDto = new PaymentDto
            {
                SelectedPlan = entity,
                UserId = User.GetUserId()
            };

            var url = _vnPayService.CreatePaymentUrl(paymentDto, HttpContext);

            return new JsonResult(url);
        }

        [HttpPost("return")]
        public async Task<ActionResult<Transaction>> PaymentReturn(PaymentResponse res)
        {
            res.UserId = User.GetUserId();
            var entity = await _vnPayService.HandlePayment(res);

            return Ok(entity);
        }
    }
}
