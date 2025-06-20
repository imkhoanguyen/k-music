using Music.Application.DTOs.Playlists;
using Music.Domain.Entities;

namespace Music.Application.Mappers
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
                IsPublic = playlist.IsPublic,
                UserName = playlist.AppUser?.UserName ?? string.Empty
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
