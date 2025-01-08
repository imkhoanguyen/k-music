using KM.Domain.Entities;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class SongSeed
    {
        public static async Task SeedAsync(MusicContext context)
        {
            if (context.Songs.Any()) return;

            var songs = new List<Song>
            {
                new Song
                {
                    Name = @"Danh Sĩ Khúc Tứ Thủ/名士曲四首",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675025/danhsikhuctuthu_umh4m8.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652367/Vietsub_Pinyin_Danh_S%C4%A9_Kh%C3%BAc_T%E1%BB%A9_Th%E1%BB%A7%E5%90%8D%E5%A3%AB%E6%9B%B2%E5%9B%9B%E9%A6%96_OST_DramaR%E1%BA%A5t_Nh%E1%BB%9B_R%E1%BA%A5t_Nh%E1%BB%9B_Anh_%E5%BE%88%E6%83%B3%E5%BE%88%E6%83%B3%E4%BD%A0_wjlyo1.mp3",
                    Introduction = @"Tác từ: Minh Hoàng, Nam Kỳ (冥凰/南岐)
Tác khúc: Hạo Vận (皓韻)
Biên khúc: Thất Và Huyền Của Sao Đêm, Trần Thuấn Vũ, Chu Kim Thái, Vương Nguyên Chiêu (星夜的七和弦/陈舜禹/朱金泰/王元昭)
Nhạc phim: Rất nhớ rất nhớ anh",
                    Lyric = @"liè tiān:
Běichéng xiāosè tiānyá huí wàng lù mànmàn
fēnghuǒ liǎo yuán shuòfēng chuī bùduàn
zhuàngshì bǎi zhàn wú rén huán jīngqí bàn juǎn yǐ chū guān
hún shì gūyàn pánxuán tiānjì yuǎn wúxiàn shānhé kuān
duōshǎo yīngxióng fù guānshān xiāngjiàn hèn tài wǎn
huī bīng pò zhèn cè mǎwǎngōng shè luò yuè yī wān
zhè jiāngshān qiān jūn wǒ lái dān

xiánzi:
Yōuyōu qiān bǎi nián tánzhǐ yī huī jiān
xīngshuāi biànqiān fánhuá jiē rú yān
yīngxióng háojié tánhuāyīxiàn
fǔkàn rénjiān yǒu shéi zhī cāngshēng zuì kělián

zòng shì qiān bān jǐnxiù wànbān fēngliú dōu huà wūyǒu
cǐshēng yī qiāng hàoqì réng yījiù
zòng shì cánpò jiǔzhōu gāngē bùxiū wú rén lái jiù
wǒ yuàn shě qù hóngzhuāngzhe jiǎzhòu cāngmáng tiāndì rèn qù liú

lǐchángchāo:
Zhè biānguān běi fēng juǎn qǐ qiāngǔ de kuánglán
cányuè zhào biàn shèng wáng bài kòu yùxuè de chéngguān
fēnghuǒ xià shìshì biànqiān děng fēnghuílùzhuǎn
cè mǎ dài zhàn shā yì bèi wǒ yīniàn kànchuān
gōuhuǒ liè liè diǎnrán yī bǎ lángyān de shíjiān
yīngxióng zuòbié fēngyún zhǐ dài zhèn qián xiāng jiàn
xiào dāngnián huáng shā rú xuě shì wǒ zài tízhe jiàn
yī qiāng rèxuè pōsǎ xiàng mái gǔ rénjiān

xiāngshí xiāng bié yī mèng duō shào nián
rénshì biànqiān yīngxióng bù fù jiàn

tán jiàncì:
Běi wàng héchuān wàng bù chuān xīshuǐ mànmàn
cóng yún hàodàng lái sòng wǒ shàng xiāohàn
qiānlǐ xíng zhōudù chóngshān fēng cuī yǔ hán
cǐshēng zhǎnzhuǎn nán shí jiàn gāndǎn

běi wàng héchuān cányáng chù wúxiàn jiāngshān
shuòfēngguò zhòng guān dāng bùcí yī zhàn
rì yuè hàohàn zuò qípán luòzi míngduàn
gǔjīn zhēng róng suìyuè gǔngǔn lái
gǔjīn zhēng róng suìyuè gǔngǔn lái

pángbái:
Shǐ chén bǐmò jì wǒ cǐshēng shālù kě yú shǎoxǔ
ràng wǒ diànnèi dēng xià huà nǐ róngyán rú shǐ rúchū
".Trim(),

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(1,1),
                        new SongSinger(1,2),
                        new SongSinger(1,3),
                        new SongSinger(1,4),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(1,2),
                        new SongGenre(1,3),
                        new SongGenre(1,4),
                    }
                },

                 new Song
                {
                    Name = @"Bất nhiễm/不染",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733668638/batnhiem_nebhnv.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652367/y2mate.com_-_Vietsubpinyin_B%E1%BA%A5t_nhi%E1%BB%85m_Mao_B%E1%BA%A5t_D%E1%BB%8BchH%C6%B0%C6%A1ng_m%E1%BA%ADt_t%E1%BB%B1a_kh%C3%B3i_s%C6%B0%C6%A1ng_OST_%E4%B8%8D%E6%9F%93_%E6%AF%9B%E4%B8%8D%E6%98%93%E9%A6%99%E8%9C%9C%E6%B2%89%E6%B2%89%E7%83%AC%E5%A6%82%E9%9C%9C%E4%B8%BB%E9%A2%98%E6%9B%B2_hd3ui9.mp3",
                    Introduction = @"Bất nhiễm
Nhạc phim Hương mật tựa khói sương
Lời: Hải Lôi
Nhạc: Giản Hoằng Diệc
Biên khúc: Đinh Bồi Phong
Biểu diễn: Mao Bất Dịch",
                    Lyric = @"Bù yuàn rǎn shì yǔ fēi
zěn liào shìyǔyuànwéi
Xīnzhōng de huā kūwěi
shíguāng tā qù bù huí
Dàn yuàn xǐ qù fúhuá
dǎn qù yīshēn chén huī
Zài yǔ nǐ yī hú qīngjiǔ
huà yīshì chénzuì

Bù yuàn rǎn shì yǔ fēi
zěn liào shìyǔyuànwéi
Xīnzhōng de huā kūwěi
shíguāng tā qù bù huí
Huíyì zhan zhuàn láihuí
tòng bùguò zhè xīnfēi
Yuàn zhǐ yuàn yúshēng wú
huǐ suí huāxiāng yuǎn fēi

Yī hú qīngjiǔ yīshēn chén huī
Yīniàn láihuí dù yúshēng wú huǐ
Yī chǎng chūnqiū shēngshēng
miè miè fúhuá shìfēi

Dài huā kāi zhī shí zài zuì yī huí


Bù yuàn rǎn shì yǔ fēi
zěn liào shìyǔyuànwéi
Xīnzhōng de huā kūwěi
shíguāng tā qù bù huí
Huíyì zhan zhuàn láihuí
tòng bùguò zhè xīnfēi
Yuàn zhǐ yuàn yúshēng wú
huǐ suí huāxiāng yuǎn fēi


Yī hú qīngjiǔ yīshēn chén huī
Yīniàn láihuí dù yúshēng wú huǐ
Yī chǎng chūnqiū shēngshēng
miè miè fúhuá shìfēi
Dài huā kāi zhī shí zài zuì yī huí


Yuàn zhè shēngshēng de shíguāng bù zài
kūwěi dài huā kāi zhī shí zài zuì yī huí
Yuàn zhè shēngshēng de shíguāng bù zài
kūwěi
zàihuíshǒu qiǎncháng xīn jiǔ yúwèi

Yī hú qīngjiǔ yīshēn chén huī
Yīniàn láihuí dù yúshēng wú huǐ

Yī chǎng chūnqiū shēngshēng
miè miè fúhuá shìfēi
Dài huā kāi zhī shí zài zuì yī huí
Yī hú qīngjiǔ yīshēn chén huī
Yīniàn láihuí dù yúshēng wú huǐ

Yī chǎng huíyì shēngshēng
miè mièliǎoliǎo xīnfēi
Zàihuíshǒu qiǎncháng xīn jiǔ yúwèi
Yī chǎng huíyì shēngshēng
miè mièliǎoliǎo xīnfēi
Zàihuíshǒu qiǎncháng xīn jiǔ yúwèi",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(2,5),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(2,2),
                        new SongGenre(2,3),
                    }
                },

                   new Song
                {
                    Name = @"Lừa dối/骗",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675027/luadoi_kbddbw.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652359/y2mate.com_-_VietsubPinyin_L%E1%BB%ABa_d%E1%BB%91i_Tr%C6%B0%C6%A1ng_B%C3%ADch_Th%E1%BA%A7n_%E9%AA%97%E5%BC%A0%E7%A2%A7%E6%99%A8_Nh%E1%BA%A1c_Hoa_t%C3%A2m_tr%E1%BA%A1ng_w3mn05.mp3",
                    Introduction = @"Ca khúc: Lừa dối
Trình bày: Trương Bích Thần
Nhạc phim: Nếu không nhớ được thanh âm ấy",
                    Lyric = @"🎵 Pinyin:
Rúguǒ ài shì yǒngyǒu zhànjù
wǒ zěnme sōng kāi shǒu fàngqì
rèn liǎng kē xīn lā yuǎn jùlí
què wúnéngwéilì
xiàng wūyún zhù jìnle shēntǐ
liàngzhe dēng yě gǎnjué yāyì
zài gūdú zhōng tóngyàng yǒngjǐ
zàijiànle xiāngyù
wǒ kěyǐ xuézhe lěngmò xuézhe hěnxīn xuézhe wàngjì
bù ràng rén fà xiàn xīnlǐ miàn de qīngpén dàyǔ
céng yīqǐ kūguò xiàoguò tòngguò mèngguò
guānyú nǐ suǒyǒu yīqiè juékǒu bù tí
wǒ rúhé piànguò nèixīn piànguò yǎnlèi piànguò zìjǐ
shéi shuō de àiguò jiù yīdìng huì liú yǒu yìnjì
wǒmen de àiqíng ruò àn xià zàntíng
gàosù wǒ kěbù kěyǐ
xiàng wūyún zhù jìnle shēntǐ
liàngzhe dēng yě gǎnjué yāyì
zài gūdú zhōng tóngyàng yǒngjǐ
zàijiànle xiāngyù
wǒ kěyǐ xuézhe lěngmò xuézhe hěnxīn xuézhe wàngjì
bù ràng rén fà xiàn xīnlǐ miàn de qīngpén dàyǔ
céng yīqǐ kūguò xiàoguò tòngguò mèngguò
guānyú nǐ suǒyǒu yīqiè juékǒu bù tí
wǒ rúhé piànguò nèixīn piànguò yǎnlèi piànguò zìjǐ
shéi shuō de àiguò jiù yīdìng huì liú yǒu yìnjì
wǒmen de àiqíng ruò àn xià zàntíng
gàosù wǒ kěbù kěyǐ
yuè shì píngjìng de tòng yuè chèdǐ
nà zhǒng wúfǎ huítóu de xīnqíng
xiǎng yào wàngjì
rúhé wàngjì
wǒ kěyǐ xuézhe lěngmò xuézhe hěnxīn xuézhe wàngjì
bù ràng rén fà xiàn xīnlǐ miàn de qīngpén dàyǔ
céng yīqǐ kūguò xiàoguò tòngguò mèngguò
guānyú nǐ suǒ yǒu yīqiè juékǒu bù tí
wǒ rúhé piànguò nèixīn piànguò yǎnlèi piànguò zìjǐ
shéi shuō de àiguò jiù yīdìng huì liú yǒu yìnjì
wǒmen de àiqíng ruò àn xià zàntíng
gàosù wǒ kěbù kěyǐ",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(3,6),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(3,2),
                        new SongGenre(3,3),
                    }
                },

                    new Song
                {
                    Name = @"Liên Thành Từ",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675026/lienthanhtu_zadfxt.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652358/y2mate.com_-_Vietsub_TGCF_Li%C3%AAn_Th%C3%A0nh_T%E1%BB%AB_L%E1%BB%99c_H%C3%A0m_OST_Ho%E1%BA%A1t_h%C3%ACnh_Thi%C3%AAn_Quan_T%E1%BB%A9_Ph%C3%BAc_ypwpae.mp3",
                    Introduction = @"Bài hát: Liên Thành Từ

Biểu diễn: Lộc Hàm.

Viết lời: Trịnh Chí Hoàn

Soạn nhạc: Choi Jinwoo

Biên khúc và Chế tác: Viên Văn Duệ

Phối âm: Chu Thiên Triệt

Hiệu ứng chữ: Kirena Jang",
                    Lyric = @"Tạm thời chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(4,14),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(4,2),
                        new SongGenre(4,3),
                    }
                },

                    new Song
                {
                    Name = @"Bách Hoa Tàn/百花残",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675022/bachhoatan_maripz.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652352/y2mate.com_-_Vietsub_B%C3%A1ch_Hoa_T%C3%A0n_Th%C3%B4i_T%E1%BB%AD_C%C3%A1ch_%E5%B4%94%E5%AD%90%E6%A0%BC_%E7%99%BE%E8%8A%B1%E6%AE%8B_Ost_L%E1%BB%87_C%C6%A1_Truy%E1%BB%87n_ekbhag.mp3",
                    Introduction = @"Ca khúc: Bách Hoa Tàn
Trình bày: Thôi Tử Cách
Nhạc: Trần Thi Mục + Thôi Tử Cách
Lời: Thôi Thư",
                    Lyric = @"Phiên âm:
Bùzhī níshang nuǎn
zhǐ jué běi fēnghán
qián shì rú chén mírén yǎn
sìjì lúnliú zhuàn
kūróng duō biànhuàn
shēng gēchàng duàn bǎihuā cán
ài yǔ hèn jiāozhī jiūchán yuè lǐ yuè fēnluàn
rènpíng dāoguāngjiànyǐng jiǎn yě jiǎn bùduàn
bēi yǔ huān diēdàng xúnhuán jiéjú duō huāngdàn
fānyúnfùyǔ xímièle cànlàn
bǎihuā cán lèi bānlán
fánhuá yànxí zhōng xū sàn
jìmò kǔ qīngchūn duǎn rénshēng nán
bǎihuā cán kōng bēitàn
jìnghuāshuǐyuè jǐn xūhuàn
jǐnxiù jiāngshān róng bùxià àiliàn
bùzhī níshang nuǎn
zhǐ jué běi fēnghán
qián shì rú chén mírén yǎn
sìjì lúnliú zhuàn
kūróng duō biànhuàn
shēng gēchàng duàn bǎihuā cán
ài yǔ hèn jiāozhī jiūchán yuè lǐ yuè fēnluàn
rènpíng dāo guāng jiàn yǐng jiǎn yě jiǎn bùduàn
bēi yǔ huān diēdàng xúnhuán jiéjú duō huāngdàn
fānyúnfùyǔ xímièle cànlàn
bǎihuā cán lèi bānlán
fánhuá yànxí zhōng xū sàn
jìmò kǔ qīngchūn duǎn rénshēng nán
bǎihuā cán kōng bēitàn
jìnghuāshuǐyuè jǐn xūhuàn
jǐnxiù jiāngshān róng bùxià àiliàn
bǎihuā cán lèi bānlán
fánhuá yànxí zhōng xū sàn
jìmò kǔ qīngchūn duǎn rénshēng nán
bǎihuā cán shéi xī lián
déshī nán táo nàihé tiān
yù niǎn xiāng chē huí bù qù cóngqián
yù niǎn xiāng chē huí bù qù cóngqián",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(5,8),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(5,2),
                        new SongGenre(5,3),
                    }
                },

                      new Song
                {
                    Name = @"Sơ kiến/初见",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675021/sokien_yr0dzs.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652352/y2mate.com_-_Vietsubpinyin_S%C6%A1_ki%E1%BA%BFn_D%C6%B0_Chi%C3%AAu_Nguy%C3%AAn_Di%E1%BB%87p_L%C3%BD%C4%90%C3%B4ng_cung_OST_%E5%88%9D%E8%A7%81_%E4%BD%99%E6%98%AD%E6%BA%90_%E5%8F%B6%E9%87%8C%E4%B8%9C%E5%AE%AB%E4%B8%BB%E9%A2%98%E6%9B%B2_jaftmp.mp3",
                    Introduction = @"Sơ kiến
Nhạc phim Đông cung
Lời: Lý Ngọc Phi
Nhạc: Phùng Đạt
Biên khúc: Vu Hạo
Biểu diễn: Dư Chiêu Nguyên & Diệp Lý",
                    Lyric = @"Yè weiyà̄ng
yùe sè líang ỳing xī chuāng
qíanchén shì shènsī liang
mèng yōucháng
què zǒng shì jù sàn liǎng mángmáng
shī yǎnkùang zhǐ pàn nǐ húi wàng
shāng zài xīnlǐ jíe chéng shuāng
wàng bù dìao shì nǐ de muyá̀ng
húishǒu chū jìan nà cóngqían xiāng wàng de shùnjiān
zhuā bù zhù shēn chū de zhǐ jiān

líxīn sùi kōng líulèi rén bù guī
wàng chuān zhī shuǐ jìng kàn hóngchén shìfēi
shíguāng dào húi yǐn xìa wàngqíng yībēi
rùo rú chū jìan wèi shéi ér guī
qiū yòu qù chūn yòu guī
mèng yǔ xǐng lúnhúi

Yè weiyà̄ng
yùe sè líang ỳing xī chuāng
qíanchén shì shènsī liang
mèng yōucháng
què zǒng shì jù sàn liǎng mángmáng
shī yǎnkùang zhǐ pàn nǐ húi wàng

líxīn sùi kōng líulèi rén bù guī
wàng chuān zhī shuǐ jìng kàn hóngchén shìfēi
shíguāng dào húi yǐn xìa wàngqíng yībēi
rùo rú chū jìan wèi shéi ér guī

líxīn sùi kōng líulèi rén bù guī
wàng chuān zhī shuǐ jìng kàn hóngchén shìfēi
shíguāng dào húi yǐn xìa wàngqíng yībēi
rùo rú chū jìan wèi shéi ér guī
qiū yòu qù chūn yòu guī
mèng yǔ xǐng lúnhúi",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(6,10),
                        new SongSinger(6,9),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(6,2),
                        new SongGenre(6,3),
                    }
                },

                        new Song
                {
                    Name = @"Nước chảy từ trời/水從天上來",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675029/nuochaytutroi_ac41re.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652351/y2mate.com_-_VietsubKara_N%C6%B0%E1%BB%9Bc_ch%E1%BA%A3y_t%E1%BB%AB_tr%E1%BB%9Di_%E6%B0%B4%E5%BE%9E%E5%A4%A9%E4%B8%8A%E4%BE%86_Tr%C6%B0%C6%A1ng_B%C3%ADch_Th%E1%BA%A7n_ft_Tr%E1%BB%8Bnh_V%C3%A2n_Long_OST_Th%E1%BA%A7n_T%E1%BB%8Bch_Duy%C3%AAn_vvggk8.mp3",
                    Introduction = @"Tạm thời chưa có",
                    Lyric = @"Tạm thời chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(7,6),
                        new SongSinger(7,11),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(7,2),
                        new SongGenre(7,3),
                    }
                },

                         new Song
                {
                    Name = @"Biết chăng, Biết chăng/知否 知否",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675023/bietchangbietchang_ttx9vj.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652351/y2mate.com_-_Vietsub_Bi%E1%BA%BFt_ch%C4%83ng_Bi%E1%BA%BFt_ch%C4%83ng_Ho%C3%A0ng_Thi_Ph%C3%B9_Y%C3%AAu_D%C6%B0%C6%A1ng_%E7%9F%A5%E5%90%A6_%E7%9F%A5%E5%90%A6_%E9%BB%84%E8%AF%97%E6%89%B6_%E5%A6%96%E6%89%AC_sev9kg.mp3",
                    Introduction = @". Khúc: 知否 知否  | Biết chăng, Biết chăng
. Tác từ: 李清照, 张靖怡 | Lý Thanh Chiếu & Trương Tịnh Di
. Tác khúc: 刘炫豆 | Lưu Huyền Đậu
. Nguyên xướng: 郁可唯 & 胡夏| Úc Khả Duy & Hồ Hạ 
. Phiên xướng: 黄诗扶 & 妖扬 | Hoàng Thi Phù & Yêu Dương  
. Hỗn âm: 幺唠 | Yêu Lao",
                    Lyric = @"Pinyin:
Yī zhāo huā kāi bàng liǔ
 xún xiāng wù mì tíng hóu
 zòng yǐn zhāoxiá bànrì huī
 fēngyǔzhe bù tòu

 yīrèn gōng zhǎng xiāo shòu
 tái gāo bīng lèi nán liú
 jǐn shū sòng bà mò huíshǒu
 wúyú suì kě tōu

 zuóyè yǔ shū fēng zhòu
 nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù
 zhī fǒu zhī fǒu
 yīng shì lǜféi hóng shòu

 zuóyè yǔ shū fēng zhòu
 nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù
 zhī fǒu zhī fǒu
 yīng shì lǜféi hóng shòu

 yī zhāo huā kāi bàng liǔ
 xún xiāng wù mì tíng hóu
 zòng yǐn zhāoxiá bànrì huī
 fēngyǔzhe bù tòu

 yīrèn gōng zhǎng xiāo shòu
 tái gāo bīng lèi nán liú
 jǐn shū sòng bà mò huíshǒu
 wúyú suì kě tōu

 zuóyè yǔ shū fēng zhòu
 nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù 
zhī fǒu zhī fǒu
 yīng shì lǜféi hóng shòu

 zuóyè yǔ shū fēng zhòu
 nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù
 zhī fǒu zhī fǒu
 yīng shì lǜféi hóng shòu

 zuóyè yǔ shū fēng zhòu 
nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù
 zhī fǒu zhī fǒu 
yīng shì lǜféi hóng shòu

 zuóyè yǔ shū fēng zhòu
 nóng shuì bùxiāo cán jiǔ
 shìwèn juǎn lián rén què dào hǎitáng yījiù
 zhī fǒu zhī fǒu 
yīng shì lǜféi hóng shòu

 zhī fǒu zhī fǒu
 yīng shì lǜféi hóng shòu",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(8,12),
                        new SongSinger(8,13),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(8,2),
                        new SongGenre(8,3),
                    }
                },

                          new Song
                {
                    Name = @"Nếu Thanh Âm Không Ghi Nhớ/如果声音不记得",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1733675020/neuthanhamkhongghinho_q3ulvh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652351/y2mate.com_-_Vietsub_N%E1%BA%BFu_Thanh_%C3%82m_Kh%C3%B4ng_Ghi_Nh%E1%BB%9B_Ng%C3%B4_Thanh_Phong_%E5%A6%82%E6%9E%9C%E5%A3%B0%E9%9F%B3%E4%B8%8D%E8%AE%B0%E5%BE%97_%E5%90%B4%E9%9D%92%E5%B3%B0_iimirp.mp3",
                    Introduction = @"Nếu Thanh Âm Không Ghi Nhớ - Ngô Thanh Phong | 如果声音不记得 - 吴青峰
Sáng tác: inDy
Lời: Quách Kính Minh, Lạc Lạc
Nhạc phim Nếu Thanh Âm Không Ghi Nhớ | The End of Endless Love | 如果声音不记得 OST ",
                    Lyric = @"rú guǒ shuō wǒ de shēng yīn dōu jì dé 
niàn nǐ míng zi shí tǎn tè 
xǐ yuè hé kǔ sè 
rú guǒ nǐ shì yì qǔ liàn gē 
nà wǒ shì gé chuāng xié yáng yì mǒ  
cóng chén xī dào rì luò 
nǐ shì tiān kōng fēi guò de xìn gē 
wǒ shì luò kuǎn de bǐ mò 
wǒ yǒu wàn yǔ qiān yán 
cáng zài chàn dǒu de zì lǐ háng jiān 

yi tiān yi tiān yì nián yòu yì nián    
měi gè zhuǎn shēn huǎng rú chū jiàn 
sī niàn shì chūn cán 
yì kǒu yi kǒu chī diào shí jiān 
chūn fēng qiū yǔ luò bǐ chéng niàn 

xīn huā yì duǒ shān yě làn màn 
luò yè de chán mián 
fēng de gān yuàn 
xīn de huā yuán huāng wú yí piàn 
dào shù de wēn nuǎn 
 
yǒu dēng guāng cuī cù wǒ sàn chǎng   
yǒu xīn huǒ diǎn liàng zhè chǎng lí shāng 
xīn lǐ liú le shàn chuāng 
yuè guāng zhào dé yǐng zi cháng cháng cháng 
jiù ràng wǒ duì ài tóu xiáng 

ràng wǒ bù lǚ chéng shuāng  
guī tú rì mù zhōng diē diē zhuàng zhuàng 

yì tiān yi tiān yì nián yòu yì nián 
xīn yǒu jīng hóng shēn rú huī yàn 
lí qù de shào nián 
fēng chén pú pú jiàn zì rú miàn  
chūn fēng qiū yǔ luò bǐ chéng niàn   

xīn huā yì duǒ shān yě làn màn 
luò yè de chán mián 
fēng de gān yuàn 
xīn de huā yuán huāng wú yí piàn 
dào shù de wēn nuǎn 

shì yán zǒng tān lán wú dāng   
duì dào cǎo jǐn zhuā bú fàng   
yuè guāng bǎ lèi chuī liáng     
ài hé hèn tiān gè yì fāng 
wǒ men biàn tǐ lín shāng   
mèng què ān rán wú yàng    
bù sī liang zì nán wàng 

yì tiān yi tiān yì nián yòu yì nián    
měi gè zhuǎn shēn huǎng rú chū jiàn 
lí qù de shào nián  
fēng chén pú pú jiàn zì rú miàn    
chūn fēng qiū yǔ luò bǐ chéng niàn 
xīn huā yì duǒ shān yě làn màn   
luò yè de chéng quán    
fēng de zhí niàn   
gù dì chóng yóu jiǎo bù qīng qiǎn   
bù gān de gān yuàn 
bù gān de gān yuàn",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(9,15),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(9,2),
                        new SongGenre(9,3),
                    }
                },


             new Song
                {
                    Name = @"Chỉ hỏi nàng có bằng lòng?/只问你肯不肯",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734444508/chihoinangcobanglong_goi5he.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652340/y2mate.com_-_Vietsubpinyin_Ch%E1%BB%89_h%E1%BB%8Fi_n%C3%A0ng_c%C3%B3_b%E1%BA%B1ng_l%C3%B2ng_H%E1%BB%93_H%E1%BA%A1Minh_Lan_truy%E1%BB%87n_OST_%E5%8F%AA%E9%97%AE%E4%BD%A0%E8%82%AF%E4%B8%8D%E8%82%AF_%E8%83%A1%E5%A4%8F%E7%9F%A5%E5%90%A6%E7%9F%A5%E5%90%A6%E5%BA%94%E6%98%AF%E7%BB%BF%E8%82%A5%E7%BA%A2%E7%98%A6%E6%A6%82%E5%BF%B5%E6%9B%B2_cevypx.mp3",
                    Introduction = @"Chỉ hỏi nàng có bằng lòng?
Nhạc phim Minh Lan truyện aka Thật ư thật ư phải là hồng phai xanh thắm
Lời: Trương Tịnh Di
Nhạc: Lưu Huyền Đậu
Biên khúc: Lưu Huyền Đậu
Biểu diễn: Hồ Hạ",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(10,16),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(10,2),
                        new SongGenre(10,3),
                    }
                },

             new Song
                {
                    Name = @"Dữ Quân Quy/与君归",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1734479713/duquanquy_bcomxh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1734479256/D%E1%BB%AF_Qu%C3%A2n_Quy_-_%C4%90%C3%A0n_Ki%E1%BB%87n_Th%E1%BB%A9_L%E1%BA%A1c_Ti%E1%BB%83u_%C4%90%C3%A0o_bz7gaj.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"𝑝𝑖𝑛𝑦𝑖𝑛
jiāng suìyuè dù chéng yī yè piāoyáo de zhōu
yóuyìguò xiōngyǒng yòu wān yán de líchóu
pà wǎngshì bèi yíngmiàn ér lái de hán fēng chuī zhòu
jiǎo sàn chéng yīpiàn jiāngshuǐ yōuyōu
yòng zhǐ jiān mósāguò pòliè de quēkǒu
bù gǎn kàn jìng zhōng de cāng yán yǔ hàoshǒu
duōnián hòu sīniàn què yīrán hái fēnglì rú jiù
qīng jiǎnle yīlù rényǐng xiāoshòu
jiāng huíyì yán chéng mòjī
xiě yī zhǐ línlí
jìng yǔ rén jù qù
hé chù kě wèn guīqī
tóng jìng pòsuìle biélí
xiāngsī zǒng nán jì
qiān wàn lǐ
xiào cǐshēng míng lù rónghuá
huàn zuò jìng zhōng huā
nán dǐ nǐ shǒuzhōng yī zhǎn qīngchá
ruò néng jǔ bēi gòng qí méi
jiāng qiánchén yǐn xià
xiāngyī xiāngbàn bù shě zhāoxì
xiāngbàn gòng zhāoxì
língdīng zài shānhé tiānyá
shuāng bái é qián fā
fàng yǎn wàng rénjiān héyǐ wéi jiā
yuàn qīng shuāng yìng míngyuè
zhào jìng zhōng rényǐng chéng shuāng
yǔ jūn guī qù
kuí kuòle bànshēng fēngyǔ

lóu zhōng shù bǐ
liú shàng línquánfù
yǎn juǎn liǎng shēng
shì yǔ jūn tóng guī

jiāng huíyì yán chéng mòjī
xiě yī zhǐ línlí
jìng yǔ rén jù qù
hé chù kě wèn guīqī
tóng jìng pòsuìle biélí
xiāngsī zǒng nán jì
qiān wàn lǐ
xiào cǐshēng míng lù rónghuá
huàn zuò jìng zhōng huā
nán dǐ nǐ shǒuzhōng yī zhǎn qīngchá
ruò néng jǔ bēi gòng qí méi
jiāng qiánchén yǐn xià
xiāngyī xiāngbàn bù shě zhāoxì
xiāngbàn gòng zhāoxì
língdīng zài shānhé tiānyá
shuāng bái é qián fā
fàng yǎn wàng rénjiān héyǐ wéi jiā
yuàn qīng shuāng yìng míngyuè
zhào jìng zhōng rényǐng chéng shuāng
yǔ jūn guī qù
kuí kuòle bànshēng fēngyǔ
jiāng suìyuè dù chéng yī yè bù xì zhī zhōu
yóuyìguò xiōngyǒng yòu wān yán de jiāng liú
wǎngshì bèi yī céng céng yàng kāi liàn yàn zài xīntóu
míngmiè de yuè sè yōuyōu
míngmiè de yuè sè yōuyōu

shí fāng bù zài
sìhǎi wú cún
nǎi gǎn yǔ ěr jué",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(11,17),
                        new SongSinger(11,4),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(11,2),
                        new SongGenre(11,3),
                        new SongGenre(11,4),
                    }
                },

                new Song
                {
                    Name = @"Hồng (Màu Đỏ)",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249038/hong_y7lrnk.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652327/y2mate.com_-_Vietsub_MV_H%E1%BB%93ng_M%C3%A0u_%C4%90%E1%BB%8F_Mao_B%E1%BA%A5t_D%E1%BB%8Bch_OST_Th%E1%BB%A5c_C%E1%BA%A9m_Nh%C3%A2n_Gia_%E8%9C%80%E9%94%A6%E4%BA%BA%E5%AE%B6%E6%AD%8C%E6%9B%B2_%E7%BA%A2%E6%AF%9B%E4%B8%8D%E6%98%93_lmhcwu.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(12,5),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(12,2),
                        new SongGenre(12,3),
                    }
                },

                new Song
                {
                    Name = @"Niên Tuế/年岁",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249039/nientue_k2nlfy.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652329/y2mate.com_-_vietsub_Ni%C3%AAn_Tu%E1%BA%BF_Mao_B%E1%BA%A5t_D%E1%BB%8Bch_%E5%B9%B4%E5%B2%81_%E6%AF%9B%E4%B8%8D%E6%98%93_%E5%8D%83%E5%8F%A4%E7%8E%A6%E5%B0%98Thi%C3%AAn_C%E1%BB%95_Quy%E1%BA%BFt_Tr%E1%BA%A7n_OST_gzu8bb.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(13,5),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(13,2),
                        new SongGenre(13,3),
                    }
                },

                new Song
                {
                    Name = @"Đào hoa nặc/桃花诺",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249037/daohoanac_atyrrb.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652330/y2mate.com_-_Vietsubpinyin_%C4%90%C3%A0o_hoa_n%E1%BA%B7c_GEM_%C4%90%E1%BA%B7ng_T%E1%BB%AD_K%E1%BB%B3Th%C6%B0%E1%BB%A3ng_c%E1%BB%95_t%C3%ACnh_ca_OST_%E6%A1%83%E8%8A%B1%E8%AF%BA_%E9%82%93%E7%B4%AB%E6%A3%8B_GEM%E4%B8%8A%E5%8F%A4%E6%83%85%E6%AD%8C%E7%89%87%E5%B0%BE%E6%9B%B2_ytadfl.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(14,18),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(14,2),
                        new SongGenre(14,3),
                    }
                },

                new Song
                {
                    Name = @"Nhất Liêm Thanh Hoan",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249039/nhatliemthanhhoan_tgzdup.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652332/y2mate.com_-_Vietsub_Nh%E1%BA%A5t_Li%C3%AAm_Thanh_Hoan_Th%E1%BB%8F_Kh%E1%BB%8Fa_Ti%C3%AAn_%C4%90%E1%BA%A3n_Quy%E1%BB%83n_%E4%B8%80%E5%B8%98%E6%B8%85%E6%AC%A2_%E5%85%94%E8%A3%B9%E7%85%8E%E8%9B%8B%E5%8D%B7_jlq3pq.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(15,19),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(15,2),
                    }
                },

                new Song
                {
                    Name = @"Cửu Vạn Tự (90.000 chữ)/九万字",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249038/cuuvantu_uer0n4.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652335/y2mate.com_-_Vietsub_C%E1%BB%ADu_V%E1%BA%A1n_T%E1%BB%B1_90000_ch%E1%BB%AF_Ho%C3%A0ng_Thi_Ph%C3%B9_%E4%B9%9D%E4%B8%87%E5%AD%97_%E9%BB%84%E8%AF%97%E6%89%B6_pum6mc.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(16,12),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(16,2),
                        new SongGenre(16,4),
                    }
                },

                new Song
                {
                    Name = @"Bách Hoa Lạc/百花落",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249038/bachhoalac_daywwz.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652335/y2mate.com_-_Vietsub_Pinyin_B%C3%A1ch_Hoa_L%E1%BA%A1c_Ng%E1%BA%A1o_H%C3%A0n_%C4%90%E1%BB%93ng_H%E1%BB%8Dc_%E7%99%BE%E8%8A%B1%E8%90%BD_%E5%82%B2%E5%AF%92%E5%90%8C%E5%AD%A6_fot2u6.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(17,20),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(17,2),
                    }
                },

                new Song
                {
                    Name = @"Vong Xuyên/忘川",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249042/vongxuyen_dmcxfe.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652336/y2mate.com_-_VietsubKara_Vong_Xuy%C3%AAn_Ti%E1%BB%83u_Kh%C3%BAc_Nhi_%E5%BF%98%E5%B7%9D_%E5%B0%8F%E6%9B%B2%E5%84%BF_gnqtm0.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(18,21),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(18,2),
                        new SongGenre(18,4),

                    }
                },

                new Song
                {
                    Name = @"Lưu Vân Mạn/流云慢",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249039/luuvanman_cgvc7w.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652336/y2mate.com_-_Vietsub_L%C6%B0u_V%C3%A2n_M%E1%BA%A1n_Di%E1%BB%87p_L%C3%BD_%E6%B5%81%E4%BA%91%E6%85%A2_%E5%8F%B6%E9%87%8C_ntymnj.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(19,9),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(19,2),

                    }
                },


                new Song
                {
                    Name = @"Trường An xưa/故长安",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249041/truonganxua_xt2ykt.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652337/y2mate.com_-_Vietsubpinyin_Tr%C6%B0%E1%BB%9Dng_An_x%C6%B0a_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nhT%C6%B0%C6%A1ng_d%E1%BA%A1_OST_%E6%95%85%E9%95%BF%E5%AE%89_%E5%BC%A0%E9%9D%93%E9%A2%96%E5%B0%86%E5%A4%9C%E4%B8%BB%E9%A2%98%E6%9B%B2_g8ihdu.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(20,22),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(20,2),
                        new SongGenre(20,3),
                    }
                },

                new Song
                {
                    Name = @"Rừng Tiếng Chim/鸟语林",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249042/rungtiengchim_kfnctz.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652341/y2mate.com_-_Vietsub_R%E1%BB%ABng_Ti%E1%BA%BFng_Chim_Song_S%C3%AAnh_%E9%B8%9F%E8%AF%AD%E6%9E%97_%E5%8F%8C%E7%AC%99_x3a86y.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(21,23),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(21,2),
                        new SongGenre(21,3),
                    }
                },

                new Song
                {
                    Name = @"Niên Luân",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249039/nienluan_ynrz9h.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652344/y2mate.com_-_Vietsub_Pinyin_Hanzi_Ni%C3%AAn_Lu%C3%A2n_Tr%C6%B0%C6%A1ng_Bich_Th%C3%A2n_OST_Hoa_Thi%C3%AAn_C%C3%B4t_drdnq5.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(22,6),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(22,2),
                        new SongGenre(22,3),
                    }
                },

                new Song
                {
                    Name = @"Chăm Chú/凝眸",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736249039/chamchu_htvij7.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652327/y2mate.com_-_Vietsub_MV_OST_V%C4%A9nh_D%E1%BA%A1_Tinh_H%C3%A0_Ch%C4%83m_Ch%C3%BA_V%C6%B0%C6%A1ng_T%C3%A2m_L%C4%83ng_ft_Tr%C6%B0%C6%A1ng_Vi%E1%BB%85n_%E6%B0%B8%E5%A4%9C%E6%98%9F%E6%B2%B3%E6%AD%8C%E6%9B%B2_%E5%87%9D%E7%9C%B8_%E7%8E%8B%E5%BF%83%E5%87%8C_%E5%BC%A0%E8%BF%9C_gyt5fh.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",

                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(23,25),
                        new SongSinger(23,26),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(23,2),
                        new SongGenre(23,3),
                    }
                },

                new Song
                {
                    Name = @"Thanh Xuân",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736257589/thanhxuan_bapsqn.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736257509/Thanh_Xu%C3%A2n_-_Da_LAB_Official_MV_yeqsdz.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    IsVip = true,
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(24,27),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(24,1),
                    }
                },

                new Song
                {
                    Name = @"YÊU 5",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258158/yeu5_lfqugk.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736258212/Lyrics_Y%C3%8AU_5_-_Rhymastic_z0jhan.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    IsVip = true,
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(25,29),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(25,1),
                    }
                },

                 new Song
                {
                    Name = @"Cứ Chill Thôi",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258161/cuchillthoi_rbbvek.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736258208/C%E1%BB%A9_Chill_Th%C3%B4i_-_Chillies_Official_Music_Video_ft._Suni_H%E1%BA%A1_Linh_Rhymastic_dpogke.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    IsVip = true,
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(26,28),
                        new SongSinger(26,29),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(26,1),
                    }
                },

                 new Song
                {
                    Name = @"Đầu Hạ Năm Ấy",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258816/dauhanamay_zbvyed.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736258790/VietsubPinyin_%C4%90%E1%BA%A7u_H%E1%BA%A1_N%C4%83m_%E1%BA%A4y-_Nh%E1%BA%ADm_Nhi%C3%AAn_wonuto.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(27,30),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(27,2),
                        new SongGenre(27,3),

                    }
                },

                 new Song
                {
                    Name = @"Trục Nguyệt/逐月",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736258976/trucnguyet_w9zewa.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736258926/Vietsub_Tr%E1%BB%A5c_Nguy%E1%BB%87t_-_Ch%C3%A2u_Th%C3%A2m_Nh%E1%BA%A1c_phim_Nguy%E1%BB%87t_Ca_H%C3%A0nh_%E9%80%90%E6%9C%88_-_%E5%91%A8%E6%B7%B1_Drama_Song_Of_The_Moon_OST_tdkwwp.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(28,24),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(28,2),
                        new SongGenre(28,3),

                    }
                },

                 new Song
                {
                    Name = @"Trầm Hương/沉香",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736259263/tramhuong_md32kq.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736259216/Vietsub_Pinyin_Tr%E1%BA%A7m_H%C6%B0%C6%A1ng_-_Tr%C6%B0%C6%A1ng_Ki%E1%BB%87t_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nh_%E6%B2%89%E9%A6%99-%E5%BC%A0%E6%9D%B0_%E5%BC%A0%E9%9D%93%E9%A2%96_OST_Tr%E1%BA%A7m_V%E1%BB%A5n_H%C6%B0%C6%A1ng_Phai_blfs0x.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(29,31),
                        new SongSinger(29,22),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(29,2),
                        new SongGenre(29,3),

                    }
                },

                 new Song
                {
                    Name = @"Trường tương tư/长相思",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736259422/truongtuongtu_gmn8id.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736259715/Vietsub_Pinyin_Tr%E1%BA%A7m_H%C6%B0%C6%A1ng_-_Tr%C6%B0%C6%A1ng_Ki%E1%BB%87t_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nh_%E6%B2%89%E9%A6%99-%E5%BC%A0%E6%9D%B0_%E5%BC%A0%E9%9D%93%E9%A2%96_OST_Tr%E1%BA%A7m_V%E1%BB%A5n_H%C6%B0%C6%A1ng_Phai_kv678j.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(30,12),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(30,2),
                        new SongGenre(30,3),
                        new SongGenre(30,4),

                    }
                },

                 new Song
                {
                    Name = @"Kim Tịch Hà Tịch/今夕何夕",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736259739/kimtichhatich_usdswb.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736259925/Vietsub_Kim_T%E1%BB%8Bch_H%C3%A0_T%E1%BB%8Bch_-_Huy%E1%BB%81n_T%E1%BB%AD_Nh%E1%BA%A1c_phim_Ph%C3%BAc_L%C6%B0u_Ni%C3%AAn_%E4%BB%8A%E5%A4%95%E4%BD%95%E5%A4%95_-_%E5%BC%A6%E5%AD%90_%E8%A6%86%E6%B5%81%E5%B9%B4_%E5%BD%B1%E8%A7%86%E5%89%A7OST_3_chzyii.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(31,2),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(31,2),
                        new SongGenre(31,3),

                    }
                },

                  new Song
                {
                    Name = @"Phó Hồng Môn/赴鸿门",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736260157/phohongmon_dkwqsw.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736260094/Vietsub____Ph%C3%B3_H%E1%BB%93ng_M%C3%B4n_-_Y%C3%AAu_D%C6%B0%C6%A1ng___Ho%C3%A0ng_Thi_Ph%C3%B9_live___%E8%B5%B4%E9%B8%BF%E9%97%A8_-_%E5%A6%96%E6%89%AC___%E9%BB%84%E8%AF%97%E6%89%B6_qY5p9rX4lcw_kmbznl.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(32,12),
                        new SongSinger(32,13),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(32,2),

                    }
                },

                  new Song
                {
                    Name = @"Quy Y/皈依",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736260282/quyy_kl4h80.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736260094/Vietsub____Ph%C3%B3_H%E1%BB%93ng_M%C3%B4n_-_Y%C3%AAu_D%C6%B0%C6%A1ng___Ho%C3%A0ng_Thi_Ph%C3%B9_live___%E8%B5%B4%E9%B8%BF%E9%97%A8_-_%E5%A6%96%E6%89%AC___%E9%BB%84%E8%AF%97%E6%89%B6_qY5p9rX4lcw_kmbznl.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(33,21),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(33,2),
                        new SongGenre(33,4),


                    }
                },

                  

                  new Song
                {
                    Name = @"Ảo Mộng/幻梦",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267056/aomong_nqwgms.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736267239/%E1%BA%A2o_M%E1%BB%99ng_-_B%E1%BA%A5t_T%C3%A0i_%E5%B9%BB%E6%A2%A6_-_%E4%B8%8D%E6%89%8D_OST_V%C3%A2n_T%C6%B0%C6%A1ng_Truy%E1%BB%87n%E4%BA%91%E8%A5%84%E4%BC%A0_Li_Qiong_ap3o8s.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(34,77),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(34,2),
                        new SongGenre(34,3),


                    }
                },

                  new Song
                {
                    Name = @"Cặp đôi đẹp nhất",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267056/capdoidepnhat_esorfa.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268112/Vietsub_Pinyin_C%E1%BA%B7p_%C4%91%C3%B4i_%C4%91%E1%BA%B9p_nh%E1%BA%A5t_-_H%E1%BA%AFc_K%E1%BB%B3_T%E1%BB%AD_-_%E6%9C%80%E7%BE%8E%E6%83%85%E4%BE%B6_-_%E9%BB%91%E5%B4%8E%E5%AD%90_f1i9el.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(35,76),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(35,2),

                    }
                },

                  new Song
                {
                    Name = @"Hỏi",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267066/hoi_uzfrvf.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1733652340/y2mate.com_-_Vietsubpinyin_Ch%E1%BB%89_h%E1%BB%8Fi_n%C3%A0ng_c%C3%B3_b%E1%BA%B1ng_l%C3%B2ng_H%E1%BB%93_H%E1%BA%A1Minh_Lan_truy%E1%BB%87n_OST_%E5%8F%AA%E9%97%AE%E4%BD%A0%E8%82%AF%E4%B8%8D%E8%82%AF_%E8%83%A1%E5%A4%8F%E7%9F%A5%E5%90%A6%E7%9F%A5%E5%90%A6%E5%BA%94%E6%98%AF%E7%BB%BF%E8%82%A5%E7%BA%A2%E7%98%A6%E6%A6%82%E5%BF%B5%E6%9B%B2_cevypx.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(36,75),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(36,2),
                        new SongGenre(36,3),


                    }
                },

                  

                  

                   new Song
                {
                    Name = @"Vội Vã/匆匆",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/voiva_ntm53m.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268139/V%E1%BB%99i_V%C3%A3_L%C6%B0u_V%C5%A9_Ninh_-_Nh%E1%BA%A1c_phim_Tr%C6%B0%E1%BB%9Dng_Phong_%C4%90%E1%BB%99_OST_%E9%95%BF%E9%A3%8E%E6%B8%A1_%E5%88%98%E5%AE%87%E5%AE%81_%E5%8C%86%E5%8C%86_-_Chinese_Drama_Destined_OST_aipqjg.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(37,35),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(37,2),
                        new SongGenre(37,3),

                    }
                },

                   new Song // chưa
                {
                    Name = @"Nguyệt bán minh thời/月半明时",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/nguyetbanminhthoi_qdyqrq.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268151/Vietsub_Nguy%E1%BB%87t_b%C3%A1n_minh_th%E1%BB%9Di_-_H%E1%BA%A7u_Minh_H%E1%BA%A1o_--_%E6%9C%88%E5%8D%8A%E6%98%8E%E6%97%B6_-_%E4%BE%AF%E6%98%8E%E6%98%8A___%E5%B0%91%E5%B9%B4%E7%99%BD%E9%A9%AC%E9%86%89%E6%98%A5%E9%A3%8E_OST_sa9lid.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(38,74),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(38,2),
                        new SongGenre(38,3),


                    }
                },

                   new Song
                {
                    Name = @"Hí văn thuyết/戏文说",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/hivanthuyet_kthwlt.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268013/Vietsub_H%C3%AD_v%C4%83n_thuy%E1%BA%BFt_-_Khi%E1%BA%BFu_B%E1%BA%A3o_B%E1%BA%A3o_ft_T%C6%B0%E1%BB%9Dng_L%E1%BA%B7c_L%E1%BA%B7c_--_%E6%88%8F%E6%96%87%E8%AF%B4_-_%E5%8F%AB%E5%AE%9D%E5%AE%9D-%E7%A5%A5%E5%98%9E%E5%98%9E___C%E1%BB%ADu_tr%C3%B9ng_t%E1%BB%AD_%E4%B9%9D%E9%87%8D%E7%B4%AB_OST_osn6cp.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(39,72),
                        new SongSinger(39,73),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(39,2),
                        new SongGenre(39,3),
                        new SongGenre(39,4),


                    }
                },

                   

                   new Song
                {
                    Name = @"Phong Tức/风息",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/phongtuc_l1l1sn.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268006/Phong_T%E1%BB%A9c_H%E1%BB%93_Ng%E1%BA%A1n_B%C3%A2n_Di%E1%BB%87p_Huy%E1%BB%81n_Thanh_-_Nh%E1%BA%A1c_phim_Th%E1%BA%A3_Th%C3%AD_Thi%C3%AAn_H%E1%BA%A1_OST_%E4%B8%94%E8%AF%95%E5%A4%A9%E4%B8%8B_-_%E9%A3%8E%E6%81%AF_%E8%83%A1%E5%BD%A6%E6%96%8C_%E5%8F%B6%E7%82%AB%E6%B8%85_qvivff.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(40,71),
                        new SongSinger(40,38),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(40,2),
                        new SongGenre(40,3),


                    }
                },

                   new Song
                {
                    Name = @"Không Quên/无忘",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/khongquen_lyjocj.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268141/Vietsub_Pinyin_Kh%C3%B4ng_Qu%C3%AAn_-_Tr%C6%B0%C6%A1ng_L%E1%BB%97i_-_%E6%97%A0%E5%BF%98_-_%E5%BC%A0%E7%A3%8A_--_OST_Tr%E1%BA%A7m_V%E1%BB%A5n_H%C6%B0%C6%A1ng_Phai_xzi4il.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(41,78),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(41,2),
                        new SongGenre(41,3),


                    }
                },

                   new Song
                {
                    Name = @"Ngắm nhìn/看",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/ngamnhin_zfzmpb.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268123/Vietsub_pinyin_Ng%E1%BA%AFm_nh%C3%ACn_-_L%E1%BB%A5c_H%E1%BB%95_Di%C3%AAn_Hy_c%C3%B4ng_l%C6%B0%E1%BB%A3c_OST_-_%E7%9C%8B_-_%E9%99%86%E8%99%8E_%E5%BB%B6%E7%A6%A7%E6%94%BB%E7%95%A5_%E4%B8%BB%E9%A2%98%E6%9B%B2_2_hznlz2.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(42,44),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(42,2),
                        new SongGenre(42,3),


                    }
                },

                    new Song
                {
                    Name = @"Thiên đăng nguyện/千灯愿",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/thiendangnguyen_phqmwg.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268106/Vietsub_Thi%C3%AAn_%C4%91%C4%83ng_nguy%E1%BB%87n_-_Ng%E1%BA%A3i_Th%E1%BA%A7n_--_%E5%8D%83%E7%81%AF%E6%84%BF_-_%E8%89%BE%E8%BE%B0_--_Thi%C3%AAn_Quan_T%E1%BB%A9_Ph%C3%BAc_trapqz.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(43,60),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(43,2),

                    }
                },

                    new Song
                {
                    Name = @"Thiên Nhược Hữu Tình/时光洪流",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/thiennhuochuutinh_cg0oos.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268128/Vietsub_Thi%C3%AAn_Nh%C6%B0%E1%BB%A3c_H%E1%BB%AFu_T%C3%ACnh_-_Tr%C3%AC_Ng%C6%B0_-_%E5%A4%A9%E8%8B%A5%E6%9C%89%E6%83%85_-_%E6%B1%A0%E9%B1%BC_riztny.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(44,70),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(44,2),

                    }
                },

                     new Song
                {
                    Name = @"Dòng thác thời gian/天若有情",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/dongthacthoigian_auev1u.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268148/Vietsub_D%C3%B2ng_th%C3%A1c_th%E1%BB%9Di_gian_-_Tr%C3%ACnh_H%C6%B0%E1%BB%9Fng_--_%E6%97%B6%E5%85%89%E6%B4%AA%E6%B5%81_-_%E7%A8%8B%E5%93%8D_tiiowj.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(45,69),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(45,2),

                    }
                },

                     new Song
                {
                    Name = @"Nếu Người Nghe Thấy/若你也听见",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/neunguoinghethay_sexr3m.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268150/Vietsub_N%E1%BA%BFu_Ng%C6%B0%E1%BB%9Di_Nghe_Th%E1%BA%A5y_-_Vi%C3%AAn_%C3%81_Duy_-_OST_H%E1%BB%93_Y%C3%AAu_Ti%E1%BB%83u_H%E1%BB%93ng_N%C6%B0%C6%A1ng_Nguy%E1%BB%87t_H%E1%BB%93ng_Thi%C3%AAn_--_%E8%8B%A5%E4%BD%A0%E4%B9%9F%E5%90%AC%E8%A7%81_rldx3y.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(46,55),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(46,2),
                        new SongGenre(46,3),


                    }
                },

                     new Song
                {
                    Name = @"Bạn bình thường/泛泛之友",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/banbinhthuong_m54ucl.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268011/Vietsub_B%E1%BA%A1n_b%C3%ACnh_th%C6%B0%E1%BB%9Dng_-_V%C6%B0%C6%A1ng_T%C4%A9nh_V%C4%83n_ft_C%C3%A1i_Qu%C3%A2n_Vi%C3%AAm_--_%E6%B3%9B%E6%B3%9B%E4%B9%8B%E5%8F%8B_-_%E7%8E%8B%E9%9D%96%E9%9B%AF_ft_%E7%9B%96%E5%90%9B%E7%82%8E_elolnh.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(47,67),
                        new SongSinger(47,68),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(47,2),

                    }
                },


                     new Song
                {
                    Name = @"Cung Dưỡng Ái Tình/爱的供养",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267064/cungduongaitinh_kvfjoh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268145/Pinyin_Vietsub_Cung_D%C6%B0%E1%BB%A1ng_%C3%81i_T%C3%ACnh_-_Ch%C3%A2u_Th%C3%A2m_U%C3%B4ng_T%C3%B4_Lang_-_%E7%88%B1%E7%9A%84%E4%BE%9B%E5%85%BB_-_%E5%91%A8%E6%B7%B1_%E6%B1%AA%E8%8B%8F%E6%B3%B7_2_ifspu1.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(48,24),
                        new SongSinger(48,62),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(48,2),

                    }
                },

                     
                      new Song //chua
                {
                    Name = @"Phong diệp thành/枫叶城",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/phongdiepthanh_gfxnvz.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268141/vietsub_Phong_di%E1%BB%87p_th%C3%A0nh_Th%C3%A0nh_l%C3%A1_phong_-_Bunnyi_11_-_%E6%9E%AB%E5%8F%B6%E5%9F%8E_-_Bunnyi_11_y4ynef.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(49,66),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(49,2),

                    }
                },

                      new Song
                {
                    Name = @"Thương Hải Long Ngâm/沧海龙吟",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/thuonghailongngam_nbdqm3.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268007/Vietsub_--_Th%C6%B0%C6%A1ng_H%E1%BA%A3i_Long_Ng%C3%A2m_-_Ti%E1%BB%83u_Kh%C3%BAc_Nhi_Ngao_B%C3%ADnh_Nguy%C3%AAn_Sang_%C4%90%E1%BB%93ng_Nh%C3%A2n_Kh%C3%BAc_-_%E6%B2%A7%E6%B5%B7%E9%BE%99%E5%90%9F_-_%E5%B0%8F%E6%9B%B2%E5%84%BF_maka5u.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(50,21),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(50,2),

                    }
                },

                      new Song
                {
                    Name = @"Đối mặt sinh tử/向死而生",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/doimatsinhtu_i32rfv.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268114/Vietsub_pinyin_%C4%90%E1%BB%91i_m%E1%BA%B7t_sinh_t%E1%BB%AD-H%C6%B0%E1%BB%9Bng_T%E1%BB%AD_M%C3%A0_Sinh_Li%E1%BB%87t_Di%E1%BB%85m_V%C5%A9_Canh_K%E1%BB%B7_OST-L%C6%B0u_V%C5%A9_Ninh.%E5%90%91%E6%AD%BB%E8%80%8C%E7%94%9F-%E5%88%98%E5%AE%87%E5%AE%81_qd40ka.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(51,35),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(51,2),

                    }
                },

                      new Song
                {
                    Name = @"Lòng Chàng tựa lòng Ta/卿心似我心",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/longchangtualongta_arv09n.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268154/Vietsub_l%C3%B2ng_Ch%C3%A0ng_t%E1%BB%B1a_l%C3%B2ng_Ta_-_ycccc_-_Nh%E1%BA%A1c_phim_D%E1%BB%AF_Khanh_Th%C6%B0_C%C3%B9ng_Khanh_Th%C6%B0_-_%E5%8D%BF%E5%BF%83%E4%BC%BC%E6%88%91%E5%BF%83_ycccc_pocics.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(52,65),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(52,2),
                        new SongGenre(52,3),


                    }
                },

                      new Song
                {
                    Name = @"Áng mây sẽ nở hoa/会开花的云",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/anhmaysenohoa_fcwbqe.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268010/Vietsub_%C3%81ng_m%C3%A2y_s%E1%BA%BD_n%E1%BB%9F_hoa_-_Huy%E1%BB%81n_T%E1%BB%AD_ft_Di%C3%AAu_Hi%E1%BB%83u_%C4%90%C6%B0%E1%BB%9Dng_Live_--_%E4%BC%9A%E5%BC%80%E8%8A%B1%E7%9A%84%E4%BA%91_-_%E5%BC%A6%E5%AD%90_ft_%E5%A7%9A%E6%99%93%E6%A3%A0_mxmw0v.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(53,2),
                        new SongSinger(53,64),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(53,2),

                    }
                },

                       new Song
                {
                    Name = @"Vạn cốt thôi sa/万骨催沙",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267063/vancotthoisa_hmfylf.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268112/Vietsub_V%E1%BA%A1n_c%E1%BB%91t_th%C3%B4i_sa_-_%C4%90%C3%A0n_Ki%E1%BB%87n_Th%E1%BB%A9_--_%E4%B8%87%E9%AA%A8%E5%82%AC%E6%B2%99_-_%E6%AA%80%E5%81%A5%E6%AC%A1_-_R%E1%BA%A5t_nh%E1%BB%9B_r%E1%BA%A5t_nh%E1%BB%9B_anh_OST_%E5%BE%88%E6%83%B3%E5%BE%88%E6%83%B3%E4%BD%A0_sids0f.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(54,4),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(54,2),
                        new SongGenre(54,3),

                        new SongGenre(54,4),


                    }
                },

                       

                        new Song
                {
                    Name = @"Ngu Mỹ Nhân/虞美人",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/ngumynhan_yvlboa.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268006/Vietsub_--_Ngu_M%E1%BB%B9_Nh%C3%A2n_-_Winky_Thi_-_%E8%99%9E%E7%BE%8E%E4%BA%BA_-_Winky_%E8%AF%97_ftpifz.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(55,63),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(55,2),

                    }
                },

                        new Song
                {
                    Name = @"Nếu Tình yêu Đã Lãng Quên/如果爱忘了",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/neutinhyeudalangquen_gdunyd.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268120/Vietsub_Pinyin_N%E1%BA%BFu_T%C3%ACnh_y%C3%AAu_%C4%90%C3%A3_L%C3%A3ng_Qu%C3%AAn_-_U%C3%B4ng_T%C3%B4_Lang_Thi%E1%BB%87n_Y_Thu%E1%BA%A7n_-_%E5%A6%82%E6%9E%9C%E7%88%B1%E5%BF%98%E4%BA%86_-_%E6%B1%AA%E8%8B%8F%E6%B3%B7_%E5%8D%95%E4%BE%9D%E7%BA%AF_go5lff.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(56,62),
                        new SongSinger(56,33),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(56,2),

                    }
                },

                        new Song
                {
                    Name = @"Trướng thu trì/涨秋池",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/truongthutri_o5exj9.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268003/Vietsub_Pinyin_Tr%C6%B0%E1%BB%9Bng_thu_tr%C3%AC_-_Nam_T%C3%AA_Ti%E1%BB%83u_%C4%90i%E1%BB%81n_%C3%82m_Nh%E1%BA%A1c_X%C3%A3_--_%E6%B6%A8%E7%A7%8B%E6%B1%A0_-_%E5%8D%97%E6%A0%96-%E5%B0%8F%E7%94%B0%E9%9F%B3%E4%B9%90%E7%A4%BE_rjrhdr.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(57,61),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(57,2),

                    }
                },

                         

                         new Song
                {
                    Name = @"Meiyou 2",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/meiyou2_lznq83.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268144/Mashup_Meiyou_2_-_Ng%E1%BA%A3i_Th%E1%BA%A7n_%E8%89%BE%E8%BE%B0_zsin3a.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(58,60),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(58,2),

                    }
                },

                          new Song
                {
                    Name = @"Lá Thư Cách Thế/隔世信",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/lathucachthe_buaohh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268013/Vietsub_Ph%E1%BA%ADt_T%C3%BA_L%C3%A1_Th%C6%B0_C%C3%A1ch_Th%E1%BA%BF_Ng%C5%A9_S%E1%BA%AFc_Th%E1%BA%A1ch_Nam_Di%E1%BB%87p_ft._Ti%E1%BB%83u_%C3%81i_%C4%90%C3%ADch_M%E1%BB%A5_-_%E9%9A%94%E4%B8%96%E4%BF%A1_%E4%BA%94%E8%89%B2%E7%9F%B3%E5%8D%97%E8%91%89_%E5%B0%8F%E6%84%9B%E7%9A%84%E5%AA%BD_guiyvs.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(59,59),
                        new SongSinger(59,40),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(59,2),
                        new SongGenre(59,4),


                    }
                },


                           new Song
                {
                    Name = @"Tử Ức/紫亿",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/tuuc_vxadw0.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268124/Vietsub-Pinyin_T%E1%BB%AD_%E1%BB%A8c_-_Tr%C6%B0%C6%A1ng_T%E1%BB%AD_Ninh_C%E1%BB%ADu_Tr%C3%B9ng_T%E1%BB%AD_OST_%E7%B4%AB%E4%BA%BF_-_%E5%BC%A0%E7%B4%AB%E5%AE%81_%E4%B9%9D%E9%87%8D%E7%B4%ABOST_tnlo0v.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(60,58),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(60,2),
                        new SongGenre(60,3),

                        new SongGenre(60,4),


                    }
                },

                           new Song
                {
                    Name = @"Thanh Thanh Vũ/声声雨",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/thanhthanhvu_vpxaxh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268130/vietsub_-_Thanh_Thanh_V%C5%A9_-_%E5%A3%B0%E5%A3%B0%E9%9B%A8_T%C6%B0%E1%BB%9Fng_Long-Do%C3%A3n_L%E1%BB%99_Hy_-_%E5%90%9B%E4%B9%9D%E9%BE%84_Qu%C3%A2n_C%E1%BB%ADu_Linh_OST_jyzss4.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(61,56),
                        new SongSinger(61,57),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(61,2),
                        new SongGenre(61,3),


                    }
                },

                 new Song
                {
                    Name = @"Giới/界",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267060/gioi_fdyyqc.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268004/Gi%E1%BB%9Bi_Vi%C3%AAn_%C3%81_Duy_-_Tr%C6%B0%E1%BB%9Dng_Nguy%E1%BB%87t_T%E1%BA%ABn_Minh_OST_%E9%95%BF%E6%9C%88%E7%83%AC%E6%98%8E_-_%E8%A2%81%E5%A8%85%E7%BB%B4_%E7%95%8C_-Tia_Ray_-_Boundary-_La_V%C3%A2n_Hi_B%E1%BA%A1ch_L%E1%BB%99c_dxk9jh.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(62,55),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(62,2),
                        new SongGenre(62,3),


                    }
                },

                 new Song
                {
                    Name = @"Quân Cửu Linh/君九龄",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267060/quancuulinh_fvnfvp.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268134/vietsub_-_Qu%C3%A2n_C%E1%BB%ADu_Linh_-_%E5%90%9B%E4%B9%9D%E9%BE%84_%C4%90%E1%BA%B3ng_Th%E1%BA%ADp_Ma_Qu%C3%A2n_%E7%AD%89%E4%BB%80%E4%B9%88%E5%90%9B_-_%E5%90%9B%E4%B9%9D%E9%BE%84_Qu%C3%A2n_C%E1%BB%ADu_Linh_OST_oupryx.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(63,54),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(63,2),
                        new SongGenre(63,3),


                    }
                },

                  new Song
                {
                    Name = @"Diệu Bút Phù Sinh/妙笔浮生",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/dieubutphusinh_hzgbev.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268137/Vietsub_--_Di%E1%BB%87u_B%C3%BAt_Ph%C3%B9_Sinh_-_Ho%C3%A0ng_Thi_Ph%C3%B9_-_%E5%A6%99%E7%AC%94%E6%B5%AE%E7%94%9F_-_%E9%BB%84%E8%AF%97%E6%89%B6_gd2cgj.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(64,12),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(64,2),
                        new SongGenre(64,4),


                    }
                },

                  new Song
                {
                    Name = @"Bất Du/不逾",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/batdu_ufeo1z.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268135/--_Vietsub_-_B%E1%BA%A5t_Du_Di%E1%BB%87p_Huy%E1%BB%81n_Thanh_Tr%C6%B0%C6%A1ng_Vi%E1%BB%85n_-_%E4%B8%8D%E9%80%BE_-_%E5%8F%B6%E7%82%AB%E6%B8%85_%E5%BC%A0%E8%BF%9C_-_Tr%C6%B0%E1%BB%9Dng_Nguy%E1%BB%87t_T%E1%BA%ABn_Minh_OST_yio1uf.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(65,38),
                        new SongSinger(65,26),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(65,2),
                        new SongGenre(65,3),


                    }
                },

                  new Song 
                {
                    Name = @"Nguyệt Hải Ký/孽海记",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/nguyethaiky_j7qf7k.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268135/Vietsub_--_Nghi%E1%BB%87t_H%E1%BA%A3i_K%C3%AD_-_Ho%C3%A0ng_Thi_Ph%C3%B9_-_%E5%AD%BD%E6%B5%B7%E8%AE%B0_-_%E9%BB%84%E8%AF%97%E6%89%B6_znpxsa.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(66,12),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(66,2),
                        new SongGenre(66,3),
                        new SongGenre(66,4),



                    }
                },

                  new Song
                {
                    Name = @"Tư mỹ nhân/思美人",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/tumynhan_wbipyb.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268125/Vietsub_pinyin_T%C6%B0_m%E1%BB%B9_nh%C3%A2n_-_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nh_T%C6%B0_m%E1%BB%B9_nh%C3%A2n_OST_-_%E6%80%9D%E7%BE%8E%E4%BA%BA_-_%E5%BC%A0%E9%9D%93%E9%A2%96_%E6%80%9D%E7%BE%8E%E4%BA%BA_%E4%B8%BB%E9%A2%98%E6%9B%B2_mqhcpp.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(67,22),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(67,2),
                        new SongGenre(67,3),


                    }
                },

                  new Song
                {
                    Name = @"Tuyết Cơ/雪姬",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/tuyetco_edaj5b.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268010/Vietsub_--_Tuy%E1%BA%BFt_C%C6%A1_-_Ho%C3%A0ng_Thi_Ph%C3%B9_-_%E9%9B%AA%E5%A7%AC_-_%E9%BB%84%E8%AF%97%E6%89%B6_bnfes1.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(68,12),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(68,2),
                        new SongGenre(68,4),


                    }
                },

                  new Song 
                {
                    Name = @"Nguyện Như Trường Phong/愿如长风",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/nguyennhutruongphong_w94y3t.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736300109/Vietsub_PinyinNguy%E1%BB%87n_Nh%C6%B0_Tr%C6%B0%E1%BB%9Dng_Phong_B%E1%BA%A1ch_K%C3%ADnh_%C4%90%C3%ACnh_D%C4%A9_%C4%90%C3%B4ng_%E6%84%BF%E5%A6%82%E9%95%BF%E9%A3%8E_-_%E7%99%BD%E6%95%AC%E4%BA%AD_%E4%BB%A5%E5%86%AC_s5pqyq.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(69,52),
                        new SongSinger(69,53),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(69,2),
                        new SongGenre(69,3),


                    }
                },

                  new Song
                {
                    Name = @"Khinh Khinh/轻轻",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267057/khinhkhinh_dk84k5.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268134/Khinh_Khinh_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nh_-_Nh%E1%BA%A1c_phim_Tr%C6%B0%E1%BB%9Dng_Phong_%C4%90%E1%BB%99_OST_%E9%95%BF%E9%A3%8E%E6%B8%A1_%E5%BC%A0%E9%9D%93%E9%A2%96_%E8%BD%BB%E8%BD%BB_B%E1%BA%A1ch_K%C3%ADnh_%C4%90%C3%ACnh_T%E1%BB%91ng_D%E1%BA%ADt_dnvpnz.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(70,22),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(70,2),
                        new SongGenre(70,3),


                    }
                },

                  new Song
                {
                    Name = @"Là Người/是你",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267056/languoi_mwluil.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268130/L%C3%A0_Ng%C6%B0%E1%BB%9Di_Huy%E1%BB%81n_T%E1%BB%AD_L%C3%BD_M%E1%BA%ADu_-_Nh%E1%BA%A1c_phim_Tr%C6%B0%E1%BB%9Dng_Phong_%C4%90%E1%BB%99_OST_%E9%95%BF%E9%A3%8E%E6%B8%A1_%E5%BC%A6%E5%AD%90_%E6%9D%8E%E8%8C%82_%E6%98%AF%E4%BD%A0_-_B%E1%BA%A1ch_K%C3%ADnh_%C4%90%C3%ACnh_T%E1%BB%91ng_D%E1%BA%ADt_rhqrlp.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(71,2),
                        new SongSinger(71,51),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(71,2),
                        new SongGenre(71,3),


                    }
                },

                  

                  new Song
                {
                    Name = @"Sớm Chiều/朝暮",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267056/somchieu_t3f8yz.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268129/Vietsub_Pinyin_MV_S%E1%BB%9Bm_Chi%E1%BB%81u_L%C6%B0u_V%C5%A9_Ninh_-_OST_C%E1%BB%ADu_Ti%C3%AAu_H%C3%A0n_D%E1%BA%A1_No%C3%A3n_%E6%9C%9D%E6%9A%AE_-_%E5%88%98%E5%AE%87%E5%AE%81_sd1xji.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(72,35),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(72,2),
                        new SongGenre(72,3),


                    }
                },

                  new Song
                {
                    Name = @"Ngộ Huỳnh/遇龙",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267056/ngolong_wuz0mf.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268122/Vietsub_MV_Ng%E1%BB%99_Hu%E1%BB%B3nh_Ho%E1%BA%AFc_T%C3%B4n_-_Nh%E1%BA%A1c_phim_Ng%E1%BB%99_Long_OST_Miss_The_Dragon_%E9%81%87%E9%BE%99_-_%E9%81%87%E8%8C%A7_%E9%9C%8D%E5%B0%8A_qydijb.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(73,50),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(73,2),
                        new SongGenre(73,3),


                    }
                },

                  new Song
                {
                    Name = @"Tuyết Nguyệt",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/tuyetnguyet_djzwru.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268109/Vietsub_Tuy%E1%BA%BFt_Nguy%E1%BB%87t_-_V%E1%BA%A1n_Linh_L%C3%A2m_-_Thi%E1%BA%BFu_Ni%C3%AAn_Ca_H%C3%A0nh_-_Chuy%E1%BB%87n_t%C3%ACnh_L%C3%BD_H%C3%A0n_Y_-_Tri%E1%BB%87u_Ng%E1%BB%8Dc_Ch%C3%A2n_ssvrtp.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(74,49),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(74,2),
                        new SongGenre(74,3),


                    }
                },

                  new Song
                {
                    Name = @"Hồng Nhan Xưa",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/hongnhanxua_gtlbfn.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268028/Vietsub_H%E1%BB%93ng_Nhan_X%C6%B0a_-_L%C6%B0u_%C4%90%C3%A0o_xuohid.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(75,48),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(75,2),
                        new SongGenre(75,3),


                    }
                },

                   new Song
                {
                    Name = @"Pháo hoa rực rỡ trong đêm/焰火夜光",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267065/phaohoangucrotrongdem_hs17kh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736300585/Vietsub_%E7%84%B0%E7%81%AB%E5%A4%9C%E5%85%89_-_%E5%82%85%E8%9E%8D_Ph%C3%A1o_hoa_r%E1%BB%B1c_r%E1%BB%A1_trong_%C4%91%C3%AAm_-_Ph%C3%B3_Dung_s4hoh0.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(76,47),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(76,2),

                    }
                },

                  new Song
                {
                    Name = @"Tư Mộ",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/tumo_ur6mvy.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268149/Vietsub_Kara_T%C6%B0_M%E1%BB%99_-_%C3%9Ac_Kh%E1%BA%A3_Duy_OST_Tam_sinh_tam_th%E1%BA%BF_th%E1%BA%ADp_l%C3%BD_%C4%91%C3%A0o_hoa_e5wndy.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(77,46),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(77,2),
                        new SongGenre(77,3),


                    }
                },

                  new Song
                {
                    Name = @"Lạnh lẽo",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267061/lanhleo_ygf9mw.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268154/Vietsub_L%E1%BA%A1nh_l%E1%BA%BDo_-_Tr%C6%B0%C6%A1ng_B%C3%ADch_Th%E1%BA%A7n_D%C6%B0%C6%A1ng_T%C3%B4ng_V%E1%BB%B9_OST_Tam_Sinh_Tam_Th%E1%BA%BF_Th%E1%BA%ADp_L%C3%BD_%C4%90%C3%A0o_Hoa_gdw1u0.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(78,6),
                        new SongSinger(79,79),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(78,2),
                        new SongGenre(78,3),


                    }
                },

                  new Song
                {
                    Name = @"Tam Sinh Tam Thế",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267060/tamsinhtamthe_q6ylmh.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268113/Vietsub_FMV_Tam_Sinh_Tam_Th%E1%BA%BF_-_%E4%B8%89%E7%94%9F%E4%B8%89%E4%B8%96_-_Tr%C6%B0%C6%A1ng_Ki%E1%BB%87t_Ost_Tam_Sinh_Tam_Th%E1%BA%BF_Th%E1%BA%ADp_L%C3%BD_%C4%90%C3%A0o_Hoa_zagczs.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(79,31),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(79,2),
                        new SongGenre(79,3),


                    }
                },

                  new Song 
                {
                    Name = @"Ba Ngàn Thế Giới Không Gặp Được Nàng/三千世界不见你",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267060/banganthegioikogapduocnang_rwuw6z.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299887/Ba_Ng%C3%A0n_Th%E1%BA%BF_Gi%E1%BB%9Bi_Kh%C3%B4ng_G%E1%BA%B7p_%C4%90%C6%B0%E1%BB%A3c_N%C3%A0ng_-_T%E1%BB%89nh_Lung_%E4%B8%89%E5%8D%83%E4%B8%96%E7%95%8C%E4%B8%8D%E8%A7%81%E4%BD%A0-_%E4%BA%95%E8%83%A7_OST_Ninh_An_Nh%C6%B0_M%E1%BB%99ng_v9lomr.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(80,45),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(80,2),
                        new SongGenre(80,3),


                    }
                },

                  new Song
                {
                    Name = @"Sớm Chiều",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/somchieu1_r2na5p.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299730/Pinyin_Vietsub_S%E1%BB%9Bm_Chi%E1%BB%81u_-_%C4%90%C3%A0n_Ki%E1%BB%87n_Th%E1%BB%A9_%E6%9C%9D%E5%A4%95_-_%E6%AA%80%E5%81%A5%E6%AC%A1___OST_R%E1%BA%A5t_Nh%E1%BB%9B_R%E1%BA%A5t_Nh%E1%BB%9B_Anh_%E5%BE%88%E6%83%B3%E5%BE%88%E6%83%B3%E4%BD%A0_Iv62js7DAmU_bw0vq6.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(81,4),


                    },
                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(81,2),
                        new SongGenre(81,3),
                        new SongGenre(81,4),
                    }
                },

                  new Song 
                {
                    Name = @"Vân Chi Vũ/云之羽",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/vanchivu_adrxnn.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299742/Vietsub____V%C3%A2n_Chi_V%C5%A9_Tr%C6%B0%C6%A1ng_Ki%E1%BB%87t_V%C3%A2n_Chi_V%C5%A9_OST_%E4%BA%91%E4%B9%8B%E7%BE%BD_%E5%BC%A0%E6%9D%B0_%E4%BA%91%E4%B9%8B%E7%BE%BD_OST_My_Journey_To_You_OST_dkmwp5.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(82,31),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(82,2),
                        new SongGenre(82,3),


                    }
                },

                  new Song
                {
                    Name = @"Vạn vật không bằng nàng/万物不如你-张杰",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267059/vanvatkhongbangnang_meegsi.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268010/MV_Vietsub_V%E1%BA%A1n_v%E1%BA%ADt_kh%C3%B4ng_b%E1%BA%B1ng_n%C3%A0ng_%E4%B8%87%E7%89%A9%E4%B8%8D%E5%A6%82%E4%BD%A0-%E5%BC%A0%E6%9D%B0_OST_Tr%C6%B0%E1%BB%9Dng_T%C6%B0%C6%A1ng_T%C6%B0_-_-_Lost_you_forever_-_%E9%95%BF%E7%9B%B8%E6%80%9D._jboqqb.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                   SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(83,31),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(83,2),
                        new SongGenre(83,3),

                    }
                },

                 

                  new Song
                {
                    Name = @"Duyên lạc/缘落",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/duyenlac_knlpmq.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268118/Vietsub_pinyin_Duy%C3%AAn_l%E1%BA%A1c_-_L%E1%BB%A5c_H%E1%BB%95_Ch%C3%A2u_Th%C3%A2m_Nguy%E1%BB%87t_th%C6%B0%E1%BB%A3ng_tr%C3%B9ng_h%E1%BB%8Fa_OST_-_%E7%BC%98%E8%90%BD_-_%E9%99%86%E8%99%8E_%E5%91%A8%E6%B7%B1_%E6%9C%88%E4%B8%8A%E9%87%8D%E7%81%AB_%E7%89%87%E5%B0%BE%E6%9B%B2_rpjzns.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(84,24),
                        new SongSinger(84,44),


                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(84,2),
                        new SongGenre(84,3),


                    }
                },

                  new Song
                {
                    Name = @"Duyên khởi/缘起",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/duyenkhoi_qe6niu.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268115/Vietsub_pinyin_Duy%C3%AAn_kh%E1%BB%9Fi_-_Ch%C3%A2u_Th%C3%A2m_B%E1%BA%A1ch_x%C3%A0-_Duy%C3%AAn_kh%E1%BB%9Fi_OST_-_%E7%BC%98%E8%B5%B7_-_%E5%91%A8%E6%B7%B1_%E7%99%BD%E8%9B%87_%E7%BC%98%E8%B5%B7_%E6%8E%A8%E5%B9%BF%E6%9B%B2_vkv41b.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(85,24),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(85,2),

                    }
                },

                  new Song
                {
                    Name = @"Niệm Quy Khứ/念归去",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/niemquykhu_pqy0tm.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268144/Vietsub_Pinyin_MV_Ni%E1%BB%87m_Quy_Kh%E1%BB%A9_-_Ch%C3%A2u_Th%C3%A2m_-_%E5%BF%B5%E5%BD%92%E5%8E%BB_-_%E5%91%A8%E6%B7%B1_--_OST_K%C3%ADnh_Song_Th%C3%A0nh_g100as.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                   SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(86,24),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(86,2),
                        new SongGenre(86,3),


                    }
                },

                  new Song
                {
                    Name = @"Chạm Khắc/镌刻",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736298901/chamkhac_livay8.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299073/Vietsub_Pinyin_Ch%E1%BA%A1m_Kh%E1%BA%AFc_-_Tr%C6%B0%C6%A1ng_B%C3%ADch_Th%E1%BA%A7n_%E9%95%8C%E5%88%BB_-_%E5%BC%A0%E7%A2%A7%E6%99%A8_H%E1%BB%99c_Ch%C3%A2u_Phu_Nh%C3%A2n_OST_imsxep.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(87,6),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(87,2),
                        new SongGenre(87,3),


                    }
                },

                  new Song
                {
                    Name = @"Ngàn Năm/千年",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736298901/ngannam_ciemat.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299266/VietsubPinyin_Ng%C3%A0n_N%C4%83m_-_Kim_Ch%C3%AD_V%C4%83n_C%C3%A1t_Kh%E1%BA%AFc_Tuy%E1%BB%83n_D%E1%BA%ADt_%E5%8D%83%E5%B9%B4_-_%E9%87%91%E5%BF%97%E6%96%87_%E5%90%89%E5%85%8B%E9%9A%BD%E9%80%B8_%E5%A4%A9%E4%B9%A9%E4%B9%8B%E7%99%BD%E8%9B%87%E4%BC%A0%E8%AF%B4_gfomz4.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(88,42),
                        new SongSinger(88,43),
                        
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(88,2),
                        new SongGenre(88,3),
                    }
                },

                  new Song
                {
                    Name = @"Thịnh thế chi cương",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736298901/thinhthechicuong_jiphlw.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299077/Vietsub_Th%E1%BB%8Bnh_th%E1%BA%BF_chi_c%C6%B0%C6%A1ng-Huy%E1%BB%81n_T%E1%BB%AD_L%C3%A3o_Can_Ma_HITA_Ti%E1%BB%83u_%C3%81i_%C4%90%C3%ADch_M%E1%BB%A5_Ti%C3%AAu_%E1%BB%A8c_T%C3%ACnh_Li%E1%BB%87t_Thi%C3%AAn_dc5lws.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(89,2),
                        new SongSinger(89,3),
                        new SongSinger(89,39),
                        new SongSinger(89,40),
                        new SongSinger(89,1),
                        new SongSinger(89,41),
                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(89,2),
                        new SongGenre(89,3),
                        new SongGenre(89,4),


                    }
                },

                  new Song 
                {
                    Name = @"Yêu Trong Thầm Lặng/爱若无声",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267057/yeutrongthamlang_wrqdsq.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299531/Vietsub_Pinyin_Y%C3%AAu_Trong_Th%E1%BA%A7m_L%E1%BA%B7ng_-_Mao_B%E1%BA%A5t_D%E1%BB%8Bch_%E7%88%B1%E8%8B%A5%E6%97%A0%E5%A3%B0_-_%E6%AF%9B%E4%B8%8D%E6%98%93_OST_K%C3%ADnh_Song_Th%C3%A0nh_y3beh9.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(90,5),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(90,2),
                        new SongGenre(90,3),


                    }
                },

                  

                  new Song
                {
                    Name = @"Cơn Gió Giống Như Ta/風一樣的我",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267057/tanhucongio_yhrqrl.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268148/Vietsub_C%C6%A1n_Gi%C3%B3_Gi%E1%BB%91ng_Nh%C6%B0_Ta_%E9%A2%A8%E4%B8%80%E6%A8%A3%E7%9A%84%E6%88%91_-_Di%E1%BB%87p_Huy%E1%BB%81n_Thanh_-_Song_Th%E1%BA%BF_S%E1%BB%A7ng_Phi_OST_kpteoj.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(91,38),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(91,2),
                        new SongGenre(91,3),


                    }
                },

                  new Song
                {
                    Name = @"Bức họa vô tình/无情画",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267057/buchoavotinh_sla4fr.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268110/Vietsub_Pinyin_B%E1%BB%A9c_h%E1%BB%8Da_v%C3%B4_t%C3%ACnh_-_V%C6%B0%C6%A1ng_Tr%C3%ACnh_Ch%C6%B0%C6%A1ng_-_%E6%97%A0%E6%83%85%E7%94%BB_-_%E7%8E%8B%E5%91%88%E7%AB%A0_-_OST_Song_th%E1%BA%BF_s%E1%BB%A7ng_phi_2_%E5%8F%8C%E4%B8%96%E5%AE%A0%E5%A6%83_ybscic.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(92,37),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(92,2),
                        new SongGenre(92,3),


                    }
                },


                  new Song
                {
                    Name = @"Thanh mai dẫn/青梅引",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736298901/thanhmaidan_ie0one.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736299075/Vietsub_Thanh_mai_d%E1%BA%ABn_-_Th%C3%AC_Th%C6%B0%E1%BB%A3ng_%E9%9D%92%E6%A2%85%E5%BC%95_-_%E6%97%B6%E5%B0%9A_-_R%E1%BA%A5t_nh%E1%BB%9B_r%E1%BA%A5t_nh%E1%BB%9B_anh_OST_%E5%BE%88%E6%83%B3%E5%BE%88%E6%83%B3%E4%BD%A0_fozwad.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(93,4),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(93,2),
                        new SongGenre(93,3),
                        new SongGenre(93,4),


                    }
                },

                  new Song
                {
                    Name = @"Mộng Hoa/梦华",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267057/monghoa_pyihvl.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268018/Vietsub_Pinyin_M%E1%BB%99ng_Hoa_-_L%C6%B0u_V%C5%A9_Ninh_-_%E6%A2%A6%E5%8D%8E_-_%E5%88%98%E5%AE%87%E5%AE%81_-_A_Dream_of_Splendor_M%E1%BB%99ng_Hoa_L%E1%BB%A5c_%E6%A2%A6%E5%8D%8E%E5%BD%95_OST_h54oid.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                   SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(94,35),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(94,2),
                        new SongGenre(94,3),
                    }
                },

                  new Song
                {
                    Name = @"Như Ca/如歌",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267058/nhuca_o5cnhd.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736267244/VietsubH%C3%A1n_Vi%E1%BB%87t_Nh%C6%B0_Ca_-_%E5%A6%82%E6%AD%8C_ll_Tr%C6%B0%C6%A1ng_Ki%E1%BB%87t_-_%E5%BC%A0%E6%9D%B0_Li%E1%BB%87t_H%E1%BB%8Fa_Nh%C6%B0_Ca_OST_fhm3d6.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(95,31),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(95,2),
                        new SongGenre(95,3),
                    }
                },

                  new Song
                {
                    Name = @"Nại Hà Nại Hà",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267066/naihanaiha_x3j0ea.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268135/vietsub_-_N%E1%BA%A1i_H%C3%A0_N%E1%BA%A1i_H%C3%A0_-_%E5%A5%88%E4%BD%95%E5%A5%88%E4%BD%95_Ho%C3%A0ng_Ti%C3%AAu_V%C3%A2n_%E9%BB%84%E9%9C%84%E9%9B%B2_-_Lu%E1%BA%ADn_Anh_H%C3%B9ng_Ai_X%E1%BB%A9ng_Anh_H%C3%B9ng_OST_nul1up.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(96,34),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(96,2),
                        new SongGenre(96,3),
                    }
                },

                  new Song
                {
                    Name = @"Nhất sinh nhất niệm/一生一念",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/nhatsinhnhatniem_sgcdku.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268105/Vietsub_Nh%E1%BA%A5t_sinh_nh%E1%BA%A5t_ni%E1%BB%87m_-_Thi%E1%BB%87n_Y_Thu%E1%BA%A7n_OST_K%E1%BB%B3_Kim_Tri%C3%AAu_-_%E4%B8%80%E7%94%9F%E4%B8%80%E5%BF%B5_-_%E5%8D%95%E4%BE%9D%E7%BA%AF_OST_%E7%A5%88%E4%BB%8A%E6%9C%9D_suslcs.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(97,33),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(97,2),
                        new SongGenre(97,3),
                    }
                },

                   new Song
                {
                    Name = @"Không tiếc thời gian/不惜时光",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267060/khongtiecthoigian_j71ct9.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268118/Vietsub_pinyin_Kh%C3%B4ng_ti%E1%BA%BFc_th%E1%BB%9Di_gian_-_Tr%C6%B0%C6%A1ng_L%C6%B0%C6%A1ng_D%C4%A9nh_M%E1%BB%99ng_hoa_l%E1%BB%A5c_OST_-_%E4%B8%8D%E6%83%9C%E6%97%B6%E5%85%89_-_%E5%BC%A0%E9%9D%93%E9%A2%96_%E6%A2%A6%E5%8D%8E%E5%BD%95_%E4%B8%BB%E9%A2%98%E6%9B%B2_zzmnvy.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(98,22),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(98,2),
                        new SongGenre(98,3),

                    }
                },

                   new Song
                {
                    Name = @"Gió Thổi Khi Nhớ Anh/想你时风起",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267066/giothoikhiemnhoanh_hn0k6o.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736300405/%E6%83%B3%E4%BD%A0%E6%97%B6%E9%A3%8E%E8%B5%B7_%E7%94%B5%E8%A7%86%E5%89%A7%E6%88%91%E7%9A%84%E4%BA%BA%E9%97%B4%E7%83%9F%E7%81%AB%E5%9B%9E%E5%BF%86%E4%B8%BB%E9%A2%98%E6%9B%B2_lt9g9u.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(99,33),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(99,2),
                        new SongGenre(99,3),
                    }
                },

                 

                  new Song
                {
                    Name = @"Hy Phong Tấu/曦风奏",
                    ImgUrl = @"https://res.cloudinary.com/dh1zsowbp/image/upload/v1736267062/hyphongtau_mih0mi.jpg",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1736268151/Vietsub_Hy_Phong_T%E1%BA%A5u_-_L%C3%BD_Ti%C3%AAu_Minh_-_Nh%E1%BA%A1c_ch%E1%BB%A7_%C4%91%E1%BB%81_skin_Valentine_2024_VGVD_--_%E6%9B%A6%E9%A3%8E%E5%A5%8F_-_%E6%9B%A6%E7%8E%84%E5%BC%95%E6%83%85%E6%84%9F%E4%B8%BB%E9%A2%98%E6%9B%B2_2_nvnwi8.mp3",
                    Introduction = @"Tạm chưa có",
                    Lyric = @"Tạm chưa có",
                    SongSingers = new List<SongSinger>
                    {
                        // song, singer
                        new SongSinger(100,32),

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(100,2),
                        new SongGenre(100,4),
                    }
                },

            };
            context.Songs.AddRange(songs);
            await context.SaveChangesAsync();

        }
    }
}
