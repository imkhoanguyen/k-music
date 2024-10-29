using KM.Application.DTOs.Singers;
using KM.Domain.Entities;

namespace KM.Application.Mappers
{
    public class SingerMapper
    {
        public static SingerDto EntityToSingerDto(Singer singer)
        {
            return new SingerDto
            {
                Id = singer.Id,
                Name = singer.Name,
                Gender = singer.Gender.ToString(),
                Introduction = singer.Introduction,
                Location = singer.Location,
                ImgUrl = singer.ImgUrl,
            };
        }

        public static Singer SingerCreateDtoToEntity(SingerCreateDto s)
        {
            return new Singer
            {
                Name = s.Name,
                Gender = s.Gender,
                Introduction = s.Introduction,
                Location = s.Location,
            };
        }

        public static Singer SingerUpdateDtoToEntity(SingerUpdateDto s)
        {
            return new Singer
            {
                Id = s.Id,
                Name = s.Name,
                Gender = s.Gender,
                Introduction = s.Introduction,
                Location = s.Location,
            };
        }
    }
}
