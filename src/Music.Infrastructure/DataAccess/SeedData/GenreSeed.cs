using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class GenreSeed
    {
        public static async Task SeedAsync(MusicContext context)
        {
            if (await context.Genres.AnyAsync()) return;

            var genres = new List<Genre>
            {
                new Genre
                {
                    Name = "Việt Nam",
                    Description = @"Âm nhạc Việt Nam là hệ thống tác phẩm âm nhạc tại Việt Nam. Đây là một phần của lịch sử và văn hóa Việt Nam. Âm nhạc Việt Nam phản ánh những nét đặc trưng của con người, văn hóa, phong tục, địa lý,... của đất nước Việt Nam, trải dài suốt chiều dài Lịch sử Việt Nam.".TrimStart().TrimEnd()
                },
                new Genre
                {
                    Name = "Trung Quốc",
                    Description = @"Nhạc Trung Quốc Phong (giản thể: 中国风; phồn thể: 中國風; bính âm: Zhōngguó fēng) hay làn gió Trung Hoa, tức dòng nhạc mang phong cách Trung Quốc, âm hưởng Trung Hoa, nổi lên trên thị trường nhạc đại chúng vào đầu thập niên 2000, nối tiếp sự thành công của những bản hit thời kỳ đầu của ngôi sao nhạc Mandopop người Đài Loan Châu Kiệt Luân như ""Nương Tử"" (tiếng Trung: 娘子; bính âm: Niáng zǐ) và ""Gió đông thổi"" (tiếng Trung: 東風破; bính âm: Dōng fēng pò).

Làn gió ""Trung Quốc Phong"" dẫn đầu một xu hướng mới của dòng nhạc pop Hoa ngữ (C-pop), bao gồm việc sử dụng các yếu tố Trung Hoa truyền thống hơn là việc đơn giản đi theo khuôn mẫu âm nhạc phương Tây. Những bài hát Trung Quốc Phong nổi tiếng khác gồm có ""Sứ Thanh Hoa"" (tiếng Trung: 青花瓷; bính âm: Qīng huā cí), ""Đài hoa cúc"" (tiếng Trung: 菊花台; bính âm: Jú huā tái), ""Thiên lý chi ngoại"" (tiếng Trung: 千里之外; bính âm: Qiān lǐ zhī wài) của Châu Kiệt Luân và ""Lỗi lầm ở vườn hoa"" (tiếng Trung: 花田錯; bính âm: Huā tián cuò) của Vương Lực Hoành.".TrimStart().TrimEnd()
                },
                new Genre
                {
                    Name = "OST",
                    Description = @"OST/Soundtrack có thể là nhạc đã thu âm sẵn đi kèm và đồng bộ với hình ảnh của một bộ phim, sách, chương trình truyền hình hay video game; một album nhạc phim được phát hành một cách thương mại âm nhạc trong nhạc phim của một bộ phim hoặc show truyền hình; hoặc phần vật lý của một phim mà bao gồm những âm thanh đã được ghi âm và đồng bộ sẵn.".TrimStart().TrimEnd()
                },
                new Genre
                {
                    Name = "Cổ phong",
                    Description = @"Nhạc cổ phong (tiếng Trung: 古风音乐; bính âm: gǔ fēng yīn yuè) là một phong cách âm nhạc Trung Quốc xuất hiện và nổi lên trong thế kỷ 21,[1] đặc trưng bởi: ca từ cổ điển tao nhã, cách dùng từ đều đặn, có trật tự và được trau chuốt giống như bài thơ cổ (có vần, nhịp, sử dụng hình ảnh ước lệ tượng trưng, dùng từ cổ, điển cố, tả cảnh tả tình, số câu chẵn), tác từ dựa trên điển tích, điển cố của Trung Quốc, thường có văn án. Nhạc cổ phong có giai điệu nhẹ nhàng, âm điệu du dương trên nền các loại nhạc cụ dân tộc,[1] chứa đựng phong cách độc đáo, được xem như làn gió mới thổi vào âm nhạc Trung Quốc cổ điển.

Một số nghệ sĩ đại diện của dòng nhạc này như Đặc Mạn, Lão Can Ma, nhóm nhạc Mặc Minh Kỳ Diệu, Hà Đồ, I2Star (nhóm nhạc nữ trực thuộc Mặc Minh Kỳ Diệu: HITA, Aki A Kiệt, Tiểu Ái Đích Mụ- đã tan rã), Ngân Lâm, Mộ Hàn, Tiểu W, Winky Thi (nam), Đổng Trinh, Finale (nữ), Tiểu Khúc Nhi, HITA, Âm Tần Quái Vật, Vân Chi Khấp, Huyền Thương, CRITTY, Song Sênh.".TrimStart().TrimEnd(),
                }
            };

            context.Genres.AddRange(genres);
            await context.SaveChangesAsync();
        }
    }
}
