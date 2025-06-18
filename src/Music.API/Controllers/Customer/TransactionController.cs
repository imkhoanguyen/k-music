using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Transactions;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    [Authorize]
    public class TransactionController : BaseApiController
    {
        private readonly ITransactionService _transactionService;
        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll([FromQuery] TransactionParams prm)
        {
            var userId = ClaimsPrincipleExtensions.GetUserId(User);
            var pagedList = await _transactionService.GetAllAsync(prm, uvs => uvs.UserId == userId, false);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }
    }
}
