using Music.Core.DTOs.Playlists;
using Music.Core.Entities;

namespace Music.Core.Mappers
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
                Created = (DateTimeOffset)playlist.CreatedDate,
                Updated = (DateTimeOffset)playlist.LastModifiedDate,
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
