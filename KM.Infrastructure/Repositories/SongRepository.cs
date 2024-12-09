using KM.Application.Parameters;
using KM.Application.Repositories;
using KM.Application.Utilities;
using KM.Domain.Entities;
using KM.Infrastructure.DataAccess;
using KM.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace KM.Infrastructure.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly MusicContext _context;

        public SongRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Song>> GetAllAsync(SongParams prm, bool tracked = false)
        {
            var query = tracked ? _context.Songs.AsQueryable() : _context.Songs.AsNoTracking().AsQueryable();

            query = query.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre);

            if (!prm.Search.IsNullOrEmpty()) // search with song name and singer name
            {
                query = query.Where(s => s.Name.ToLower().Contains(prm.Search.ToLower())
                || s.SongSingers.Any(ss => ss.Singer.Name.ToLower().Contains(prm.Search.ToLower())));
            }

            if (prm.GenreList.Count > 0)
            {
                query = query.Where(s => s.SongGenres.Any(sg => prm.GenreList.Contains(sg.GenreId)));
            }

            if (!prm.OrderBy.IsNullOrEmpty())
            {
                query = prm.OrderBy switch
                {
                    "id" => query.OrderBy(s => s.Id),
                    "id_desc" => query.OrderByDescending(s => s.Id),
                    "name" => query.OrderBy(s => s.Name),
                    "name_desc" => query.OrderByDescending(s => s.Name),
                    _ => query.OrderByDescending(s => s.Id)
                };
            }

            return await query.ApplyPaginationAsync(prm.PageNumber, prm.PageSize);
        }

        public override async Task<Song?> GetAsync(Expression<Func<Song, bool>> expression, bool tracked = false)
        {
            if (tracked)
                return await _context.Songs
                .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre)
                .Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                .FirstOrDefaultAsync(expression);
            return await _context.Songs
                .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre)
                .Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<SongGenre>> GetAllGenreBySongIdAsync(int songId)
        {
            var song = await _context.Songs.AsNoTracking()
                .Include(s => s.SongGenres).FirstOrDefaultAsync(s => s.Id == songId);
            if (song == null)
                return Enumerable.Empty<SongGenre>();

            return song.SongGenres;
        }

        public async Task<IEnumerable<SongSinger>> GetAllSingerBySongIdAsync(int songId)
        {
            var song = await _context.Songs.AsNoTracking()
                .Include(s => s.SongSingers).FirstOrDefaultAsync(s => s.Id == songId);
            if (song == null)
                return Enumerable.Empty<SongSinger>();

            return song.SongSingers;
        }

        public async Task UpdateImgFileAsync(Song song)
        {
            var songFromDb = await _context.Songs.FirstOrDefaultAsync(s => s.Id == song.Id);
            if (songFromDb != null)
            {
                songFromDb.ImgUrl = song.ImgUrl;
                songFromDb.PublicImgId = song.PublicImgId;
            }
        }

        public async Task UpdateSongAsync(Song song)
        {
            var songFromDb = await _context.Songs.FirstOrDefaultAsync(s => s.Id == song.Id);
            if (songFromDb != null)
            {
                songFromDb.Name = song.Name;
                songFromDb.Introduction = song.Introduction;
                songFromDb.Lyric = song.Lyric;
                songFromDb.Updated = DateTime.Now;
            }
        }

        public async Task UpdateSongFileAsync(Song song)
        {
            var songFromDb = await _context.Songs.FirstOrDefaultAsync(s => s.Id == song.Id);
            if (songFromDb != null)
            {
                songFromDb.SongUrl = song.SongUrl;
                songFromDb.PublicSongId = song.PublicSongId;
            }
        }

        public async Task UpdateSongVipAsync(int songId, bool vip)
        {
            var songFromDb = await _context.Songs.FirstOrDefaultAsync(s => s.Id == songId);
            if (songFromDb != null)
            {
                songFromDb.IsVip = vip;
            }
        }

        public async Task<IEnumerable<Song>> GetAllAsync(bool tracked)
        {
            var query = tracked ? _context.Songs.AsQueryable() : _context.Songs.AsNoTracking().AsQueryable();

            return await query.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre).ToListAsync();
        }
    }
}
