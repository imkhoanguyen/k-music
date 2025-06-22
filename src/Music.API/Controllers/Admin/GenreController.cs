using API.Controllers.Base;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Music.API.Filters;
using Music.Core.Authorization;
using Music.Core.Common;
using Music.Core.DTOs.Genres;
using Music.Core.Exceptions;
using Music.Core.Parameters;
using Music.Core.Service.Interfaces;

namespace API.Controllers.Admin
{
    [Authorize]
    public class GenreController : BaseAdminApiController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres([FromQuery] GenreParams prm)
        {
            var pagedList = await _genreService.GetAllAsync(prm, false);

            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
        }

        [HttpGet("get-all")]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllGenre()
        {
            var genres = await _genreService.GetAllAsync();
            return Ok(Result.Ok(genres));
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            return Ok(await _genreService.GetAsync(g => g.Id == id));
        }

        [HttpPost]
        [Authorize(Policy = AppPermission.Genre_Create)]
        [ValidateModelState]
        public async Task<ActionResult<GenreDto>> CreateGenre(GenreCreateDto genreCreateDto)
        {
            var result = await _genreService.CreateAsync(genreCreateDto);

            return StatusCode(201, Result.Ok(result, 201));
        }

        [Authorize(Policy = AppPermission.Genre_Edit)]
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateGenre(int id, GenreDto genreDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genre = await _genreService.UpdateAsync(id, genreDto);

            return Ok(genre);
        }

        [Authorize(Policy = AppPermission.Genre_Delete)]
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteAsync(g => g.Id == id);
            return NoContent();
        }
    }
}
