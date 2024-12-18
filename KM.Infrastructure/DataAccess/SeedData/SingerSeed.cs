using KM.Domain.Entities;
using KM.Domain.Enum;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class SingerSeed
    {
        public static async Task SeedAsync(MusicContext context)
        {
            if (await context.Singers.AnyAsync()) return;

            var singers = new List<Singer>
            {
                new Singer
                {
                    Name = @"Liệt Thiên/裂天",
                    Gender = Gender.Male,
                    Introduction = @"Tên tiếng Trung: Liệt Thiên/裂天

Nghề nghiệp: Ca sĩ

Ngày sinh: 21/02/1984

Các tác phẩm tiêu biểu: “Tuyệt chiêu nhất thế gian”, “Bát tùng rồng”, “Bạch mã gầm gió Tây, v.v.”

Giới thiệu: Split Sky, một ca sĩ trực tuyến, một nhạc sĩ được chứng nhận bởi cơ sở âm nhạc gốc 5sing của Trung Quốc, một nhạc sĩ nổi tiếng, thành viên trong nhóm âm nhạc gốc của Luan Fengming và là ca sĩ trong ban nhạc kênh toàn nam YY Man-Han. Giọng hát của anh có đặc điểm là cứng rắn, độc đoán và táo bạo. Anh là một trong những ca sĩ có giọng hát nổi tiếng nhất trong làng nhạc cổ điển. Anh giỏi nhạc rock, trữ tình và các thể loại khác. Năm 2013, anh chính thức bước vào giới âm nhạc cổ xưa với ca khúc dành cho người hâm mộ Tomb Raiders Evil Spirit ""Jiu"". Cùng năm đó, anh hát ""The Best Move in the World"" cho trò chơi trực tuyến Tian Long Ba Bu, trò chơi trực tuyến đầu tiên. tác phẩm tiêu biểu của Ritian sau khi bước vào giới âm nhạc cổ xưa. Kể từ đó, đặc điểm giọng hát và kỹ năng ca hát của anh đã thu hút nhiều trò chơi và hoạt hình khác nhau được mời hát các bài hát chủ đề và bài hát mở đầu, chẳng hạn như ""Crazy Wilderness"", ""The Sky-Splitting Blade"", ""A Mortal's Road to Immortality"", "" Hãy đến để thực hiện một giấc mơ”, v.v.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733644730/1-liethtien_tvivft.webp",

                },
                new Singer
                {
                    Name = @"Huyền Tử/弦子",
                    Gender = Gender.Female,
                    Introduction = @"Tên tiếng Trung: Zhang Xianzi

Tên nước ngoài: Stringer

Quốc tịch: Trung Quốc

Nơi sinh: Huyện Debao, thành phố Baise, khu tự trị dân tộc Choang Quảng Tây

Ngày sinh: 22/04/1986

Nghề nghiệp: Ca sĩ, diễn viên

Tác phẩm tiêu biểu: “Gió say”, “Phải yêu”, “Bất đắc dĩ”, “Ngây thơ”, “Hoa hồng ngược gió”, “Yêu em trước ngày hết hạn”

Thành tích chính: Bảng xếp hạng TOP Trung Quốc năm 2013 Nghệ sĩ toàn năng đại lục Bảng xếp hạng phương Đông lần thứ 16 Giải thưởng Top 10 Giai điệu vàng 2009 Bảng xếp hạng bài hát Trung Quốc Hàng năm Nữ ca sĩ xuất sắc nhất, Nhà soạn nhạc xuất sắc nhất, Giai điệu vàng hàng năm (được đề cử) Giải Bạc Người mới đến Phương Đông lần thứ 14 Giải Bạc 9+2 Tiên phong Âm nhạc Liệt kê Lực lượng mới hàng năm trong giới âm nhạc Trung Quốc Xếp hạng HÀNG ĐẦU Giải thưởng Nghệ sĩ mới biểu diễn xuất sắc nhất Đại lục, Giải thưởng được yêu thích tại trường đại học

Giới thiệu: Xianzi, tốt nghiệp Học viện đào tạo âm nhạc hiện đại Bắc Kinh, là nữ ca sĩ, diễn viên nổi tiếng người Trung Quốc.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733644730/2-huyentu_adz6bg.webp",
                },
                new Singer
                {
                    Name = @"Lão Can Ma/李常超（Lao乾妈）",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Nam Kinh, Giang Tô

Tác phẩm tiêu biểu: “Kẻ cướp mộ ghi chú: Mười năm trên thế giới”, “Cô gái Trường An”, “Với Zhuang”, “Sự sống và cái chết”, “Lịch sử núi xuân”, “Phong Vân Hi”

Giới thiệu ngắn gọn: Li Changchao (Laoganma), một nhạc sĩ phong cách Trung Quốc, sinh ra ở Nam Kinh, tỉnh Giang Tô.

Tính đến năm 2021, hơn 100 bài hát gốc đã được phát hành thành công, với hơn 10 tỷ lượt xem trên toàn mạng.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733644730/3-laocanma_pho6gc.webp",

                },
                new Singer
                {
                    Name = @"Đàn Kiện Thứ/檀健次",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: JC-T

Bí danh: Duoduo

Quốc tịch: Trung Quốc

Nơi sinh: Bắc Hải, Quảng Tây

Ngày sinh: 5 tháng 10 năm 1990

Nghề nghiệp: Diễn viên, ca sĩ

Tác phẩm tiêu biểu: “Sách minh họa về tội ác săn bắn”, “Bạn có an toàn không”, “Sauvignon Blanc”, “Hổ gầm rồng gầm”, “Liên minh quân sự vĩ đại của Tư Mã Ý”, “Vạn đèn”, “Bay”. Xa""

Thành tích chính: Quán quân nhóm trẻ cuộc thi nhảy Latin quốc gia Taoli Cup, giải Ngôi sao siêu mới nổi của Liên hoan nhạc Pop châu Á Hồng Kông, Nhóm nhạc xuất sắc nhất bảng xếp hạng âm nhạc lần thứ 4, Hạng ba môn múa Latin của thiếu niên 16 tuổi Nhóm của IDSF Grand Prix Thế giới, Nhà vô địch Khiêu vũ Latin chuyên nghiệp của Giải vô địch Khiêu vũ Quốc gia, Giải Vàng Kết hợp Siêu Chuông Vàng Âm thanh Trung Quốc

Giới thiệu: Tan Jianci (JC-T) sinh ngày 5 tháng 10 năm 1990 tại Thành phố Bắc Hải, Khu tự trị dân tộc Choang Quảng Tây. Ca sĩ, diễn viên. Thành viên của nhóm ca hát và nhảy múa Đại lục MIC. Anh chính thức ra mắt với tư cách là thành viên của nhóm nhạc nam MIC vào năm 2010.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733644730/4-dankienthu_k8qpxj.webp",

                },

                new Singer
                {
                    Name = @"Mao Bất Dịch/毛不易",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Siêu sao Mao, Maomao, Siêu sao nghiệp dư, Siêu sao, Mao Nao, Mao Tiantian, Đào nhỏ, Lão Mao, Amao, Ông Mao, Thầy Mao

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Tề Tề Cáp Nhĩ, tỉnh Hắc Long Giang

Ngày sinh: 1 tháng 10 năm 1994

Nghề nghiệp: Ca sĩ

Các tác phẩm tiêu biểu: “Xoa dịu nỗi buồn”, “Vay vốn”, “Cuộc sống thơm tho”, “Cảm giác như siêu sao”, “Nếu một ngày tôi trở nên rất giàu có”…

Thành tích chính: Nhà vô địch vòng chung kết quốc gia ""Con trai ngày mai"" 2017, Giải thưởng Ngôi sao âm nhạc trong Sách trắng của Tencent Entertainment 2017, Giải thưởng Sức mạnh âm nhạc mới thường niên của Tencent Video Starlight Awards 2017, Giải thưởng Thái độ thường niên NetEase 2017 Giải thưởng Ca sĩ-Nhạc sĩ có thái độ nhất trong năm, Giải thưởng Cá mập vàng đầu tiên năm 2018 Giải thưởng Top 10 ngôi sao đang lên trên Internet hàng năm, Giải thưởng Nam ca sĩ triển vọng nhất tại Lễ hội âm nhạc châu Á 2018, Giải thưởng Ca sĩ-Nhạc sĩ xuất sắc nhất hàng năm

Tên gốc: Wang Weijia

Giới thiệu: Mao Buyi, nam, trước đây gọi là Wang Weijia, đến từ Qiqihar, Hắc Long Giang. Một thí sinh của chương trình tạp kỹ ""Tomorrow's Son"" bước vào vòng solo của Xue Zhiqian với ca khúc gốc vui nhộn ""If One Day I Become Very Rich"" sau đó, anh ấy đã chinh phục được người hâm mộ với bài hát mạnh mẽ ""Xiaochou"" và được mọi người khen ngợi. được yêu thích. Bây giờ nó là một trong chín hãng lớn của ""Con trai ngày mai"". Tên hãng là Superstar Buyi Studio.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666051/5-maobatdich_zu3o1h.webp",
                },

                new Singer
                {
                    Name = @"Trương Bích Thần/张碧晨",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Diamond

Bí danh: Đại Mạnh, Nhị Đại, Trần Ca, Nhị Đại Thần, Boss, wuli Bichen, Zhang Wusui, Chen Chen

Quốc tịch: Trung Quốc

Nơi sinh: Thiên Tân

Ngày sinh: 10 tháng 9 năm 1989

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Nhẫn của năm”, “Giữa một nụ hôn”, “Cô ấy nói”, “Yêu định mệnh của em”

Thành tích chính: Quán quân The Voice of China mùa 3, Giải xuất sắc vòng chung kết K-POP World Celebration 2012, Quán quân K-POP World Celebration 2012 khu vực Trung Quốc, Ca sĩ mới xuất sắc nhất Liên hoan Âm nhạc Phương Đông lần thứ 22, Giải Huading xuất sắc nhất lần thứ 14 Ca sĩ mới nổi tiếng của năm ở Trung Quốc, 2014 Baidu Boiling Point Người mới xuất sắc nhất

Giới thiệu: Zhang Bichen, một nữ ca sĩ nhạc pop Trung Quốc, tốt nghiệp Đại học Nghiên cứu Quốc tế Thiên Tân.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666051/6-truongbichthan_tjlpsk.webp",
                },

                new Singer
                {
                    Name = @"Dã Khu Ca Thần/野区歌神",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Giới thiệu về ca sĩ hoang dã

Anh ấy yêu âm nhạc, thích hát cover và có phong cách hát tự học của Ye Luzi, khó nghe đến mức mọi người có thể dễ dàng trở nên sáng suốt sau khi nghe nó. Tôi không giỏi sáng tác và ca hát như nhiều người tài năng Tất cả những gì tôi có là kinh nghiệm của bản thân. Tôi có nhiều năng lượng tiêu cực và không có khả năng sảng khoái. Có lẽ bạn có thể nhớ lại bản thân và những điều của vài năm trước. trong tiếng hát của tôi.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666052/7-khudacatan_gnoimo.webp",
                },

                new Singer
                {
                    Name = @"Thôi Tử Cách/崔子格",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Cui Zige (Queena) sinh ra ở Urumqi, Tân Cương vào ngày 25 tháng 6 năm 1988. Cô tốt nghiệp Nhạc viện Hiện đại Bắc Kinh. Cô là một nữ diễn viên ở Trung Quốc Đại lục và là một nữ ca sĩ đa dạng đã chuyển từ sáng tạo sang sân khấu. Trong những năm đầu đời, anh sáng tác ""The Wedding Veil of Flowers"" cho Cyndi Wang. Năm 2012, anh bước sang sân khấu mạnh mẽ với các ca khúc như ""Bói toán"" và ""Người vợ lớn nhất"", đã đứng đầu các bảng xếp hạng lớn. và xuất bản tám album. Giành được Giải thưởng Nữ ca sĩ được yêu thích nhất của Mạng Migu, Giải thưởng Mười giai điệu vàng hàng đầu của QQ Music, Giải Giai điệu vàng Trung Quốc cho Album gốc hay nhất, Giải thưởng Mười giai điệu vàng hàng đầu của Kugou Fanxing và các giải thưởng khác. Cô cũng đã hát ca khúc chủ đề cho nhiều bộ phim điện ảnh và truyền hình lớn. Các tác phẩm tiêu biểu của cô bao gồm ca khúc chủ đề “The Princess's Promotion”, “Có thể nhớ nhưng không nói”, tập “Người đẹp | Mặt trời” của “Nirvana in”. Lửa"", và tập phim ""Thiếu nữ lộng lẫy"", ""Bộ sưu tập nến ngọc"", bài hát chủ đề của ""Người đẹp nhà Tần"", ""Sự sống và cái chết"", bài hát chủ đề của ""Tướng quân ở trên"", ""Tình yêu là Ở trên"", v.v.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666051/8-thoitucach_f48rjr.webp",
                },

                 new Singer
                {
                    Name = @"Diệp Lý/叶里",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Ye Li, sinh ra ở Thành Đô, Tứ Xuyên, là một nhạc sĩ gốc với chất giọng trầm, bùng nổ và âm vực rộng. Anh ấy là một nhạc sĩ được đề xuất trên nền tảng âm nhạc gốc của 5sing.

Thông tin cơ bản

Quốc tịch: Trung Quốc

Nơi sinh: Thành Đô, Tứ Xuyên

Nghề nghiệp: Nhạc sĩ

Các tác phẩm tiêu biểu: “Trạng thái lễ nghi”, “Saha”, “Khi chúng ta già đi”, v.v.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666052/9-dieply_z1z02n.webp",
                },

                  new Singer
                {
                    Name = @"Dư Chiêu Nguyên/余昭源",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Quận Triều Dương, Bắc Kinh

Sinh nhật: 15 tháng 3 năm 1989

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Cuộc gặp gỡ đầu tiên”

Giới thiệu: Yu Zhaoyuan, nam ca sĩ người Trung Quốc, nổi tiếng với siêu phẩm “First Meet”.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666052/10-duchieunguyen_yvkl2z.webp",
                },

                   new Singer
                {
                    Name = @"Trịnh Vân Long/郑云龙",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Đại Long

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Thanh Đảo, tỉnh Sơn Đông

Sinh nhật: 27 tháng 6 năm 1990

Nghề nghiệp: Diễn viên nhạc kịch, ca sĩ

Tác phẩm tiêu biểu: “Bác sĩ kỳ lạ”, “Tôi”, “Don Quixote”, “Lời thú tội dài”, “À! Guling"", ""Thân gửi""

Thành tích chính: Nam diễn viên nhạc kịch xuất sắc nhất tại Lễ trao giải Học viện Âm nhạc lần thứ 3 năm 2018, đứng thứ 51 trong 100 gương mặt mới đẹp nhất Trung Quốc của LikeTCCAsia năm 2019, được chọn vào Danh sách ưu tú dưới 30 tuổi của Forbes Trung Quốc năm 2019, 2020 Giải thưởng Nghệ thuật biểu diễn và kịch nghệ Thượng Hải lần thứ 30 ""Giải thưởng nhân vật chính mới"", Giải thưởng Nam diễn viên mới xuất sắc nhất thường niên của Liên hoan phim Mỹ-Trung lần thứ 17 năm 2021, Giải Ca sĩ đột phá nhất Billboard phương Đông lần thứ 29 năm 2022, Giải Ca sĩ từ thiện thứ 28 của năm trong "" Biển quảng cáo phương Đông""

Giới thiệu: Zheng Yunlong, một diễn viên và ca sĩ nhạc kịch đến từ Trung Quốc đại lục, tốt nghiệp Khoa Sân khấu Nhạc kịch của Học viện Múa Bắc Kinh năm 2009.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666062/11-trinhvanlong_ounvxv.webp",
                },

                     new Singer
                {
                    Name = @"Hoàng Thi Phù/黄诗扶",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Đại hoàng, Tiên vàng

Quốc tịch: Trung Quốc

Nơi sinh: Thượng Hải

Sinh nhật: 8 tháng 5

Nghề nghiệp: Ca sĩ-nhạc sĩ, ca sĩ

Tác phẩm tiêu biểu: “Chín vạn chữ”, “Thế gian không đáng”, “Nhiếp Hải Cơ”

Giới thiệu: Huang Shifu, nhạc sĩ và ca sĩ, học âm nhạc từ nhỏ và tốt nghiệp Đại học Bristol ở Anh.

Sự nghiệp nghệ thuật: Từ năm 2014 đến 2016, anh là nhạc sĩ Gaohu trong Dàn nhạc Quốc gia Jasmine của Cung điện Thành phố Thượng Hải.

Từ năm 2017 đến 2018, anh sáng tác các bài hát cho đĩa đơn “Huaisha” của ca sĩ Dong Zhen, đĩa đơn “The People Outside the Story” của Mu Han, ca khúc “Backwater Cold” của trò chơi NetEase “Bihaiwenzhou”, trò chơi NetEase “Huizhen·Miaobi Qianshan” ""Yin Lin biểu diễn ca khúc chủ đề ""Miaobi Fusheng"" và sáng tác nhạc.

Năm 2019, anh chính thức chuyển hướng từ nhà sản xuất hậu trường sang ca sĩ; vào tháng 1, anh phát hành album nhạc đầu tiên “The World Is Not Worth It”, bao gồm các ca khúc “Ninety Thousand Words”, “Exploring Qingshui River”. "", vân vân.

Tháng 1 năm 2020, anh phát hành album thứ hai ""Qing Qing and You"" (Dream and Wake Up); vào tháng 3, anh sáng tác và hát tập ""Xuxu"" cho bộ phim truyền hình ""Three Thousand Crows"" vào tháng 4, anh He is; nhà soạn nhạc điện ảnh và truyền hình xen kẽ ""Every Tear Is a Star"" và ""Moonlight"" cho bộ phim truyền hình ""The Road to Awakening"";",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666051/12-hoangthiphu_pxe4p6.webp",
                },

                      new Singer
                {
                    Name = @"Yêu Dương/王敬轩 (妖扬)",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Yaoyang, Yangyang

Quốc tịch: Trung Quốc

Nơi sinh: Bản Hi, Liêu Ninh

Sinh nhật: 2 tháng 6 năm 1993

Nghề nghiệp: Ca sĩ, diễn viên, người mẫu, diễn viên lồng tiếng

Giới thiệu: Wang Jingxuan sinh ra ở Benxi, tỉnh Liêu Ninh. Anh tốt nghiệp Đại học Sư phạm Liêu Ninh chuyên ngành phát thanh truyền hình và dẫn chương trình. Anh là một diễn viên, ca sĩ cổ trang, người mẫu và diễn viên lồng tiếng người Trung Quốc.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733666051/13-yeuduong_abrjpa.webp",
                },

                       new Singer
                {
                    Name = @"Lộc Hàm/鹿晗",
                    Gender = Gender.Male,
                    Introduction = @"Tên tiếng Hàn: 루한

Bí danh: Hươu buổi sáng, Hươu cỏ, Hươu Hani, Hươu hươu, Hươu trứng ngớ ngẩn

Quốc tịch: Trung Quốc

Nơi sinh: Quận Hải Điến, Bắc Kinh

Ngày sinh: 20/04/1990

Nghề nghiệp: Ca sĩ, diễn viên

Tác phẩm tiêu biểu: phim “20 Again”; album “Reloaded”; ca khúc “Our Tomorrow”, “Sweet Honey”, “Medal”",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733669395/15-locham_s7t2vq.webp",
                },

                       new Singer
                {
                    Name = @"Ngô Thanh Phong/吴青峰",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Qing Feng Wu

Bí danh: Mr. Cat

Quốc tịch: Trung Quốc

Quốc tịch: Hán

Nơi sinh: Thành phố Đài Bắc, tỉnh Đài Loan

Ngày sinh: 30/08/1982

Nghề nghiệp: Ca sĩ, nhà soạn nhạc, người viết lời

Tác phẩm tiêu biểu: album ""Spaceman"", đĩa đơn ""Everybody Woohoo"", ""The Wind Rises"", ""Hummingbird"", ""Singer"", ""Window""...",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733674754/14-ngothanhphong_bl3tfq.webp",
                },

                       new Singer
                {
                    Name = @"Hồ Hạ/胡夏",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Hồ Hạ

Bí danh: Hồ Hiểu Hạ, Hạ Hạ, Tiểu Hạ, Thanh Tuyền vương

Quốc tịch: Trung Quốc

Nơi sinh: Khu tự trị dân tộc Choang Quảng Tây

Ngày sinh: 1 tháng 3 năm 1990

Nghề nghiệp: Ca sĩ, diễn viên

Các tác phẩm tiêu biểu: “Những Năm Đó”, “Mùa Hè Tình Yêu”, “Randian”, “Khi Em Lắng Nghe Anh”, “Truyện Cổ Buồn”, “Kính Gọng Đen”, “Tĩnh Điện”...

Thành tích chính: Nhà vô địch Super Avenue of Stars Đài Loan lần thứ 6, Giải thưởng Nghệ sĩ mới xuất sắc nhất Giải Giai điệu vàng Singapore lần thứ 17, Giải Bài hát được yêu thích nhất của Giới âm nhạc Hồng Kông, Giải thưởng Người mới xuất sắc nhất của năm tại Liên hoan CCTV-MTV tại Trung Quốc đại lục, Bảng xếp hạng âm nhạc lần thứ 12 Giải thưởng người mới xuất sắc nhất

Giới thiệu ngắn gọn: Hu Xia, sinh ngày 1 tháng 3 năm 1990 tại quận Xixiangtang, thành phố Nam Ninh, Khu tự trị dân tộc Choang Quảng Tây, là một ca sĩ và diễn viên.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734448656/16-hoha_cix3pp.webp",
                },

                       new Singer
                {
                    Name = @"Lạc Tiểu Đào/乐小桃",
                    Gender = Gender.Female,
                    Introduction = @"Cảm ơn mọi người đã lắng nghe❤",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734479562/17-lactieudao_c0vyca.webp",
                },
            };

            context.Singers.AddRange(singers);
            await context.SaveChangesAsync();

        }
    }
}
