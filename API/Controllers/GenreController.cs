using API.Extensions;
using KM.Application.DTOs.Genres;
using KM.Application.Parameters;
using KM.Application.Service.Abstract;
using KM.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class GenreController : BaseApiController
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetGenres([FromQuery] GenreParams prm)
        {
            var pagedList = await _genreService.GetAllAsync(prm, false);

            Response.AddPaginationHeader(pagedList);

            return Ok(pagedList);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<GenreDto>>> GetAllGenre()
        {

            return Ok(await _genreService.GetAllAsync(false));
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GenreDto>> GetGenre(int id)
        {
            return Ok(await _genreService.GetAsync(g => g.Id == id));
        }

        [HttpPost]
        public async Task<ActionResult<GenreDto>> CreateGenre(GenreCreateDto genreCreateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genre = await _genreService.CreateAsync(genreCreateDto);

            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, genre);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateGenre(int id, GenreDto genreDto)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var genre = await _genreService.UpdateAsync(id, genreDto);

            return Ok(genre);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteGenre(int id)
        {
            await _genreService.DeleteAsync(g => g.Id == id);
            return NoContent();
        }
    }
}
