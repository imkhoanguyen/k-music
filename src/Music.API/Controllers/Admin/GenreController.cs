using API.Controllers.Base;
using API.Extensions;
using KM.Application.Authorization;
using KM.Application.DTOs.Genres;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(await _genreService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            return Ok(await _genreService.GetAsync(g => g.Id == id));
        }

        [HttpPost]
        [Authorize(Policy = AppPermission.Genre_Create)]
        public async Task<ActionResult<GenreDto>> CreateGenre(GenreCreateDto genreCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genre = await _genreService.CreateAsync(genreCreateDto);

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
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
