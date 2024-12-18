using KM.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class PlaylistSeed
    {
        public static async Task SeedAsync(MusicContext context, UserManager<AppUser> userManager)
        {
            if (await context.Playlist.AnyAsync()) return;
            var allSongs = await context.Songs.ToListAsync();
            var random = new Random();
            var user = await userManager.GetUsersInRoleAsync("Admin");

            List<PlaylistSong> GetRandomSongs(int playlistId, int count)
            {
                return allSongs
                    .OrderBy(x => random.Next()) // Xáo trộn danh sách
                    .Take(count) // Lấy số lượng bài hát cần thiết
                    .Select(song => new PlaylistSong(playlistId, song.Id)) // Chuyển thành PlaylistSong
                    .ToList();
            }

            var listPlaylist = new List<Playlist>()
            {
                new Playlist
                {
                    Name = "OST Minh Lan Truyện",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734444219/minhlantruyen_yxnibn.jpg",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(1,8),
                        new PlaylistSong(1,10),
                    },
                },
                new Playlist
                {
                    Name = "OST Rất nhớ, rất nhớ anh",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483018/ratnhoratnhoanh_llby9n.jpg",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(2,11),
                        new PlaylistSong(2,1),

                    },
                },
                new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 1",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483630/300_ccxatg.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                 new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 2",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483630/300_1_mfovyz.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                  new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 3",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483631/300_2_ahboog.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                   new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 4",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483634/300_3_pxfnbr.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                    new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 5",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483632/300_4_lulu20.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                        new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 6",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483635/300_5_tje2vo.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
                            new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 7",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483636/300_6_lmj1pk.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },    new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 8",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483638/300_7_ibhdbg.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },    new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 9",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483639/600_vmxaqu.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },    new Playlist
                {
                    Name = "Danh sách phát ngẫu nhiên 10",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483640/300_8_g6qqtb.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(3, 7)
                },
            };

            context.Playlist.AddRange(listPlaylist);
            await context.SaveChangesAsync();

        }


    }
}
