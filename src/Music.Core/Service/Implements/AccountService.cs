using Music.Core.DTOs.Accounts;
using Music.Core.DTOs.Playlists;
using Music.Core.DTOs.Singers;
using Music.Core.DTOs.Songs;
using Music.Core.Entities;
using Music.Core.Exceptions;
using Music.Core.Parameters;
using Music.Core.Repositories;
using Music.Core.Service.Interfaces;
using Music.Core.Utilities;

namespace Music.Core.Service.Implements
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unit;
        private readonly ISongService _songService;
        private readonly IPlaylistService _playlistService;
        private readonly ISingerService _singerService;

        public AccountService(IUnitOfWork unit, ISongService songService, IPlaylistService playlistService, ISingerService singerService)
        {
            _unit = unit;
            _songService = songService;
            _playlistService = playlistService;
            _singerService = singerService;
        }

        public async Task<bool> CheckLikePlaylistAsync(LikePlaylistDto dto)
        {
            return await _unit.LikePlaylist.ExistsAsync(lp => lp.UserId == dto.UserId && lp.PlaylistId == dto.PlaylistId) == true;
        }

        public async Task<bool> CheckLikeSingerAsync(LikeSingerDto dto)
        {
            return await _unit.LikeSinger.ExistsAsync(ls => ls.UserId == dto.UserId && ls.SingerId == dto.SingerId) == true;
        }

        public async Task<bool> CheckLikeSongAsync(LikeSongDto dto)
        {
            return await _unit.LikeSong.ExistsAsync(ls => ls.UserId == dto.UserId && ls.SongId == dto.SongId) == true;
        }

        public async Task<PagedList<PlaylistDto>> GetPlaylistLiked(PlaylistParams prm, string userId)
        {
            var playlistLiked = await _unit.LikePlaylist.GetAllAsync(lp => lp.UserId == userId);
            var likedPlaylistIds = playlistLiked.Select(lp => lp.PlaylistId).ToList();
            var playlists = await _playlistService.GetAllAsync(prm, p => likedPlaylistIds.Contains(p.Id));
            return playlists;
        }

        public async Task<PagedList<SingerDto>> GetSingerLiked(SingerParams prm, string userId)
        {
            var singerLiked = await _unit.LikeSinger.GetAllAsync(ls => ls.UserId == userId);
            var likedSingerIds = singerLiked.Select(sl => sl.SingerId).ToList();
            var singers = await _singerService.GetAllAsync(prm, s => likedSingerIds.Contains(s.Id));
            return singers;
        }

        public async Task<PagedList<SongDto>> GetSongLiked(SongParams prm, string userId)
        {
            var songLiked = await _unit.LikeSong.GetAllAsync(ls => ls.UserId == userId);
            var likedSongIds = songLiked.Select(sl => sl.SongId).ToList();
            var songs = await _songService.GetAllAsync(prm, s => likedSongIds.Contains(s.Id));
            return songs;
        }

        public async Task LikePlaylistAsync(LikePlaylistDto dto)
        {
            if (await _unit.Playlist.ExistsAsync(p => p.Id == dto.PlaylistId) == false)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát");
            }

            if(await CheckLikePlaylistAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích danh sách phát này rồi");
            }

            var entity = new LikePlaylist
            {
                PlaylistId = dto.PlaylistId,
                UserId = dto.UserId,
            };

            await _unit.LikePlaylist.AddAsync(entity);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích danh sách phát");
            }
        }

        public async Task LikeSingerAsync(LikeSingerDto dto)
        {
            if (await _unit.Singer.ExistsAsync(s => s.Id == dto.SingerId) == false)
            {
                throw new NotFoundException("Không tìm thấy ca sĩ");
            }

            if (await CheckLikeSingerAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích ca sĩ này rồi");
            }

            var entity = new LikeSinger
            {
                SingerId = dto.SingerId,
                UserId = dto.UserId,
            };

            await _unit.LikeSinger.AddAsync(entity);

            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích ca sĩ");
            }
        }

        public async Task LikeSongAsync(LikeSongDto dto)
        {
            if(await _unit.Song.ExistsAsync(s => s.Id == dto.SongId) == false)
            {
                throw new NotFoundException("Không tìm thấy bài hát");
            }

            if (await CheckLikeSongAsync(dto) == true)
            {
                throw new BadRequestException("Bạn đã thích bài hát này rồi");
            }

            var entity = new LikeSong
            {
                SongId = dto.SongId,
                UserId = dto.UserId,
            };

            await _unit.LikeSong.AddAsync(entity);

            if(!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Có lỗi xảy ra khi thích bài hát");
            }
        }

        public async Task UnlikePlaylistAsync(LikePlaylistDto dto)
        {
            var entity = await _unit.LikePlaylist.GetAsync(lp => lp.UserId == dto.UserId && lp.PlaylistId == dto.PlaylistId);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy danh sách phát đã thích");
            }

            _unit.LikePlaylist.Remove(entity);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích danh sách phát thất bại");
            }
        }

        public async Task UnlikeSingerAsync(LikeSingerDto dto)
        {
            var entity = await _unit.LikeSinger.GetAsync(ls => ls.UserId == dto.UserId && ls.SingerId == dto.SingerId);
            if (entity == null)
            {
                throw new NotFoundException("Không tìm thấy ca sĩ đã thích");
            }

            _unit.LikeSinger.Remove(entity);
            if (!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích ca sĩ thất bại");
            }
        }

        public async Task UnlikeSongAsync(LikeSongDto dto)
        {
            var entity = await _unit.LikeSong.GetAsync(ls => ls.UserId == dto.UserId && ls.SongId == dto.SongId);
            if(entity == null)
            {
                throw new NotFoundException("Không tìm thấy bài hát đã thích");
            }

            _unit.LikeSong.Remove(entity);
            if(!await _unit.CompleteAsync())
            {
                throw new BadRequestException("Bỏ thích bài hát thất bại");
            }
        }
    }
}
