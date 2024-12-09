using KM.Application.DTOs.Playlists;
using KM.Domain.Entities;

namespace KM.Application.Mappers
{
    public class PlaylistMapper
    {
        public static PlaylistDto EntityToPlaylistDto(Playlist playlist)
        {
            return new PlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                ImgUrl = playlist.ImgUrl,
                Created = playlist.Created,
                Updated = playlist.Updated,
                PlayCount = playlist.PlayCount,
                IsPublic = playlist.IsPublic,
            };
        }

        public static Playlist PlaylistCreateDtoEntity(PlaylistCreateDto dto)
        {
            return new Playlist
            {
                Name = dto.Name,
                UserId = dto.UserId,
                IsPublic = dto.IsPublic,
            };
        }
    }
}
