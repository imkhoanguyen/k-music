using API.Controllers.Base;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.Core.Entities;
using Music.Core.DTOs.Transactions;
using Music.Core.Parameters;
using Music.Core.Service.Interfaces;

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
        public async Task<ActionResult<Transaction>> Get(int id)
        {
            var entity = await _transactionService.GetAsync(t => t.Id == id);
            return Ok(entity);
        }
    }
}
