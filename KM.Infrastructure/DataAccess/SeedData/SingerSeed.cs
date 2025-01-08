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

                        new Singer
                {
                    Name = @"G.E.M. Đặng Tử Kỳ/G.E.M. 邓紫棋",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: GEM (Get Everybody Move), Gloria Tang

Bí danh: Cá vàng, GEM, Đặng Bảo, Qibao, Gloria, Qiqi, Cá vàng nhỏ, Cá vàng GEM, Phổi nhỏ, Jiejie

Tên gốc: Đặng Thế Anh

Quốc tịch: Trung Quốc

Nơi sinh: Thượng Hải

Ngày sinh: 16/08/1991

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Công chúa ngủ trong rừng”, “Đồng hồ cát ký ức”, “AINY”, “Bí mật của tôi”, “Bong bóng”, “Phép màu”, “Thỉnh thoảng”",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736251521/dangtuky_mnydtt.webp",
                },

                new Singer
                {
                    Name = @"Thỏ Khỏa Tiên Đản Quyển/兔裹煎蛋卷",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Ca sĩ. Tác phẩm tiêu biểu “Ngõ Yến Hội”, “Đợi gió chờ hoàng hậu” và “Khi hoa rơi Trường An”",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736251814/Th%E1%BB%8F_Kh%E1%BB%8Fa_Ti%C3%AAn_%C4%90%E1%BA%A3n_Quy%E1%BB%83n_x7euh6.webp",
                },

                new Singer
                {
                    Name = @"Ngạo Hàn Đồng Học/傲寒同学",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Sinh nhật: 15 tháng 11 năm 1996

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Lovesickness Order”",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736252441/Ng%E1%BA%A1o_H%C3%A0n_%C4%90%E1%BB%93ng_H%E1%BB%8Dc_f0tfeq.webp",
                },
                

                new Singer
                {
                    Name = @"Tiểu Khúc Nhi/小曲儿",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Xiao Qu'er là một ca sĩ kiêm nhạc sĩ nhạc cổ điển nổi tiếng. Với giọng hát dễ nhận biết và kỹ năng ca hát tuyệt vời, anh đã hình thành một phong cách ca hát độc đáo và khá nổi tiếng trong giới âm nhạc cổ xưa.",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736254870/tieukhucnhi_vuiktw.webp",
                },

                new Singer
                {
                    Name = @"Trương Lương Dĩnh/张靓颖",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Jane Zhang, 장량잉, ジェーン・チャン (tiếng Nhật), Джейн Чжан (tiếng Nga)",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736255179/truongluongdinh_fweawh.webp",
                },

                new Singer
                {
                    Name = @"Song Sênh/双笙 (陈元汐)",
                    Gender = Gender.Female,
                    Introduction = @"Tên thật: Chen Yuanxi

Quốc tịch: Trung Quốc

Nơi sinh: Quận Khai Châu, thành phố Trùng Khánh",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736255548/songsenh_zzq2in.webp",
                },

                new Singer
                {
                    Name = @"Châu Thâm/周深",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Charlie

Bí danh: Kabu, Kabula

Quốc tịch: Trung Quốc

Nơi sinh: thành phố Thiệu Dương, tỉnh Hồ Nam

Sinh nhật: 29 tháng 9 năm 1992

Nghề nghiệp: Ca sĩ, nhà sản xuất âm nhạc",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736255889/chautham_akcbtw.webp",
                },

                new Singer
                {
                    Name = @"Vương Tâm Lăng/王心凌",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Cyndi Wang

Bí danh: Wang Junru, Maru Xini

Quốc tịch: Trung Quốc

Nơi sinh: Huyện Hsinchu, tỉnh Đài Loan, Trung Quốc

Ngày sinh: 5 tháng 9 năm 1982",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736256232/vuongtamlang_iooa2l.webp",
                },

                new Singer
                {
                    Name = @"Trương Viễn/张远",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Chim

Bí danh: Ruanruan, Xiaoyuan, Yuanqiu

Quốc tịch: Trung Quốc

Nơi sinh: Huyện Fengyang, thành phố Chuzhou, tỉnh An Huy

Sinh nhật: 02/06/1985

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736256332/truongvien_etrzpd.webp",
                },

                new Singer
                {
                    Name = @"Da LAB",
                    Gender = Gender.Male,
                    Introduction = @"Nơi bạn sẽ tìm thấy âm nhạc của Da LAB",
                    Location = "Việt Nam",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736257384/dalab_mkcswj.jpg",
                },

                new Singer
                {
                    Name = @"Suni Hạ Linh",
                    Gender = Gender.Female,
                    Introduction = @"Nơi Suni chia sẻ những sản phẩm âm nhạc, video đời sống đến với khán giả. ",
                    Location = "Việt Nam",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736257933/sunihalinh_razurf.jpg",
                },

                new Singer
                {
                    Name = @"Rhymastic",
                    Gender = Gender.Male,
                    Introduction = @"...",
                    Location = "Việt Nam",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258044/rymatic_uakk0j.jpg",
                },

                new Singer
                {
                    Name = @"Nhậm Nhiên",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Thành Đô, tỉnh Tứ Xuyên

Ngày sinh: 3 tháng 7 năm 1989

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258551/nhamnien_zpiz7x.webp",
                },

                new Singer
                {
                    Name = @"Trương Kiệt",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Jason

Bí danh: Zhang Xiaojie

Quốc tịch: Trung Quốc

Nơi sinh: Thành Đô, Tứ Xuyên

Sinh nhật: 20/12/1982

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736259090/truongkiet_idlyhm.webp",
                },

                new Singer //
                {
                    Name = @"Lý Tiêu Minh/李潇鸣",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Thạc sĩ nghiên cứu giảng dạy và ca hát đại chúng tại Nhạc viện Tây An",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306805/lytieuminh_to3fob.webp",
                },

                new Singer //
                {
                    Name = @"Thiện Y Thuần/单依纯",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Xiaodan, Yichun

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Dongyang, tỉnh Chiết Giang

Sinh nhật: 23 tháng 12 năm 2001

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306803/thienythuan_xmijmh.webp",
                },

                new Singer //
                {
                    Name = @"Hoàng Tiêu Vân/黄霄雲",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Guigui, Nữ hoàng Guigui, Agui, Bánh mì, Cô gái bánh mì

Quốc tịch: Trung Quốc

Nơi sinh: Thị trấn Longping, huyện Luodian, quận tự trị Qiannan Buyi và Miao, tỉnh Quý Châu

Sinh nhật: 22/12/1998

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306803/hoangtieuvan_lzt96c.webp",
                },

                new Singer //
                {
                    Name = @"Lưu Vũ Ninh/刘宇宁",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Xiao Ning, anh Ning

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Đan Đông, tỉnh Liêu Ninh

Ngày sinh: 8 tháng 1 năm 1990

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306802/luuvuninh_pppfxb.webp",
                },

                new Singer //
                {
                    Name = @"Thì Thượng/时尚",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Thời trang, sinh ra ở thành phố Tế Ninh, tỉnh Sơn Đông, nam ca sĩ, nhạc sĩ và nhà sản xuất âm nhạc nhạc pop Trung Quốc.

Năm 2020, anh là thực tập sinh của Thanh Xuân Có Bạn 3.

Năm 2021, các học trò của đội Hacken Li tại ""The Voice of China""",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306801/trithuong_jt5vuk.webp",
                },

                new Singer //
                {
                    Name = @"Vương Trình Chương/王呈章",
                    Gender = Gender.Female,
                    Introduction = @"Tên tiếng Trung: Wang Chengzhang

Bí danh: Trương Bảo

Quốc tịch: Trung Quốc

Nơi sinh: Vu Hồ, An Huy",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306801/vuongchinhtruong_o8rzuh.webp",
                },

                new Singer //
                {
                    Name = @"Diệp Huyền Thanh/叶炫清",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Qingqing, Xiaoyezi, Qinger

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Thặng Châu, tỉnh Chiết Giang

Ngày sinh: 2 tháng 3 năm 1998

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306800/diephuyenthanh_vefhdt.webp",
                },

                new Singer //
                {
                    Name = @"HITA",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Chị Tạ

Quốc tịch: Trung Quốc

Nơi sinh: Bắc Kinh

Sinh nhật: 26/12/1984

Nghề nghiệp: Ca sĩ, biên tập viên tạp chí",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306797/hita_jcuua9.webp",
                },

                new Singer //
                {
                    Name = @"Tiểu Ái Đích Mụ/小爱的妈",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Emma

Quốc tịch: Trung Quốc

Sinh nhật: ngày 9 tháng 1

Nghề nghiệp: Ca sĩ, họa sĩ minh họa",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306797/tieuaidichmu_uw5k9a.webp",
                },

                new Singer //
                {
                    Name = @"Tiêu Ức Tình/萧忆情Alex",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Alex

Bí danh: Tiên Nhi, Tiên Ngỗng, Wo Điểu, Ngỗng Vương

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Sâm Châu, tỉnh Hồ Nam

Sinh nhật: 14/06/1988

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306796/tieuuctinh_x9h7vd.webp",
                },

                new Singer //
                {
                    Name = @"Kim Chí Văn/金志文",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: 김지문, Kim Ji-mun

Bí danh: Xiaowen, Anh Xiaowen

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Cát Lâm, tỉnh Cát Lâm

Ngày sinh: 12 tháng 7 năm 1982

Nghề nghiệp: Ca sĩ, nhà sản xuất",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306796/kimchivan_xdygw4.webp",
                },

                new Singer //
                {
                    Name = @"Cát Khắc Tuyển Dật/吉克隽逸",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Summer

Bí danh: Wang Junyi

Quốc tịch: Trung Quốc

Nơi sinh: Huyện Ganluo, tỉnh Lương Sơn, tỉnh Tứ Xuyên

Sinh nhật: 13 tháng 5 năm 1988

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306797/catkhactuyendat_kgnbeo.webp",
                },

                new Singer //
                {
                    Name = @"Lục Hổ/陆虎",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: LT

Bí danh: Huji

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Chu Khẩu, tỉnh Hà Nam

Ngày sinh: 24/4/1986 (16/3 âm lịch)",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306796/lucho_ihcjqh.webp",
                },

                new Singer //
                {
                    Name = @"Tỉnh Lung/井胧",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Thẩm Dương, tỉnh Liêu Ninh

Ngày sinh: 7 tháng 7 năm 1997

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306796/tinhlung_uimdir.webp",
                },

                new Singer //
                {
                    Name = @"Úc Khả Duy/郁可唯",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Yisa

Tên gốc: Yu Yingxia

Bí danh: Xiaoyu, Kewei, Melancholy Duner, Rabbit

Quốc tịch: Trung Quốc

Nơi sinh: Thành Đô, tỉnh Tứ Xuyên

Ngày sinh: 23/10/1983

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736307292/uckhaduy_q8o2wf.webp",
                },

                new Singer //
                {
                    Name = @"Phó Dung/代号鸢",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Nhóm âm thanh Codename Kite Studio",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306830/phodung_ey4bhp.webp",
                },

                new Singer //
                {
                    Name = @"Lưu Đào/刘涛",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Tamia Liu

Bí danh: Taotao, chị Tao

Quốc tịch: Trung Quốc

Nơi sinh: Quận Tây Hồ, thành phố Nam Xương, tỉnh Giang Tây

Ngày sinh: 12/07/1978

Nghề nghiệp: Diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306829/luudao_ajmoyw.webp",
                },

                new Singer //
                {
                    Name = @"Vạn Linh Lâm/万玲琳",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Wan Lingling, biệt danh Long Live Lord, là một nhạc sĩ và ca sĩ nhạc pop hậu thập niên 90. Các tác phẩm tiêu biểu của cô bao gồm ""Can't Sleep"", ""Bee Demo"", v.v.",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306828/vanlinhtam_ujxb57.webp",
                },

                new Singer //
                {
                    Name = @"Hoắc Tôn/霍尊",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Henry

Bí danh: Zunzun, Hoắc Thập Tam, Tiểu Hỏa Hỏa

Quốc tịch: Trung Quốc

Nơi sinh: Thượng Hải

Sinh nhật: 18 tháng 9 năm 1990

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306828/hoacton_ketpzj.webp",
                },

                new Singer //
                {
                    Name = @"Lý Mậu/李茂",
                    Gender = Gender.Male,
                    Introduction = @"Họ tên: Lý Mậu

Chiều cao: 182cm

Quốc tịch: Trung Quốc

Ngày sinh: 02/06/1986

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306826/lymau_mr0t1k.webp",
                },

                new Singer //
                {
                    Name = @"Bạch Kính Đình/白敬亭",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Tiểu Bạch

Quốc tịch: Trung Quốc

Quốc tịch: Mãn Châu

Nơi sinh: Bắc Kinh

Sinh nhật: 15 tháng 10 năm 1993

Nghề nghiệp: Diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306826/bachkinhdinh_snrqnt.webp",
                },

                new Singer //
                {
                    Name = @"Dĩ Đông/以冬",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Vui lòng nhập phần giới thiệu của nhạc sĩ vào đây~",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306825/didong_pby8xt.webp",
                },

                new Singer //
                {
                    Name = @"Đẳng Thập Ma Quân/等什么君",
                    Gender = Gender.Female,
                    Introduction = @"Tên thật: Đặng Yujun

Quốc tịch: Trung Quốc

Nơi sinh: Tỉnh Cát Lâm

Sinh nhật: 16/12/1999

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306824/dangthapmaquan_xrzlzt.webp",
                },

                new Singer //
                {
                    Name = @"Viên Á Duy/袁娅维 TIA RAY",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Tia Ray

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Hoài Hóa, tỉnh Hồ Nam

Ngày sinh: 12/12/1984

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306824/vienaduy_oetnco.webp",
                },

                new Singer //
                {
                    Name = @"Tưởng Long/蒋龙",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Thẩm Dương, tỉnh Liêu Ninh

Ngày sinh: 22/03/1995

Nghề nghiệp: Diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306822/tuonglong_hgctnv.webp",
                },

                new Singer //
                {
                    Name = @"Doãn Lộ Hy/尹露浠",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Bắc Kinh

Nghề nghiệp: Ca sĩ

Giới thiệu: Yin Luxi, một nghệ sĩ được Haolewuhuang ký hợp đồng, tốt nghiệp Đại học Kyung Hee ở Hàn Quốc. Tác phẩm đại diện: ""7710""",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306823/doanlohi_tjbzu1.webp",
                },

                new Singer //
                {
                    Name = @"Trương Tử Ninh/张紫宁",
                    Gender = Gender.Female,
                    Introduction = @"Tên nước ngoài: Winnie

Quốc tịch: Trung Quốc

Nơi sinh: Thành Đô, Tứ Xuyên

Sinh nhật: 9 tháng 3 năm 1996

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306821/truongtuninh_imjh8f.webp",
                },

                new Singer //
                {
                    Name = @"Ngũ Sắc Thạch Nam Diệp/五色石南葉",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Anh Năm | Lao Wu | Ngũ Sắc Nanshiye |

Quốc tịch: Trung Quốc

Nghề nghiệp: Diễn viên lồng tiếng",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306821/ngusacthachnamdiep_wffjh3.webp",
                },

                new Singer //
                {
                    Name = @"Ngải Thần/艾辰",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: AI Chen

Quốc tịch: Trung Quốc

Nơi sinh: Liên Vân Cảng, Giang Tô

Ngày sinh: 11 tháng 7 năm 1995

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306819/ngaithan_tjbmrf.webp",
                },

                new Singer //
                {
                    Name = @"Nam Tê/南栖",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Nan Qi, nữ ca sĩ đến từ Trung Quốc đại lục, được biết đến với các tác phẩm tiêu biểu như ""Put in the Air"", ""Siri"" và ""Rainy Day"".",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306819/namte_wqvs61.webp",
                },

                new Singer //
                {
                    Name = @"Uông Tô Lang/汪苏泷",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Silence.W

Bí danh: Kotaki

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Thẩm Dương, tỉnh Liêu Ninh

Ngày sinh: 17 tháng 9 năm 1989

Nghề nghiệp: Nhạc sĩ, quản lý thương hiệu thời trang",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306818/uongtolang_swg5we.webp",
                },

                new Singer //
                {
                    Name = @"Winky 诗",
                    Gender = Gender.Male,
                    Introduction = @"Bí danh: Xiaoshi, giám sát

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Tuy Hóa, tỉnh Hắc Long Giang

Sinh nhật: 18 tháng 1 năm 1991

Nghề nghiệp: Nhạc sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306818/winky_vklyas.webp",
                },

                new Singer //
                {
                    Name = @"Diêu Hiểu Đường/姚晓棠",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Shanwei, tỉnh Quảng Đông

Ngày sinh: 11 tháng 9 năm 1998

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306816/dieuhieuduong_nlz25e.webp",
                },

                new Singer //
                {
                    Name = @"ycccc",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Tôi hy vọng âm nhạc của tôi có thể làm cho thế giới trở nên tốt đẹp hơn.",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306815/ycccc_pzd8rz.webp",
                },

                new Singer //
                {
                    Name = @"Bunnyi_11/单循",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Người Phụ Nữ Hát Sống Động 02 Song Tử

Business Xiii_1231 (không phải mục đích chuyến thăm của tôi)",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306815/Bunnyi_11_lztcfy.webp",
                },

                new Singer //
                {
                    Name = @"Vương Tĩnh Văn/王靖雯",
                    Gender = Gender.Female,
                    Introduction = @"Bí danh: Wang Jingwen không béo

Quốc tịch: Trung Quốc

Nơi sinh: Cáp Nhĩ Tân, Hắc Long Giang

Ngày sinh: 5 tháng 4 năm 2001

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306815/vuongtinhvan_yooe09.webp",
                },

                 new Singer //
                {
                    Name = @"Cái Quân Viêm/盖君炎",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Chậm rãi”, “Tôi Muốn”

Giới thiệu: Gai Junyan là nam ca sĩ cover người Trung Quốc, người đã xuất bản các tác phẩm như ""Slowly"" và ""I Want"".",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306814/caiquanviem_huxaqq.webp",
                },

                 new Singer //
                {
                    Name = @"Trình Hưởng/程响",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Hoài Nam, tỉnh An Huy

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306812/trinhhuong_txqrg5.webp",
                },

                 new Singer //
                {
                    Name = @"Trì Ngư/池鱼",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: “Kinh”

Giới thiệu: Một nàng tiên nhỏ sinh vào những năm 00 hát nhạc cover.",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306812/tringu_bgmlqp.webp",
                },

                 new Singer //
                {
                    Name = @"Hồ Ngạn Bân/胡彦斌",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Tiger Hu

Bí danh: Binbin, Tiger, Brother Tiger

Quốc tịch: Trung Quốc

Nơi sinh: Thượng Hải

Ngày sinh: 4 tháng 7 năm 1983

Nghề nghiệp: Ca sĩ, nhạc sĩ, nhà sản xuất âm nhạc",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306811/honganban_xdio15.webp",
                },

                 new Singer //
                {
                    Name = @"KHIẾU BẢO BẢO/叫宝宝",
                    Gender = Gender.Female,
                    Introduction = @"Quốc tịch: Trung Quốc

Nghề nghiệp: Ca sĩ

Tác phẩm tiêu biểu: ""Song Ngư""

Giới thiệu: Gọi là Baobao, một cô gái theo đạo Phật thích phong cách cổ xưa. Tác phẩm tiêu biểu: ""Song Ngư""",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306810/khieubaobao_qaydam.webp",
                },


                 new Singer //
                {
                    Name = @"TƯỜNG LẶC LẶC/祥嘞嘞",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Xiang Le Le, giọng nam nhẹ nhàng, bình dân, phong cách cổ trang",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306809/tuonglaclac_egjzpw.webp",
                },

                 new Singer //
                {
                    Name = @"Hầu Minh Hạo/侯明昊",
                    Gender = Gender.Male,
                    Introduction = @"Hồ sơ ca sĩ
Tên nước ngoài: Neo

Quốc tịch: Trung Quốc

Nơi sinh: Bắc Kinh

Ngày sinh: 3 tháng 8 năm 1997

Nghề nghiệp: Ca sĩ, diễn viên",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306809/hauminhhao_v9i22t.webp",
                },

                 new Singer //
                {
                    Name = @"Trần Gia Kỳ/陈家淇",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nghề nghiệp: Nhạc sĩ

Thành tích chính: Huy chương vàng cuộc thi ca sĩ Tam Giang Hàng Châu, Huy chương vàng nhóm nổi tiếng cuộc thi thanh nhạc quốc tế Osaka tại Nhật Bản, tài năng nổi bật trong cuộc thi biểu diễn thanh nhạc toàn quốc lần thứ 14

Giới thiệu: Chen Jiaqi, một nhạc sĩ đại lục. Tốt nghiệp Nhạc viện Chiết Giang.",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306808/trangiaky_z3nh3k.webp",
                },

                  new Singer //
                {
                    Name = @"Hắc Kỳ Tử/黑崎子",
                    Gender = Gender.Male,
                    Introduction = @"Giới thiệu: Người này lười biếng và không để lại gì",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306806/hackytu_j4ewxk.webp",
                },

                  new Singer //
                {
                    Name = @"Bất Tài/不才",
                    Gender = Gender.Female,
                    Introduction = @"Giới thiệu: Tôi muốn thu âm giọng hát của chính mình nhưng không hát thì sẽ già.",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736306806/battai_gbcyux.webp",
                },

                  new Singer //
                {
                    Name = @"Trương Lỗi/张磊",
                    Gender = Gender.Male,
                    Introduction = @"Tên tiếng Trung: Zhang Lei

Bí danh: Dalei, Anh Lôi

Quốc tịch: Trung Quốc

Nơi sinh: Thành phố Mẫu Đơn Giang, tỉnh Hắc Long Giang

Ngày sinh: 7 tháng 10 năm 1981

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312204/truongloi_ikcy56.webp",
                },

                   new Singer //
                {
                    Name = @"Dương Tông Vỹ/杨宗纬",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: Aska Yang

Bí danh: Ace Pigeon

Quốc tịch: Trung Quốc

Nơi sinh: huyện Đào Viên, tỉnh Đài Loan

Ngày sinh: 4/4/1978

Nghề nghiệp: Ca sĩ",
                    Location = "Trung Quốc",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736312126/duongtongvy_n8gnwp.webp",
                },
            };

            context.Singers.AddRange(singers);
            await context.SaveChangesAsync();

        }
    }
}
