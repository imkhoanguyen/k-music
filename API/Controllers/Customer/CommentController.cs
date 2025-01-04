using API.Controllers.Base;
using API.Extensions;
using KM.Application.DTOs.Comments;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using KM.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Customer
{
    public class CommentController : BaseApiController
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetAll([FromQuery]CommentParams prm)
        {

            var pagedList = await _commentService.GetAllAsync(c => c.RelatedType == prm.RelatedType && c.RelatedId == prm.RelatedId, prm);

            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CommentDto>> Get(int id)
        {
            var dto = await _commentService.GetAsync(c => c.Id == id);
            return Ok(dto);
        } 

        [HttpPost]
        public async Task<ActionResult<CommentDto>> AddComment([FromBody] CommentCreateDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var returnDto = await _commentService.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = returnDto.Id }, returnDto);
        }

        [HttpPost("reply")]
        public async Task<ActionResult<CommentDto>> AddComment([FromBody] ReplyCreateDto dto)
        {
            dto.UserId = ClaimsPrincipleExtensions.GetUserId(User);
            var returnDto = await _commentService.AddReplyAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = returnDto.Id }, returnDto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CommentDto>> Update(int id, [FromBody] CommentUpdateDto dto)
        {
            if(id != dto.Id)
            {
                throw new BadRequestException("Bình luận không khớp. Thử lại sau");
            }


            var returnDto = await _commentService.UpdateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = returnDto.Id }, returnDto);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _commentService.RemoveAsync(c => c.Id == id);
            return NoContent();
        }
    }
}
