using KM.Application.DTOs.Genres;
using KM.Application.Mappers;
using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Service.Abstract;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Domain.Exceptions;
using System.Diagnostics;
using System.Linq.Expressions;

namespace KM.Application.Service.Implementation
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unit;

        public GenreService(IUnitOfWork unit)
        {
            _unit = unit;
        }
        public async Task<GenreDto> CreateAsync(GenreCreateDto dto)
        {
            if (await _unit.Genre.ExistsAsync(g => g.Name.ToLower().Contains(dto.Name!.ToLower())))
            {
                throw new BadRequestException("Thể loại này đã tồn tại");
            }

            var genre = GenreMapper.GenreCreateDtoToEntity(dto);

            await _unit.Genre.AddAsync(genre);

            if (await _unit.CompleteAsync())
            {
                return GenreMapper.EntityToGenreDto(genre);
            }

            throw new Exception("Đã xảy ra lỗi khi tạo thể loại");
        }

        public async Task DeleteAsync(Expression<Func<Genre, bool>> expression)
        {
            var genre = await _unit.Genre.GetAsync(expression);
            if (genre == null)
                throw new NotFoundException("Thể loại không tồn tại");


            _unit.Genre.Remove(genre);
            if (!await _unit.CompleteAsync())
            {
                throw new Exception("Đã xảy ra lỗi khi xóa thể loại");
            }
        }

        public async Task<PagedList<GenreDto>> GetAllAsync(GenreParams prm, bool tracked)
        {
            var genres = await _unit.Genre.GetAllAsync(prm, tracked);

            // Map Genre to GenreDto
            var genreDtos = genres.Select(GenreMapper.EntityToGenreDto);
            return new PagedList<GenreDto>(genreDtos, genres.TotalCount, genres.CurrentPage, genres.PageSize);
        }

        public async Task<IEnumerable<GenreDto>> GetAllAsync(bool tracked)
        {
            var genres = await _unit.Genre.GetAllAsync(tracked);
            return genres.Select(GenreMapper.EntityToGenreDto); // return list GenreDto
        }

        public async Task<GenreDto?> GetAsync(Expression<Func<Genre, bool>> expression)
        {
            var genre = await _unit.Genre.GetAsync(expression);
            if (genre == null)
                throw new NotFoundException("Thể loại không tồn tại");

            return GenreMapper.EntityToGenreDto(genre);
        }

        public async Task<GenreDto> UpdateAsync(int id, GenreDto dto)
        {
            if (dto.Id != id)
            {
                throw new BadRequestException("Id không khớp. Không thể cập nhật");
            }

            if (!await _unit.Genre.ExistsAsync(g => g.Id == id))
                throw new NotFoundException("Không tìm thấy thể loại");

            if (await _unit.Genre.ExistsAsync(g => g.Name.ToLower() == dto.Name.ToLower() && g.Id != id))
                throw new BadRequestException("Tên thể loại đã tồn tại");

            var genre = GenreMapper.GenreDtoToEntity(dto);

            _unit.Genre.Update(genre);

            if (await _unit.CompleteAsync())
            {
                return dto;
            }

            throw new Exception("Đã xảy ra lỗi khi cập nhật thể loại");

        }
    }
}
