using Music.Core.DTOs.Genres;
using Music.Core.Entities;

namespace Music.Core.Mappers
{
    public class GenreMapper
    {
        public static GenreDto EntityToGenreDto(Genre genre)
        {
            return new GenreDto
            {
                Id = genre.Id,
                Name = genre.Name,
                Description = genre.Description,
            };
        }

        public static Genre GenreCreateDtoToEntity(GenreCreateDto dto)
        {
            return new Genre
            {
                Name = dto.Name!,
                Description = dto.Description!
            };
        }

        public static Genre GenreDtoToEntity(GenreDto dto)
        {
            return new Genre
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
            };
        }

    }
}
