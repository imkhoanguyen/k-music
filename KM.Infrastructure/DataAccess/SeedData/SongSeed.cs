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

                    },

                    SongGenres = new List<SongGenre>
                    {
                        // song, genre
                        new SongGenre(11,2),
                        new SongGenre(11,3),
                        new SongGenre(11,4),
                    }
                },
            };
            context.Songs.AddRange(songs);
            await context.SaveChangesAsync();

        }
    }
}
