using API.Extensions;
using KM.Application.DTOs.Transactions;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class TransactionController : BaseApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll([FromQuery]TransactionParams prm)
        {
            var pagedList = await _transactionService.GetAllAsync(prm, null, false);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }
    }
}
