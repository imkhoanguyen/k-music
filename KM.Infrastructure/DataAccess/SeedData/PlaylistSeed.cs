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

            var listImgUrl = new List<string>
            {
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312777/1bbf452e21736a8cfc37a51b9978c39f1136f5c8_11817a_ebmhsg.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312755/300_11_r34idk.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312751/300_12_w0teig.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312744/300_13_chrrav.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312740/300_14_muwffi.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312734/300_15_u0ivu2.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312681/300_16_epntoz.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313068/300_17_hbyivv.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313042/300_18_hps0th.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312942/300_19_esx4zd.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312806/300_22_kycgyq.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312800/300_23_p8ydvp.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312793/300_24_ef8kwc.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312783/300_25_cxcntu.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312773/300_26_yubzsc.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483636/300_6_lmj1pk.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483638/300_7_ibhdbg.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483640/300_8_g6qqtb.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312766/300_9_idofm3.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483630/300_ccxatg.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313046/300-1_owwuvq.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312813/3001_uqn4wy.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312788/3002_apqyqk.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312819/4a4c394d898af81aa4eb089db43c261a76cda2b8_81dd5_jec0mi.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312729/600_1_rfwnun.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312675/600_10_srwbqg.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313062/600_11_umen4z.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312723/600_2_har779.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312718/600_3_i0ma0q.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312712/600_4_dvodvz.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312707/600_5_mz6up9.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312691/600_8_nuqhfo.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312685/600_9_gnnzyn.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483639/600_vmxaqu.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313057/84a5d37abf8fbfb5c52f3951eaac2941872b7e21_facc8_h16wwx.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312669/d7d68662155e54ad1a22821e6891368a807bb6c8_247193_uqrcy5.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736313051/eb65d22c05d45783355e1bd2bc53e11181a566a3_359ddf_zmzx2e.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312835/fd1d9aa83906f21fb7be394948ddaac32a1fa39a_200022_xvyb9n.webp",
                "https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312761/300_10_rt9r3k.webp"

            };

            var listPlaylist = new List<Playlist>();

            for (var i = 0; i < listImgUrl.Count(); i++)
            {
                var playlist = new Playlist
                {
                    Name = $"Danh sách phát ngẫu nhiên {i + 1}",
                    ImgUrl = listImgUrl[i],
                    UserId = user[0].Id,
                    PlaylistSongs = GetRandomSongs(i + 1, 20)
                };
                listPlaylist.Add(playlist);
            }


            var size = listPlaylist.Count();

            var customList = new List<Playlist>()
            {
                new Playlist
                {
                    Name = "OST Minh Lan Truyện",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734444219/minhlantruyen_yxnibn.jpg",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(size + 1,8),
                        new PlaylistSong(size + 1,10),
                    },
                },
                new Playlist
                {
                    Name = "OST Rất nhớ, rất nhớ anh",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734483018/ratnhoratnhoanh_llby9n.jpg",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(size + 2,11),
                        new PlaylistSong(size + 2,1),
                        new PlaylistSong(size + 2,93),
                        new PlaylistSong(size + 2,89),
                    },
                },

                new Playlist
                {
                    Name = "List nhạc Trương Bích Thần",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312824/300_21_tp09zm.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(size + 3,87),
                        new PlaylistSong(size + 3,78),
                        new PlaylistSong(size + 3,22),
                        new PlaylistSong(size + 3,7),
                        new PlaylistSong(size + 3,3),
                    },
                },

                new Playlist
                {
                    Name = "List nhạc Châu Thâm",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312665/d8bd844a19d36e95cb1ca2afdfcd62ce5c37927f_a8562_ct1gqf.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(size + 4,48),
                        new PlaylistSong(size + 4,28),
                        new PlaylistSong(size + 4,84),
                        new PlaylistSong(size + 4,85),
                        new PlaylistSong(size + 4,86),
                    },
                },

                new Playlist
                {
                    Name = "OST Trường Phong Độ",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736320914/truongphongdo_zoae8j.webp",
                    UserId = user[0].Id,
                    PlaylistSongs = new List<PlaylistSong>()
                    {
                        new PlaylistSong(size + 5,71),
                        new PlaylistSong(size + 5,69),
                        new PlaylistSong(size + 5,70),
                    },
                },
            };

            listPlaylist.AddRange(customList);

            context.Playlist.AddRange(listPlaylist);
            await context.SaveChangesAsync();

        }


    }
}
