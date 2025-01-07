using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Transactions;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin
{
    [Authorize]
    public class TransactionController : BaseAdminApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetAll([FromQuery] TransactionParams prm)
        {
            var pagedList = await _transactionService.GetAllAsync(prm, null, false);
            Response.AddPaginationHeader(pagedList);
            return Ok(pagedList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserVipSubscription>> Get(int id)
        {
            var entity = await _transactionService.GetAsync(t => t.Id == id);
            return Ok(entity);
        }
    }
}
