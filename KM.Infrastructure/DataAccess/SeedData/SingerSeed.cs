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
                    ImgUrl = @"https://y.qq.com/music/photo_new/T001R300x300M000003ZJvIV3mipIY_4.jpg?max_age=2592000",

                },
                new Singer
                {
                    Name = @"Huyền Tử/弦子",
                    Gender = Gender.Female,
                    Introduction = @"Tên tiếng Trung: 张弦子/Zhang Xianzi

Tên nước ngoài: Stringer

Quốc tịch: Trung Quốc

Nơi sinh: Huyện Debao, thành phố Baise, khu tự trị dân tộc Choang Quảng Tây

Ngày sinh: 22/04/1986

Nghề nghiệp: Ca sĩ, diễn viên

Tác phẩm tiêu biểu: “Gió say”, “Phải yêu”, “Bất đắc dĩ”, “Ngây thơ”, “Hoa hồng ngược gió”, “Yêu em trước ngày hết hạn”

Thành tích chính: Bảng xếp hạng TOP Trung Quốc năm 2013 Nghệ sĩ toàn năng đại lục Bảng xếp hạng phương Đông lần thứ 16 Giải thưởng Top 10 Giai điệu vàng 2009 Bảng xếp hạng bài hát Trung Quốc Hàng năm Nữ ca sĩ xuất sắc nhất, Nhà soạn nhạc xuất sắc nhất, Giai điệu vàng hàng năm (được đề cử) Giải Bạc Người mới đến Phương Đông lần thứ 14 Giải Bạc 9+2 Tiên phong Âm nhạc Liệt kê Lực lượng mới hàng năm trong giới âm nhạc Trung Quốc Xếp hạng HÀNG ĐẦU Giải thưởng Nghệ sĩ mới biểu diễn xuất sắc nhất Đại lục, Giải thưởng được yêu thích tại trường đại học

Giới thiệu: Xianzi, tốt nghiệp Học viện đào tạo âm nhạc hiện đại Bắc Kinh, là nữ ca sĩ, diễn viên nổi tiếng người Trung Quốc.

Năm 2004, anh nhận được sự ủng hộ của cư dân mạng trên Internet khi hát ca khúc ""Drunken Breeze"". Năm 2005, cô được nhà sản xuất Đài Loan Chen Zihong phát hiện và ký hợp đồng với tư cách ca sĩ. Sau đó, cô hát ""Have to Love"" với Wilber Pan và được chú ý nhiều hơn. Năm 2006, anh phát hành album đầu tiên ""Mũi tên trên dây"". Năm 2007, Xianzi đã giành được Giải Bạc cho Người mới đến Phương Đông của Bảng xếp hạng Phương Đông lần thứ 14 và lọt vào danh sách rút gọn cho Giải Giai điệu Vàng Đài Loan cho Người mới xuất sắc nhất. Vào tháng 11 năm 2011, album thứ tư ""Rose Against the Wind"" đã được phát hành. Năm 2013, anh tham gia chương trình tạp kỹ ""China Star Jump"" và giành chức vô địch. Tháng 8 cùng năm, anh phát hành album thứ năm ""Looking Away"". Năm 2014, anh tham gia chương trình tạp kỹ ""The Variety Show"" và đóng vai chính trong vở nhạc kịch dành cho giới trẻ ""My Youth High Octave"". Vào tháng 4, Xianzi, người đã phát triển toàn diện trong lĩnh vực điện ảnh, truyền hình, thu âm và chương trình tạp kỹ, đã giành được giải thưởng nghệ sĩ toàn diện trong bảng xếp hạng TOP của Trung Quốc. Năm 2015, Xianzi đóng vai chính trong các bộ phim truyền hình đầy cảm hứng thành thị ""Bí mật xinh đẹp"" và ""Chị em"". Năm 2017, Xianzi đã hát những ca khúc giàu cảm xúc cho ""The Legend of the Destiny"" và ""The Legend of Chu Qiao"". Năm 2018, đĩa đơn trở lại ""Like"" được phát hành. Năm 2019, tại Gala Lễ hội mùa xuân của CCTV, Xianzi đã hát bài hát ""Cùng nhau xây dựng giấc mơ Trung Hoa"" cùng với Cao Fujia, Ayunga, Ju Laiti và Ang Sa. Năm 2020, bộ phim truyền hình ""Đổ lỗi cho bạn quá đẹp"" có sự tham gia của nó đã được phát sóng. Ngày 21 tháng 1 năm 2021, anh tham gia mùa thứ hai của ""Chị Cưỡi Gió Và Sóng"". Ngày 4 tháng 2, anh tham gia và hát bộ phim ""My Time, Your Time"" và nhạc phim gốc truyền hình được phát sóng chính thức vào ngày 6 tháng 9; và Li Baht Họ cùng phát hành đĩa đơn ""Remember Tonight"". Vào ngày 1 tháng 2 năm 2022, anh tham gia ""Dạ tiệc Lễ hội mùa xuân truyền hình vệ tinh Quảng Đông khu vực vịnh lớn năm 2022"". Vào ngày 27 tháng 6, anh đã tham gia buổi phát sóng trực tiếp bài hát trên đám mây ""Our Bauhinia"" do People's Daily New Media, Trung tâm truyền thông tích hợp Kênh Phim và 1905 Movie Network đồng phát động. Vào ngày 19 tháng 6 năm 2023, bộ phim truyền hình ""She Shines"", với Xianzi hát bài hát chủ đề mở đầu ""Be Your Own Light"", đã được ra mắt. Ngày 24 tháng 10, đĩa đơn ""Brilliant Monsoon"" được phát hành. Ngày 30/11, bộ phim truyền hình “Anh nhớ em nhiều lắm” với sự góp mặt của khách mời đặc biệt đã ra mắt. Vào ngày 24 tháng 2 năm 2024, anh tham gia ""Dạ tiệc Lễ hội đèn lồng của Đài Phát thanh và Truyền hình Trung ương Trung Quốc năm 2024"" và hát ""Forever We Are a Family"" cùng Cao Lei, Wu Kequn, Li Hongmei và những người khác. Ngày 27/3, chương trình ""100% Singer"" mà cô tham gia đã lên sóng.

Sự nghiệp nghệ thuật: Năm 2004, Xianzi đã giúp một người bạn thu âm ca khúc ""Drunken Breeze"". Sau khi bài hát được tung lên mạng đã nhận được sự ủng hộ của rất nhiều cư dân mạng. Bài hát này đã mang lại cho Xianzi sự nổi tiếng và khiến Xianzi hiểu những gì anh ấy muốn làm: hát những bài hát của chính mình, hoặc để người khác hát những bài hát của chính mình.

Tháng 6 năm 2005, anh được nhận vào Nhạc viện Tinh Hải nhưng đã bỏ học và sang Bắc Kinh học (Khoa Sản xuất Âm nhạc, Trường Truyền thông Âm nhạc, Học viện Âm nhạc Hiện đại Bắc Kinh). Sau đó, anh được nhà sản xuất Đài Loan Chen Zihong phát hiện và ký hợp đồng trở thành ca sĩ yêu âm nhạc. Cùng năm, cô hát ca khúc Have to Love cùng Wilber Pan và giọng hát tươi trẻ của cô đã nhận được sự chú ý rộng rãi.

Vào ngày 20 tháng 10 năm 2006, anh phát hành album solo đầu tiên ""Arrow on the String"". Album có tổng cộng 10 bài hát, chủ yếu là nhạc rock. Với album này, Xianzi đã được đề cử cho ""Giải thưởng Người mới xuất sắc nhất"" tại Lễ trao giải Giai điệu vàng Đài Loan năm 2007. Tháng 6 năm 2007, Xianzi hát ca khúc ""Dad"" với Dick Cowboy và thu âm MV. Cùng năm đó, Xianzi đóng vai chính trong bộ phim truyền hình hồi hộp điều tra tội phạm ""Deep Eyes"", người lần đầu tiên được tiếp xúc với phim truyền hình, vào vai một ca sĩ trẻ có tính cách phức tạp.

Vào tháng 4 năm 2008, Xianzi phát hành album thứ hai ""Don't Love the Biggest"". Nó có nghĩa là yêu một cách dũng cảm và bày tỏ thái độ rất thẳng thắn với cảm xúc. Nếu muốn yêu, bạn nên nói thẳng ra. Bài hát ""Reluctant"" đã trở thành một bản tình ca đầy nước mắt vào năm 2008 và lọt vào danh sách rút gọn của ba giải thưởng tại Lễ trao giải Bảng xếp hạng Bài hát Trung Quốc: Nữ ca sĩ xuất sắc nhất của năm, Nhà soạn nhạc xuất sắc nhất và Bài hát vàng của năm. Vào tháng 6 năm 2009, Xianzi đã sáng tác và hát ca khúc đầy cảm hứng ""Sân khấu"" cho bộ phim thần tượng ""Smile in My Heart"". Cùng năm đó, Xianzi đóng vai chính trong bộ phim ca nhạc Sunshine in the Guitar, hợp tác với Gao Xia và Griev.

Vào tháng 4 năm 2010, Xianzi phát hành album solo thứ ba ""Innocent"", bao gồm tổng cộng 10 bài hát. Album mang phong cách lãng mạn, bổ sung thêm yếu tố lãng mạn và lộng lẫy, hát dưới góc nhìn của một cô gái và hát mọi trạng thái yêu đương. Sau đó, Xianzi đã tổ chức buổi hòa nhạc lưu diễn ""Lần đầu tiên yêu Xianzi"". Cùng năm đó, Xianzi đóng vai chính trong bộ phim truyền hình đầy cảm hứng dành cho nữ ""Grand Slam"".

Vào ngày 24 tháng 11 năm 2011, Xianzi phát hành album thứ tư ""Rose Against the Wind"", hội nghị băng đầu tiên. Trong album này, Xianzi phá bỏ hình ảnh một cô gái dịu dàng, ngọt ngào trước đây và lần đầu tiên thử sử dụng phong cách rock làm chủ đề chính của album. Vào tháng 12, anh đóng chung bộ phim ""The Road to Music"" cùng với Wu Jianhao, Hong Tianxiang và những người khác. Sau đó, Xianzi tổ chức buổi hòa nhạc ""Rose Against the Wind"" tại ""The Wall"" ở Đài Bắc.

Vào tháng 3 năm 2012, Xianzi tham gia chương trình tạp kỹ ""Dance Forest Conference"". Vào tháng 6, Xianzi đóng vai chính trong bộ phim thần tượng dành cho giới trẻ ""Falling in Love with You by Expiration Date"", đóng vai Jiang Jinghui. Vào tháng 4 năm 2013, Xianzi tham gia chương trình truyền hình vệ tinh Chiết Giang ""China Star Jump"" và giành chức vô địch nhờ nụ cười rạng rỡ, cô được cư dân mạng gọi là ""Nữ thần nụ cười"". Vào ngày 25 tháng 7, Xianzi đã phát hành album thứ năm ""Looking Wrong Eyes"". Toàn bộ album xoay quanh những thay đổi trong thái độ đối với ""cảm xúc"". So với hình ảnh trữ tình trước đây của Xianzi, nó kết hợp nhiều khí chất thực sự của Xianzi hơn. Cùng năm đó, anh tham gia bộ phim truyền hình truyền cảm hứng dành cho giới trẻ ""Heroes of Fire"", đóng vai bác sĩ cứu hộ Zhang Kexin.

Vào ngày 13 tháng 2 năm 2014, anh tham gia chương trình tạp kỹ ""The Variety Show"" và bắt chước Huang Yixin của Feier Band hát ""I Want to Fly"". Cùng năm đó, anh tham gia bộ phim thần tượng True Love Meets Him, đóng vai Lai Yazhi. Vào tháng 4, Xianzi đã giành được giải thưởng ""Nghệ sĩ toàn năng Đại lục"" trong bảng xếp hạng TOP của Trung Quốc nhờ sự phát triển toàn diện trong lĩnh vực điện ảnh, truyền hình, thu âm và chương trình tạp kỹ. Vào tháng 5, Xianzi và Wu Kequn hát ca khúc ""Love Calls for Help 999"" và quay MV. Sau đó, Xianzi và Wu Xiubo đóng vai chính trong vở nhạc kịch dành cho giới trẻ ""My Youth High Octave"", đóng vai trợ lý hợp xướng Ye Shishi. Cùng năm đó, Xianzi xuất hiện trong vở kịch sân khấu ""Du lịch chia tay"".

Vào tháng 3 năm 2015, Xianzi và Jiang Mengjie đóng chung trong bộ phim hài nhẹ nhàng nhân vật nữ chính ""Sisters"" và ""Sisters 2"" bắt đầu quay vào tháng 8. Bộ phim có sự tham gia của Jiang Mengjie và Xianzi, một cặp chị em, vì suy sụp của họ. cài đặt nhân vật -to-earth Được cư dân mạng yêu thích. Vào tháng 10, Xianzi đã tổ chức chuyến lưu diễn hòa nhạc ""Party@2501 Thường trực và lắng nghe những bản tình ca"" tại Thượng Hải (17/10) và Bắc Kinh (31/10) để kỷ niệm 10 năm ra mắt. Cùng năm đó, Xianzi đóng vai chính trong bộ phim truyền hình đầy cảm hứng thành thị ""Bí mật xinh đẹp"", trong đó cô đóng vai Xu Ruolin, một ca sĩ từng trải qua sự phản bội của gia đình và tình yêu, trở thành ""nữ hoàng bụng đen"", và sau đó được bị thương và biến dạng.

Ngày 21 tháng 1 năm 2016, Xianzi phát hành bản tình ca ""Say I Do"" trên Weibo để tri ân người hâm mộ và bạn bè. Ngày 14 tháng 2 năm 2017, anh làm khách mời trong bộ phim tình cảm ""Hợp đồng"" của đạo diễn Lưu Quốc Nam. Ngày 25/2/2017, cô cùng chồng Lý Mao lần đầu tiên tham dự ""Lễ cưới thời trang cô dâu"" và đoạt giải ""Thần tượng hạnh phúc của năm"". Vào tháng 4, Xianzi đã hát bài hát đầy cảm xúc của nhân vật ""Love Goes Against Our Wishes"" cho bộ phim truyền hình giả tưởng cổ trang ""Choose Heaven"". Vào ngày 3 tháng 6, anh đã tham gia chuyên mục ""Bảng xếp hạng âm nhạc Trung Quốc toàn cầu"" của Kênh âm nhạc CCTV và hát hai ca khúc ""Have to Love"" và ""Love Backfires"". Vào tháng 7, Xianzi đã hát bài hát đầy cảm xúc ""Khi chúng ta chỉ có tôi"" của nhân vật chính Chu Qiao cho bộ phim truyền hình cổ trang ""The Legend of Chu Qiao"". Vào tháng 10, Xianzi và 16 nghệ sĩ khác đã thu âm bài hát từ thiện ""Sing 2030"" do Chương trình Phát triển Liên Hợp Quốc sản xuất. Vào tháng 12, Xianzi tham gia chương trình tạp kỹ truyền hình vệ tinh Chiết Giang ""The Voice of Dreams"" và trở thành thành viên của đội xây dựng ước mơ.

Vào tháng 1 năm 2018, Xianzi, Li Mao, Chen Duling và Liu Xianhua tham gia với tư cách khách mời trong chương trình thực tế về tình yêu dành cho người nổi tiếng của Đài truyền hình vệ tinh Hồ Bắc ""If Love"" trong cùng tháng, họ phát hành đĩa đơn trở lại ""Like"".

Vào ngày 4 tháng 2 năm 2019, tại Gala Lễ hội mùa xuân CCTV 2019, Xianzi đã hát bài hát ""Cùng nhau xây dựng giấc mơ Trung Hoa"" với Cao Fujia, Ayunga, Julaiti và Angsa. Ngày 19/6, ca khúc kết thúc ""Beyond the Sky"" của bộ phim truyền hình ""Đồng hành cùng bạn lên đỉnh thế giới"" đã được phát hành.

Ngày 2/3/2020, anh tham gia hát trực tuyến ca khúc từ thiện chống dịch “Nameless You”. Vào ngày 8 tháng 6, bộ phim truyền hình ""Blame You Are Too Beautiful"" do cô đóng vai chính đã được phát sóng, trong đó cô đóng vai trò dàn nhạc.

Ngày 21/01/2021 anh tham gia mùa thứ hai của “Chị Cưỡi Gió Và Sóng”; ngày 02/02 tập “Người đẹp tiếc nuối” hát cho bộ phim truyền hình “Tuổi trẻ tích cực” chính thức ra mắt; để hát nhạc phim gốc và phim truyền hình ""My ""Time, Your Time"" đã chính thức được phát sóng hôm nay, cùng ngày, anh tham gia ""Gala Lễ hội mùa xuân của đài truyền hình vệ tinh Hồ Nam 2021"" và biểu diễn ca khúc ""Vẻ đẹp quê hương"" cùng Jin Sha, Yu Kewei và Li Feier; vào ngày 14 tháng 2, anh tham gia chương trình trò chuyện giải trí ""Tian Tian Shang Shang"" của Truyền hình Vệ tinh Hồ Nam được phát sóng; "" đêm. Tháng 4, cô tham gia Sisters on the Gang. Vào tháng 7, Jiang Mengjie, Xianzi, Han Mubo, Bai Kainan, Huacai Youth-Huang Zihongfan, Haixia, Lu Jian, Wang Guan, He Yanke, Miao Lin và nhiều nghệ sĩ và người dẫn chương trình nổi tiếng khác cũng đóng vai trò là ""người giới thiệu phong cách quốc gia"" "" ” lần lượt xuất hiện để ủng hộ Đại hội Thể thao Quốc gia của CCTV. Vào tháng 8, anh tham gia Đêm xe toàn cầu 818 của đài truyền hình vệ tinh Hồ Nam. Vào ngày 6 tháng 9, anh hợp tác với Li Zhuxian để phát hành đĩa đơn ""Remember Tonight"". Ngày 2/10, anh tham gia My Motherland and Me và hát Youth Leap Up. Ngày 11/11, tập ""Ký ức đau thương"" hát cho phim truyền hình ""Biển sao"" đã được phát hành trực tuyến.

Vào ngày 1 tháng 2 năm 2022, anh tham gia ""Dạ tiệc Lễ hội mùa xuân truyền hình vệ tinh Quảng Đông khu vực vịnh lớn năm 2022"". Vào ngày 27 tháng 6, anh đã tham gia buổi phát sóng trực tiếp bài hát trên đám mây ""Our Bauhinia"" do People's Daily New Media, Trung tâm truyền thông tích hợp Kênh Phim và 1905 Movie Network đồng phát động. Tối 30/7, anh làm giảng viên âm nhạc cho vòng chung kết “Cuộc thi Top 10 ca sĩ hàng đầu của trường Bilibili 2022”; ngày 11/9 anh tham gia “Nhịp điệu cổ và giọng ca mới” của CCTV-1; hát bài “Phụng Niên”.

Vào ngày 14 tháng 1 năm 2023, anh tham gia ""Gala Lễ hội mùa xuân trực tuyến năm 2023 của Đài Phát thanh và Truyền hình Trung ương Trung Quốc"" và hát ca khúc ""Go Away"" cùng Zeng Li. Vào ngày 21 tháng 1, anh đã tham gia ""Lễ hội mùa xuân nhịp điệu cổ và tiếng nói mới"" và hát bài hát ""Lệnh trở về mùa xuân"" cùng với Xu Mengtao, Ma Jia và Yao Chen. Vào ngày 11 tháng 5, đĩa đơn ""Our Memorial"" đã được phát hành. Vào ngày 19 tháng 6, bộ phim truyền hình ""She Shines"" với Xianzi hát ca khúc chủ đề mở đầu ""Be Your Own Light"" đã được ra mắt. Ngày 24 tháng 10, đĩa đơn ""Brilliant Monsoon"" được phát hành. Ngày 30/11, bộ phim truyền hình “Anh nhớ em nhiều lắm” với sự góp mặt của khách mời đặc biệt đã ra mắt.

Vào ngày 24 tháng 2 năm 2024, anh tham gia ""Dạ tiệc Lễ hội đèn lồng của Đài Phát thanh và Truyền hình Trung ương Trung Quốc năm 2024"" và hát ""Forever We Are a Family"" cùng Cao Lei, Wu Kequn, Li Hongmei và những người khác. Ngày 27/3, anh đã tham gia phát sóng chương trình 100% Singer.

Kỷ lục danh dự: Âm nhạc

▪ Nghệ sĩ toàn năng của năm 2018 tại Changbahaidian (Đoạt giải thưởng)

▪ 2014 2013 Nghệ sĩ toàn năng Đại lục được xếp hạng TOP Trung Quốc (Giành giải thưởng)

▪ 2009 Giải thưởng Top 10 Giai điệu vàng của bảng xếp hạng phương Đông lần thứ 16 ""Bất đắc dĩ"" (Người chiến thắng)

▪ Nữ ca sĩ xuất sắc nhất năm 2009 trên bảng xếp hạng bài hát Trung Quốc (đề cử)

▪ 2009 Nhà soạn nhạc xuất sắc nhất bảng xếp hạng bài hát Trung Quốc ""Bất đắc dĩ"" (Được đề cử)

▪ Bài hát vàng hàng năm của Bảng xếp hạng bài hát Trung Quốc năm 2009 ""Bất đắc dĩ"" (Được đề cử)

▪ 2009 2008 Top 30 ca khúc vàng ""Bất đắc dĩ"" (Đoạt giải)

▪ 2009 2008 Nhạc Pop Bắc Kinh Nữ ca sĩ xuất sắc nhất của năm (được đề cử)

▪ 2008 Baidu Entertainment Top Ten Golden Melody Awards ""Bất đắc dĩ"" (người chiến thắng)

▪ 2007 Giải Bạc Tân binh Phương Đông Billboard lần thứ 14 (chiến thắng)

▪ Giải thưởng Giai điệu vàng Đài Loan năm 2007 cho Nghệ sĩ mới xuất sắc nhất (được đề cử)

▪ Ca khúc ăn khách nhất Hồng Kông và Đài Loan của Wireless Music năm 2006 ""Have to Love"" (chiến thắng)

▪ 2006 Danh sách tiên phong âm nhạc 9+2 Lực lượng mới hàng năm trong giới âm nhạc (Đoạt giải thưởng)

▪ Giải thưởng được yêu thích nhất tại bảng xếp hạng âm nhạc châu Á-Thái Bình Dương năm 2006 tại Trung Quốc đại lục (chiến thắng)

▪ 2006 Danh sách TOP Trung Quốc Giải thưởng Diễn viên mới xuất sắc nhất Đại lục (chiến thắng)

▪ Giải thưởng Trường đại học được yêu thích hàng đầu Trung Quốc năm 2006 (chiến thắng)

Thời trang

▪ 2018 Tin tức Bắc Kinh Gia đình thời trang của năm (chiến thắng)

▪ Lễ hội tình yêu thời trang cô dâu thường niên 2017 Thần tượng hạnh phúc (Đạt giải thưởng)

phúc lợi công cộng

▪ Ngôi sao Trách nhiệm xã hội xuất sắc nhất Lễ hội từ thiện Trung Quốc lần thứ nhất năm 2012 (được đề cử)",
                    Location = "Trung quốc",
                    ImgUrl = @"https://y.qq.com/music/photo_new/T001R300x300M000002LJqM93gNF52_3.jpg?max_age=2592000",
                },
                new Singer
                {
                    Name = @"Lão Can Ma/李常超（Lao乾妈）",
                    Gender = Gender.Male,
                    Introduction = @"Quốc tịch: Trung Quốc

Nơi sinh: Nam Kinh, Giang Tô

Tác phẩm tiêu biểu: “Kẻ cướp mộ ghi chú: Mười năm trên thế giới”, “Cô gái Trường An”, “Với Zhuang”, “Sự sống và cái chết”, “Lịch sử núi xuân”, “Phong Vân Hi”

Giới thiệu ngắn gọn: Li Changchao (Laoganma), một nhạc sĩ phong cách Trung Quốc, sinh ra ở Nam Kinh, tỉnh Giang Tô.

Tính đến năm 2021, hơn 100 bài hát gốc đã được phát hành thành công, với hơn 10 tỷ lượt xem trên toàn mạng. Các tác phẩm tiêu biểu của anh bao gồm ""Tomb Robbers Notes: Ten Years in the World"", ""Chang'an Girl"", ""Yuzhuang"". "", v.v., và đã giành được ""Đêm hạnh phúc phong cách quốc gia · ""Giải thưởng nam ca sĩ gió xuất sắc nhất của nhạc sĩ gió toàn quốc"", ""Giải thưởng âm nhạc phong cách quốc gia hàng năm Top 10 giải thưởng Giai điệu vàng"", ""Âm nhạc phong cách Trung Quốc được giới trẻ yêu thích · Ca sĩ nhạc phong cách quốc gia và các giải thưởng danh dự khác; được mời hát cho các bộ phim điện ảnh, truyền hình “Nhạc gió” “Khởi động từ Lạc Dương”, “Khởi động lại vùng biển cực nghe tiếng sấm”, “Mệnh lệnh của vị thần Samurai”, truyện tranh Trung Quốc “Người anh hùng”. and the Righteous"", ""Leyin Changge·Breaking Dawn"", IP trò chơi ""Glory of the King"", ""Onmyoji"", ""Peace Elite"" "", ""Jian Wang San"" và các IP phổ biến khác đã biểu diễn.

Lịch sử nghệ thuật: Năm 2016, anh chính thức ra mắt với vai trò ca sĩ và nhiều lần tham gia Liên hoan Âm nhạc Phong cách Quốc gia. Vào ngày 16 tháng 2 năm 2017, bài hát chủ đề trò chơi ""Bẫy"" hát cho ""300 Heroes"" được phát hành vào tháng 5, anh tham gia chương trình tạp kỹ ""I Love the Second Dimension"" do Tencent Video phát sóng và hát bài ""Classic"" trong tập đầu tiên của chương trình Thư ký nhà tù""; ngày 17/6, anh tham gia lễ kỷ niệm 30 năm ""1987, Our Dream of Red Mansions"" và hát ca khúc ""Read Less Red Mansions""; ngày 29/6, anh hát ca khúc ""Read Less Red Mansions"". bài hát chủ đề ""Young Westward Journey"" cho game di động ""Journey to the West"" ""Go"" được phát hành vào ngày 21 tháng 7, đĩa đơn solo ""Life and Death Jianghu"" được phát hành vào ngày 20 tháng 12, bài hát chủ đề ""The Legend of"" Heroes·Tam Quốc” hát cho trò chơi “Huyền Thoại Anh Hùng” đã được phát hành.

Vào ngày 9 tháng 1 năm 2018, bài hát dành cho người hâm mộ ""One Man's War"" hát cho ""Tianya Mingyue Dao OL"" được phát hành; "" ""Tomb Robbers Notes: Ten Years in the World""; ngày 8 tháng 10, anh phát hành đĩa đơn solo ""Heavy Rain·Pear Blossom""; ngày 3 tháng 11, anh tham gia National Style Bliss Night của NetEase Cloud Music, hát ca khúc ""Life và Death Jianghu"", đồng thời giành được Giải thưởng Nam ca sĩ phong cách quốc gia xuất sắc nhất; vào ngày 26 tháng 11, anh phát hành đĩa đơn cá nhân ""Feng Yun Xi"".

Ngày 20 tháng 4 năm 2019, anh tham gia Lễ hội âm nhạc phong cách quốc gia dành cho giới trẻ Trung Quốc; ngày 11 tháng 5, bài hát dành cho người hâm mộ ""Ý định giết người"" hát cho tiểu thuyết ""Tâm trí tội phạm"" được phát hành; ngày 19 tháng 6, anh hát chân dung nhóm NPC; trò chơi trực tuyến ""Jian Wang 3"" Bài hát ""A Glass of Wine in the Sea"" ngày 27 tháng 7, tham gia Liên hoan Âm nhạc Phong cách Quốc gia Trung Quốc, hát các ca khúc ""Ký ức"" và ""Zhangejue"" vào ngày 3 tháng 8; trong CCTV China Young Project ""Youth v Diary""; vào ngày 7 tháng 8. Ngày 14 tháng 8, đĩa đơn solo ""Memory"" được phát hành; phát hành ngày 16/8, hát quảng cáo cho bộ phim “Đỉnh cao vinh quang” “Trong tên giấc mơ”; và lên kế hoạch cho những câu chuyện mang phong cách dân tộc; ngày 12 tháng 10, phát hành ca khúc ""War Revolution"" đồng hát với ""Judgment"" của Yang Tianxiang; Hero"" để kỷ niệm một năm ngày mất của Jin Yong đã được phát hành; vào ngày 30 tháng 11, đĩa đơn solo ""With Zhuang"" đã được phát hành.

Vào ngày 28 tháng 3 năm 2020, anh phát hành album nhạc cổ điển đầu tiên “Empty Mountain Can Drunk Guest”, bao gồm 7 bài hát theo phong cách cổ xưa trong đó có “Chang'an Girl”; Lễ hội âm nhạc phong cách và hát Bài hát ""With Zhuang""; ngày 14 tháng 5, bài hát quảng cáo trò chơi NetEase 520 ""To the Other Side of Dreams"" được phát hành; ngày 20 tháng 5, tập ""Fflower Injury"" hát cho phim truyền hình trực tuyến ""Copycat"" Little Meng Lord"" đã được phát hành; Vào ngày 20 tháng 7, bài hát ""Wu Tuo"" của nhân vật Zhang Qiling được hát cho bộ phim truyền hình trực tuyến có chủ đề phiêu lưu ""Restart: Thunder in the Extreme Sea"" đã được phát hành; vào ngày 14 tháng 8, tác phẩm cover chính thức được ủy quyền ""Fan Dance"" được phát hành, ngày 25/9 ca khúc ""Legendary New Chapter"" được hát được phát hành. Đây là ca khúc gây ấn tượng của Ye Xiu trong album nhạc tiểu thuyết ""New Chapter"" của ""The Master"". ; Vào ngày 2 tháng 10, anh tham gia Lễ hội Âm nhạc và Hoạt hình Kugou; vào ngày 14 tháng 11, anh phát hành album ""Brotherhood·Gege"" đồng hát với Yang Tianxiang; do Douyin A làm giám khảo của sự kiện khởi xướng; vào ngày 30 tháng 12, anh đã phát hành đĩa đơn cá nhân ""Mochen Fu"".

Vào ngày 1 tháng 1 năm 2021, anh tham gia Buổi hòa nhạc mừng năm mới Flowers Blooming World của Đài truyền hình vệ tinh Tứ Xuyên, hát các bài hát ""Tomb Robbers: Ten Years in the World"" và ""Untitled Play"" trong cùng tháng, anh tham gia Lễ hội văn hóa Mochen; và hát ca khúc ""Mochen Fu""; vào tháng 1. Vào ngày 20, anh phát hành đĩa đơn cá nhân ""Peach Blossom Fan""; 'an Girl"" và ""Untitled Play""; ngày 24/1 anh phát hành album cá nhân ""Wei'er"" "", gồm 6 ca khúc trong đó""Untitled Play""; ngày 13/2, anh hát ca khúc ""Inverse"" của nhân vật Cimu cho bộ phim "" Samurai God Order""; ngày 18/4, tham gia Lễ hội ""Cuộc sống tốt đẹp thành phố Liyang"" của Douyin, cô hát các ca khúc ""Tomb Robbers: Ten Years in the World"", ""Chang'an Girl"", ""Untitled Play"" và ""Chunshan Foreign History""; ngày 6/7 cô hát ca khúc chủ đề ""Let Me Come"" cho bộ phim truyền hình ""I Will Do It"" do Carat Comics sản xuất ""Cross"" được phát sóng trực tuyến; ngày 29/7, ca khúc chủ đề ""Tuổi trẻ·Giấc mơ anh hùng"" "" hát cho game di động ""Little Raccoon"" đang trực tuyến; vào ngày 5 tháng 8, nó được hát cho cuốn tiểu thuyết ""Ghi chú của những kẻ cướp mộ·Tìm kiếm xác chết trong biển đèn lồng"" Bài hát quảng cáo ""Biển ánh sáng"" đã được hát phát hành; ngày 17 tháng 8 tham gia Hòa nhạc Lễ hội lúa gạo; ngày 21 tháng 9 tham gia hát ca khúc kỷ niệm “Giấc mơ như quần áo” nhân dịp kỷ niệm 13 năm và 5 năm tháng 10 tổ chức “Kế hoạch 5 năm lần thứ 10”; tại Thượng Hải, buổi hòa nhạc đặc biệt ""Year Overtime""; ngày 2/10, OST ""Star Dream Flying"" hát cho ""Star Dream Idol Project Radio Drama"" được ra mắt, ngày 15/10, ca khúc trò chơi ""Sword Finger"" được hát cho ""; The Legend of Sword and Fairy VII"" ""Heaven""; vào ngày 23 tháng 10, bài hát chủ đề ""Tìm kiếm thất bại"" được hát cho Giải vô địch thường niên trò chơi di động kiếm sĩ mới đã được phát hành; vào ngày 2 tháng 12, tập ""Bí mật thiên đường"" được hát cho bộ phim cổ trang ""The Wind Rises in Luoyang"" được phát hành; Ngày 8 tháng 12, anh phát hành đĩa đơn cá nhân ""Dedicated to Tenderness""; Lễ hội âm nhạc thời thượng.

Vào ngày 1 tháng 1 năm 2022, anh tham gia Buổi hòa nhạc chào năm mới của đài truyền hình vệ tinh Tứ Xuyên; 28, anh hát cho trò chơi ""Hòa bình"" Bài hát ấn tượng thời trang ""Battlefield Blast"" ""Mountain and Sea Wind"" do ""Elite"" hát được phát hành trực tuyến vào ngày 8 tháng 3, đĩa đơn song ca đầu tiên ""Drink Drink Drink"" với DP Dragon Pig; đã được phát hành. 12h ngày 6/6, đĩa đơn mới ""Mưa sông Kim Lăng"" chính thức ra mắt. Vào ngày 3 tháng 10, EP Kinh kịch kết hợp phong cách dân tộc mới của Li Changchao ""Sound in the Opera"" đã có bài hát đầu tiên. Vào ngày 28 tháng 10, việc hát ca khúc chủ đề mở đầu của ""One Hundred Refiners to God Animation"": ""Refined"" đã được phát hành trực tuyến.

Vào ngày 12 tháng 1 năm 2023, anh tham gia ""Đổi mới nhịp điệu cổ · 2022 Douyin Live Broadcast Huacai Inheritance Gala"" và biểu diễn chương trình ""Rượu Quan Sơn"". Vào ngày 17 tháng 9, đĩa đơn ""How Dare"", hợp tác với Xilina Yigao, chính thức được phát hành.

Vào ngày 14 tháng 3 năm 2024, đĩa đơn ""Mười điều ác"" được phát hành.

Kỷ lục danh dự: 2018-11-3 Đêm phong cách hạnh phúc toàn quốc Nhạc sĩ phong cách Trung Quốc Giành giải Nam ca sĩ xuất sắc nhất

2018-2-16 Giải thưởng Âm nhạc Quốc gia thường niên Top 10 Giải thưởng Giai điệu vàng ""Quên hình dạng"" đã giành giải thưởng",
                    Location = "Trung quốc",
                    ImgUrl = @"https://y.qq.com/music/photo_new/T001R300x300M000001jDBSD0zRhYh_8.jpg?max_age=2592000",

                },
                new Singer
                {
                    Name = @"Đàn Kiện Thứ/檀健次",
                    Gender = Gender.Male,
                    Introduction = @"Tên nước ngoài: JC-T

Bí danh: 多多/Duoduo

Quốc tịch: Trung Quốc

Nơi sinh: Bắc Hải, Quảng Tây

Ngày sinh: 5 tháng 10 năm 1990

Nghề nghiệp: Diễn viên, ca sĩ

Tác phẩm tiêu biểu: “Sách minh họa về tội ác săn bắn”, “Bạn có an toàn không”, “Sauvignon Blanc”, “Hổ gầm rồng gầm”, “Liên minh quân sự vĩ đại của Tư Mã Ý”, “Vạn đèn”, “Bay”. Xa""

Thành tích chính: Quán quân nhóm trẻ cuộc thi nhảy Latin quốc gia Taoli Cup, giải Ngôi sao siêu mới nổi của Liên hoan nhạc Pop châu Á Hồng Kông, Nhóm nhạc xuất sắc nhất bảng xếp hạng âm nhạc lần thứ 4, Hạng ba môn múa Latin của thiếu niên 16 tuổi Nhóm của IDSF Grand Prix Thế giới, Nhà vô địch Khiêu vũ Latin chuyên nghiệp của Giải vô địch Khiêu vũ Quốc gia, Giải Vàng Kết hợp Siêu Chuông Vàng Âm thanh Trung Quốc

Giới thiệu: Tan Jianci (JC-T) sinh ngày 5 tháng 10 năm 1990 tại Thành phố Bắc Hải, Khu tự trị dân tộc Choang Quảng Tây. Ca sĩ, diễn viên. Thành viên của nhóm ca hát và nhảy múa Đại lục MIC. Anh chính thức ra mắt với tư cách là thành viên của nhóm nhạc nam MIC vào năm 2010. Anh đảm nhiệm phần bass của nhóm. Anh nhảy Latin giỏi và đã phát hành nhiều album cùng nhóm. Năm 2007, anh tham gia bộ phim ""Bờ biển bí mật"". Năm 2012, cô giành vị trí thứ 4 trong mùa thứ ba của “Dance Forest”. Năm 2014, anh phát hành đĩa đơn solo đầu tiên ""Fly Away"". Năm 2015, anh tham gia vở nhạc kịch ""Tiny Times"". Năm 2016, anh tham gia bộ phim truyền hình ""Liên minh cố vấn quân sự vĩ đại của Tư Mã Ý"" và ""Hổ gầm rồng gầm"", đóng vai Tư Mã Chiêu. Tháng 3 năm 2017, anh tham gia bộ phim truyền hình cổ trang ""Bí mật"". Tam Quốc Chí”, đóng vai Cao Pi; tháng 10 năm 2017, anh đóng vai chính trong Urban Love. Trong phim truyền hình “So You're Still Here”, anh đóng vai Chu Tử Di. Tháng 6 năm 2018, anh tham gia bộ phim truyền hình Đưa bố đi du học với vai Kevin Chen. Cùng năm đó, anh tham gia chương trình tạp kỹ ""Tôi là diễn viên"". Năm 2019, anh tham gia bộ phim “Người yêu dấu” do Từ Tranh sản xuất và đóng vai Luo Hua. Vào tháng 12 năm 2019, anh đóng vai chính trong bộ phim tình cảm đô thị Centimet of Love với vai Quan Chấn Lôi. Năm 2020, anh đóng vai chính trong bộ phim truyền hình Trung Hoa Dân Quốc ""The Sideburns Are Not Begonia Red"", đóng vai Chen Renxiang; cùng năm đó, anh đóng vai chính trong bộ phim hài nhẹ nhàng ""The Journey of the Tang Dynasty"" với vai King Wu; Lý Khắc; và đóng vai chính trong bộ phim cổ trang lãng mạn ""Đêm nay"". Năm 2022, anh lần đầu tiên tham gia bộ phim trinh thám tội phạm ""Crime Hunters"" với vai nam chính và hát bài hát chủ đề cùng tên cho bộ phim. Vào tháng 12, anh tham gia ""Đêm giao thừa của Đài truyền hình vệ tinh Hồ Nam 2022-2023"" để hát ca khúc ""IMMA GET IT"". Tháng 2 năm 2023, anh phát hành ca khúc “Đi ngang qua, pháo hoa trên thế giới” và tham gia bộ phim “Wang Jinjin I Lost Twice”. Vào ngày 20 tháng 4, anh ấy đã tham gia ""Eternal Sound·Treasure Island Season"" và phát hành video danh sách phát của nửa đầu buổi biểu diễn thứ ba. Anh ấy đã tham gia hát ca khúc ""Vì sao anh yêu em vậy"" và phát hành album ""DREAMS"". "" cùng ngày; vào ngày 19 tháng 6, bộ phim truyền hình ""Thợ săn tội phạm 2"" mà cô tham gia đã chính thức ra mắt và tung trailer. Cùng ngày, dàn diễn viên chính của bộ phim truyền hình ""Love Has Fireworks"" đã chính thức được công bố. Vào ngày 24 tháng 7, bộ phim đặc biệt ""Sauvignon Blanc"" đã được lên lịch ra mắt. Ngày 30/11, bộ phim truyền hình ""Anh Nhớ Em Rất Nhiều"" sẽ lên sóng. Vào ngày 1 tháng 1 năm 2024, khúc dạo đầu của album solo thứ hai ""Mona Lisa"" được phát hành trực tuyến. Ngày 12/6, album ""Huấn"" được phát hành.

Sự nghiệp nghệ thuật: Tháng 8 năm 2007, anh lần đầu tiên tiếp xúc với phim truyền hình và điện ảnh, đồng thời đóng chung với Karen Mok, Eric Tsang và những người khác trong bộ phim điện ảnh ""The Secret Shore"". Phim được phát hành tại Trung Quốc đại lục vào ngày 13 tháng 10. , 2009.

Vào tháng 11 năm 2009, anh hát bài hát chủ đề ""Beyond the game"" với tư cách là khách mời biểu diễn tại Cuộc thi thể thao điện tử thế giới WCG và tổ chức cuộc họp truyền thông đầu tiên vào tháng 12, anh tham gia ghi hình ""Migu Star Academy"" của Dragon TV và hát cover ca khúc ""Poker Face"" và ""Sweet Dreams"" của Lady Ga Ga của Eurythmics, đồng thời biểu diễn ""CS Dance Show"" trong bộ đồng phục ngụy trang của lực lượng đặc biệt. Cuối cùng, anh đã giành được ""Giải vô địch Học viện Ngôi sao Migu"" và nhận được học bổng trị giá 5 triệu nhân dân tệ.

Vào ngày 27 tháng 6 năm 2012, một cuộc họp báo đã được tổ chức tại Bắc Kinh về việc đóng vai chính trong bộ phim truyền hình thần tượng dành cho giới trẻ đầu tiên ""Love Because of Love"".

Vào ngày 10 tháng 12 năm 2014, anh phát hành đĩa đơn solo đầu tiên ""Fly Away"". Năm 2015, cô đóng vai chính trong bộ phim truyền hình truyện tranh trực tuyến ""The Butlers""; vào tháng 5, cô đóng vai chính trong vở nhạc kịch ""Tiny Times"" với vai Jian Xi.

Vào tháng 3 năm 2016, anh đóng vai chính trong bộ phim truyền hình cổ trang ""Đại cố vấn quân sự Tư Mã Ý: Liên minh cố vấn quân sự"" và phần tiếp theo của nó là ""Hổ gầm rồng gầm"", đóng vai Tư Mã Chiêu, con trai thứ hai của một vị cực kỳ thông minh nhưng đầy tham vọng Tư Mã Ý; anh đã tham gia bộ phim truyền hình trực tuyến ""Trò chơi trực tuyến Giấc mơ trở về bất tử"" được phát sóng và đóng vai Guo Xiaodan trong vở kịch.

Vào ngày 12 tháng 4 năm 2017, anh đóng vai chính trong bộ phim trực tuyến giả tưởng ""The Devil Reborn"" từ Vương quốc Địa ngục, trong đó anh đóng vai thiên chủ cấp cao Gao Yuan. ""Vậy là cậu vẫn ở đây"".

Vào ngày 27 tháng 3 năm 2018, anh đóng vai chính trong bộ phim truyền hình cổ trang chủ đề Tam Quốc ""The Hidden Dragon in the Deep"", được ra mắt trên Tencent Video Tan Jian đã thực hiện bộ phim truyền hình chủ đề Tam Quốc lần thứ hai, đóng vai chính. vai Cao Pi, con trai của Tào Tháo; đóng vai chính trong bộ phim gia đình thành thị ""Du học cùng bố"", đóng vai Chen Kaiwen, con trai của Liu Ruoyu trong bộ phim được phát hành vào ngày 13 tháng 6 năm 2019. Phim được công chiếu trên Dragon TV và Truyền hình vệ tinh Chiết Giang cùng ngày.

Vào ngày 20 tháng 10 năm 2018, anh tham gia chương trình tạp kỹ ""Tôi là diễn viên"" của truyền hình vệ tinh Chiết Giang. Ở vòng đầu tiên, Sun Jian, Fan Tantan, Jiang Kaitong, Fang Fang Bin và Zhang Meng đã thách đấu ""Chuyện tình Bắc Kinh"". Họ đã được người hướng dẫn và khán giả công nhận và tham gia thành công Kênh A; Vào ngày 3 tháng 11, các đối tác Liu Huân, Zhang Junning và Wang Maolei đã thử thách ""Xiu Chun Knife 2"" và gia nhập thành công đội Xu Zheng với khả năng thể hiện vai diễn tuyệt vời của họ. của Xin Wang; vào ngày 24, các đối tác Zhang Junning và Jing Chao đã thử thách tác phẩm ""Từng bước một trái tim chấn động"" .

Vào tháng 1 năm 2019, anh đóng vai chính trong bộ phim truyền hình Trung Hoa Dân Quốc ""The Sideburns Are Not Begonia Red"", đóng vai bạn của Shang Xirui, nam diễn viên nổi tiếng Chen Renxiang. phim hài nhẹ nhàng ""Li Ge Xing""; do Xu Zheng sản xuất, dự kiến ​​ra mắt vào ngày 31 tháng 12 năm 2019.

Vào tháng 3 năm 2020, anh tham gia chương trình ca nhạc truyền hình vệ tinh Chiết Giang ""The Voice of God""; vào tháng 6, anh tham gia chương trình tạp kỹ âm nhạc truyền hình vệ tinh Bắc Kinh ""The King of Crossovers Season 5"" với tư cách khách mời thử thách vào ngày 2 tháng 7; anh đóng vai chính trong bộ phim truyền hình cổ trang ""Fighting Fire"" đã công bố dàn diễn viên chính và bắt đầu bấm máy. Tan Jianci đóng vai một trong những nhân vật nam chính, Tướng quân Gu Yun; mà anh ấy đóng vai Guan Zhenlei; ""Lễ phim truyền hình Trung Quốc năm 2020"" của truyền hình vệ tinh.

Vào ngày 22 tháng 1 năm 2021, anh tham gia Gala Lễ hội mùa xuân truyền hình Bắc Kinh 2021. Vào ngày 10 tháng 2, anh tham gia ""Buổi hòa nhạc đêm giao thừa"" và ""Dạ tiệc lễ hội mùa xuân hài kịch"" của Dragon TV do Youku và Truyền hình vệ tinh Chiết Giang phối hợp tổ chức; tham gia chương trình tạp kỹ ""Take the Move"" Seniors"" của Dragon TV; vào ngày 26 tháng 2, anh tham gia ""Dạ tiệc lễ hội đèn lồng truyền hình vệ tinh Hồ Nam năm 2021""; vào ngày 27 cùng tháng, anh tham gia chương trình thực tế của truyền hình vệ tinh Chiết Giang "" Nian Nian Peach Blossom Land""; tối ngày 27 tháng 2, anh tham gia chương trình tạp kỹ ""Brother Chasing the Light"" Mở ra trận chung kết, cuối cùng là Chen Zhipeng, Fu Longfei, Fu Xinbo, Hu Xia, Liu Wei, Tan Jianci và Yu Mengyu thành lập một nhóm. Tan Jianci cũng giành được danh hiệu ""Ngôi sao theo đuổi ánh sáng của năm"" vào ngày 30 tháng 7, xuất hiện thân thiện. Bộ phim sitcom gia đình ""One House Family"" được phát sóng trên iQiyi và anh ấy đóng vai Kenjiro. trong vở kịch; ngày 31/12, anh tham gia ""Cánh buồm 2022 - Tiệc đêm giao thừa của Đài phát thanh và Truyền hình Trung ương Trung Quốc""; Cùng nhau bắt đầu trong một kỷ nguyên mới tươi đẹp""; cùng năm đó, anh tham gia ""Lễ băng tuyết đêm giao thừa toàn cầu tại Thế vận hội mùa đông BRTV 2022"" và hát ca khúc ""Courage"" cùng Củng Lợi.

Ngày 30 tháng 1 năm 2022, anh tham gia chương trình đặc biệt Lễ hội mùa xuân văn hóa nghệ thuật “Đón xuân” của đài chính; ngày 1 tháng 2 anh tham gia “Dạ tiệc mừng xuân của Dragon TV 2022”; buổi phát sóng chung của chương trình truyền hình vệ tinh Youku và Bắc Kinh ""Đến gặp bạn vào một ngày tuyết rơi"" vào ngày 25 tháng 2, chương trình tạp kỹ trường quay thử thách tương tác ấm áp ""Ace Vs Ace Season 7"" được phát sóng vào ngày 26 tháng 2, anh ấy đã tham gia Hồ Nam; ""Xin chào"" thứ bảy"" của truyền hình vệ tinh; vào ngày 6 tháng 3, bộ phim truyền hình tội phạm bí ẩn ""Thợ săn tội phạm"" với sự tham gia của Jin Shijia đã được phát sóng trên iQiyi và Tencent Video. Tan Jianci lần đầu tiên đóng vai nam chính, đóng vai người vẽ chân dung tội phạm Thẩm Dịch. Vào ngày 28 tháng 3, ""Sauvignon Blanc"" với sự tham gia của Yang Zi, Zhang Wanyi và những người khác đã bắt đầu quay phim. Cùng năm, Tan Jianci tham gia mùa thứ ba của ""The Voice of God""; vào ngày 1 tháng 5, anh tham gia Chương trình đặc biệt ""Giấc mơ Trung Hoa · Vẻ đẹp của lao động - Ngày Quốc tế Lao động tháng 5 năm 2022"" và đã hát cùng Wang Xi và Ma Jia bài hát ""Wishful"". Từ ngày 2 đến ngày 4 tháng 5, anh tham gia chương trình truyền thông đặc biệt mới ""UP Youth"" do Đài Phát thanh và Truyền hình Trung ương Trung Quốc phát động; trình diễn phim ngắn ""Đường Thơ Đường"". Vào ngày 18 tháng 5, ""Xin chào, thứ bảy"" đã công bố danh sách khách mời mới Tan Jianci sẽ tham gia và hợp tác với He Jiong Cheng; vào ngày 31 tháng 5, ""Tan Jianci: Every Beam of Light"" sẽ kể câu chuyện Trung Quốc dựa trên Zheng Nengli. . ""Have Power"" đã được ra mắt; vào tối ngày 27 tháng 6, tờ People's Daily New Media, Trung tâm truyền thông tích hợp Kênh Phim và 1905 Movie Network đã cùng nhau phát động sự kiện phát sóng trực tiếp bài hát trên đám mây ""Our Bauhinia"". Vào ngày 28 tháng 6, đội hình đầy đủ của Star Set Sail đã chính thức được công bố, bao gồm Tan Jianci vào tháng 8, anh hát ca khúc quảng bá chủ đề ""Mười ngàn ánh sáng"" cho bộ phim hoạt hình ""New God List: Yang Jian"". Vào ngày 27 tháng 8, tập thứ sáu của ""Xin chào thứ bảy"" và ""Dự án đổi mới mùa hè"" mà cô tham gia đã được phát sóng trên truyền hình vệ tinh Hồ Nam. Cùng năm đó, anh gia nhập Boiling Campus và làm cố vấn. Vào ngày 10 tháng 9, anh tham gia Gala Tết Trung thu của Đài Phát thanh và Truyền hình Trung ương Trung Quốc năm 2022 và tham gia ca khúc ""Ode to Loneiness""; Bạn an toàn chứ?"" ""Phát sóng; ngày 16 tháng 9, bộ phim tình cảm lãng mạn thành thị ""I Miss You Very Many"" với sự tham gia của bạn diễn Chu Diệp đã ra mắt; ngày 29 tháng 11, anh tham gia ""Hội nghị tầm nhìn Weibo · Lễ hội tia sáng""; ngày 31 tháng 12, anh tham gia "" 2022 -Tiệc mừng năm mới của đài truyền hình vệ tinh Hồ Nam năm 2023"", biểu diễn ""IMMA GET IT"".

Ngày 14 tháng 1 năm 2023, anh tham gia ""Old Railway Gala"" của Kuaishou; ngày 14 tháng 2, anh đóng phim ""Wang Jinjin I Lost Twice""; ""Eternal Sound·Treasure Island Season"" đã phát hành video danh sách bài hát của nửa đầu buổi biểu diễn thứ ba, tham gia hát ca khúc ""Vì sao anh yêu em vậy"" và phát hành album ""DREAMS"" cùng ngày; Lần đầu tiên tham gia Chương trình đặc biệt ""Giấc mơ Trung Hoa · Vẻ đẹp của lao động - Ngày Quốc tế Lao động 1/5/2023"" phát sóng, hát ca khúc ""Đuổi theo ánh sáng""; 2"" đã chính thức ra mắt và tung ra trailer. Cùng ngày, dàn diễn viên chính của bộ phim truyền hình ""Love Has Fireworks"" đã chính thức được công bố. Vào ngày 24 tháng 7, bộ phim đặc biệt ""Sauvignon Blanc"" đã được lên lịch ra mắt. Ngày 30/11, bộ phim truyền hình ""Anh Nhớ Em Rất Nhiều"" sẽ lên sóng. Các ca khúc “Trở về cùng nhà vua”, “Cát cát vĩnh cửu”, “Âm thanh”, “Ngày và đêm” và “Trăm năm mộng” được hát cho bộ phim truyền hình “Anh nhớ em rất nhiều” đã được phát hành trực tuyến.

Vào ngày 1 tháng 1 năm 2024, khúc dạo đầu của album solo thứ hai ""Mona Lisa"" được phát hành trực tuyến. Ngày 12/6, album ""Huấn"" được phát hành. Ngày 9 tháng 7, đĩa đơn Peach Blossom Blood được phát hành.

Kỷ lục danh dự: Hạng mục Phim và Truyền hình

2023-4 Liên hoan truyền hình quốc tế Kỷ nguyên mới lần thứ 3 Giải thưởng Ốc sên dành cho Nam diễn viên được yêu thích nhất ""Thợ săn tội phạm"" (Giành giải thưởng)

25-3-2023 2022 Nam diễn viên nhảy vọt của năm trên weibo (đoạt giải)

2022-11 Diễn viên được mong đợi hàng năm tại Hội nghị Tầm nhìn Weibo Glimmer Glory (Giành giải thưởng)

2022-8-13 2022 Hội nghị tầm nhìn Weibo Các nhân vật điện ảnh và truyền hình vinh quang lấp lánh (Đề cử)

Giải thưởng Người mới chất lượng của Liên hoan Phim truyền hình 2021-3-13 (chiến thắng)

2021-1-1 Liên hoan phim truyền hình Trung Quốc 2020 Diễn viên có phong cách diễn giải trẻ trung (đoạt giải)

Giải thưởng Diễn viên tiên phong nổi tiếng tại Lễ hội thời trang Figaro 2021 2021 (Người chiến thắng)

Danh hiệu danh dự

Năm 2021 “Đuổi theo ánh sáng anh ơi” đạt danh hiệu “Đuổi theo ngôi sao ánh sáng của năm” (Đoạt giải)

2020 ""You Look So Good When You Smile"" đạt danh hiệu ""Ready Player One"" (Giành giải thưởng)

Nhảy

2006 Cuộc thi khiêu vũ quốc tế ""Taoli Cup"" lần thứ 8 Nhà vô địch khiêu vũ Latin tiêu chuẩn dưới 16 tuổi (chiến thắng)

Vòng chung kết thường niên IDSF Grand Prix Thế giới 2006 Thượng Hải mở rộng Nhóm 16 tuổi Nhảy Latin Vị trí thứ ba (Giành giải thưởng)

Giải vô địch thể thao khiêu vũ toàn quốc năm 2006, hạng năm môn nhảy hiện đại nhóm 16 tuổi chuyên nghiệp (chiến thắng)

Vòng chung kết thường niên IDSF Grand Prix Thế giới 2006 Thượng Hải mở rộng Nhóm 16 tuổi Nhảy hiện đại Vị trí thứ tư (Giành giải thưởng)

Giải vô địch thể thao khiêu vũ quốc gia năm 2006 Nhà vô địch khiêu vũ Latin chuyên nghiệp 16 tuổi (chiến thắng)",
                    Location = "Trung quốc",
                    ImgUrl = @"https://y.qq.com/music/photo_new/T001R300x300M000002NDCAj4d5ahV_6.jpg?max_age=2592000",

                },
            };

            context.Singers.AddRange(singers);
            await context.SaveChangesAsync();
        }
    }
}
