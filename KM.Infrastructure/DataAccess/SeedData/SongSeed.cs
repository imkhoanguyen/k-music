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
                    ImgUrl = @"https://lh3.googleusercontent.com/KCciJNg2RgXj5hbvTrSwT20VODWrtnmve0F-GfgmCU2fqX9Dk1NRhOxzCRP8-mZ7hd6jWqmJCpD3dq8",
                    SongUrl = @"https://res.cloudinary.com/dh1zsowbp/video/upload/v1726070879/Vietsub_Pinyin_Danh_S%C4%A9_Kh%C3%BAc_T%E1%BB%A9_Th%E1%BB%A7%E5%90%8D%E5%A3%AB%E6%9B%B2%E5%9B%9B%E9%A6%96_OST_DramaR%E1%BA%A5t_Nh%E1%BB%9B_R%E1%BA%A5t_Nh%E1%BB%9B_Anh_%E5%BE%88%E6%83%B3%E5%BE%88%E6%83%B3%E4%BD%A0_xraf0k.mp3",
                    Introduction = @"Tác từ: Minh Hoàng, Nam Kỳ (冥凰/南岐)
Tác khúc: Hạo Vận (皓韻)
Biên khúc: Thất Và Huyền Của Sao Đêm, Trần Thuấn Vũ, Chu Kim Thái, Vương Nguyên Chiêu (星夜的七和弦/陈舜禹/朱金泰/王元昭)
Nhạc phim: Rất nhớ rất nhớ anh".Trim(),
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

裂天：
北城萧瑟 天涯回望路漫漫
烽火燎原 朔风吹不断
壮士百战无人还 旌旗半卷已出关
魂似孤雁 盘旋天际远 无限山河宽
多少英雄赴关山 相间恨太晚
挥兵破阵策马挽弓 射落月一弯
这江山 千钧我 来担

弦子：
悠悠千百年 弹指一挥间
兴衰变迁 繁华皆如烟
英雄豪杰 昙花一现
俯瞰人间 有谁知苍生 最可怜

纵是千般锦绣 万般风流 都化乌有
此生 一腔浩气仍依旧
纵是残破九州 干戈不休 无人来救
我愿 舍去红妆着甲胄 苍茫天地任去留

李常超：
这边关北风卷起 千古的狂澜
残月照遍 胜王败寇浴血的城关
烽火下世事变迁 等峰回路转
策马待战 杀意被我一念看穿
篝火烈烈 点燃一把狼烟的时间
英雄作别 风云只待阵前相见
笑当年黄沙如雪 是我在提着剑
一腔热血 泼洒向埋骨人间

相识相别 一梦多少年
人世变迁 英雄不复见

檀健次：
北望河川望不穿 溪水漫漫
从云浩荡来 送我上霄汉
千里行舟渡重山 风催雨寒
此生辗转难时见 肝胆

北望河川残阳处 无限江山
朔风过重关 当不辞一战
日月浩瀚 作棋盘 落子明断
古今峥嵘岁月滚滚来
古今峥嵘岁月滚 滚 来

旁白：
史臣笔墨 记我此生杀戮 可余少许
让我殿内灯下画你容颜 如始 如初".Trim(),

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
            };
            context.Songs.AddRange(songs);
            await context.SaveChangesAsync();

        }
    }
}
