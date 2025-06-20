using Music.Application.DTOs.Genres;
using Music.Application.DTOs.Singers;
using Music.Application.DTOs.Songs;
using Music.Domain.Entities;

namespace Music.Application.Mappers
{
    public class SongMapper
    {
        public static SongDto EntityToSongDto(Song s)
        {
            return new SongDto
            {
                Id = s.Id,
                Name = s.Name,
                ImgUrl = s.ImgUrl,
                SongUrl = s.SongUrl,
                Introduction = s.Introduction,
                Lyric = s.Lyric,
                Created = s.Created,
                Updated = s.Updated,
                IsVip = s.IsVip,
                Singers = s.SongSingers.Select(ss => SingerMapper.EntityToSingerDto(ss.Singer)).ToList(),
                Genres = s.SongGenres.Select(sg => GenreMapper.EntityToGenreDto(sg.Genre)).ToList(),
            };
        }

        public static Song SongCreateDtoToEntity(SongCreateDto s)
        {
            return new Song
            {
                Name = s.Name,
                Introduction = s.Introduction,
                Lyric = s.Lyric,
            };
        }

        public static Song SongUpdateDtoToEntity(SongUpdateDto s)
        {
            return new Song
            {
                Id = s.Id,
                Name = s.Name,
                Introduction = s.Introduction,
                Lyric = s.Lyric,
            };
        }

    }
}
