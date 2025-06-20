using Music.Infrastructure.DataAccess;
using Music.Infrastructure.Ultilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using Music.Core.Entities;
using Music.Core.DTOs.Songs;
using Music.Core.Utilities;
using Music.Core.Parameters;
using Music.Core.Repositories;

namespace Music.Infrastructure.Repositories
{
    public class SongRepository : Repository<Song>, ISongRepository
    {
        private readonly MusicContext _context;

        public SongRepository(MusicContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Song>> GetAllAsync(SongParams prm, Expression<Func<Song, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Songs.AsQueryable() : _context.Songs.AsNoTracking().AsQueryable();

            query = query.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre);

            if(expression != null)
                query = query.Where(expression);

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
                songFromDb.LastModifiedDate = DateTime.Now;
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


        public override async Task<IEnumerable<Song>> GetAllAsync(Expression<Func<Song, bool>>? expression = null, bool tracked = false)
        {
            var query = tracked ? _context.Songs.AsQueryable() : _context.Songs.AsNoTracking().AsQueryable();

            query = query.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre);

            if (expression != null)
                query = query.Where(expression);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Song>> GetRandomAsync(int size, RandomSongRequest request,  bool tracked = false)
        {
            var query = tracked ? _context.Songs.AsQueryable() : _context.Songs.AsNoTracking().AsQueryable();

            query = query.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre);

            // Lọc bỏ giá trị 0 trong GenreIdList và SingerIdList
            var validGenreIds = request.GenreIdList?.Where(id => id != 0).ToList();
            var validSingerIds = request.SingerIdList?.Where(id => id != 0).ToList();

            if ((validGenreIds != null && validGenreIds.Any()) || (validSingerIds != null && validSingerIds.Any()))
            {
                query = query.Where(song =>
                    (validGenreIds != null && validGenreIds.Any(sg => song.SongGenres.Any(songGenre => songGenre.GenreId == sg))) ||
                    (validSingerIds != null && validSingerIds.Any(ss => song.SongSingers.Any(songSinger => songSinger.SingerId == ss)))
                );
            }

            var random = new Random();
            var songs = await query.ToListAsync();
            var randomSongs = songs.OrderBy(_ => random.Next()).Take(size);

            if (!randomSongs.Any())
            {
                var newQuery = _context.Songs.AsNoTracking().AsQueryable();
                newQuery = newQuery.Include(s => s.SongSingers).ThenInclude(ss => ss.Singer)
                    .Include(s => s.SongGenres).ThenInclude(sg => sg.Genre);
                var allSongs = await newQuery.ToListAsync();
                randomSongs = allSongs.OrderBy(_ => random.Next()).Take(20);
            }

            return randomSongs;
        }
    }
}
