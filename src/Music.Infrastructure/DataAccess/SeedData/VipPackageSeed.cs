using KM.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KM.Infrastructure.DataAccess.SeedData
{
    public class VipPackageSeed
    {
        public static async Task SeedAsync(MusicContext context)
        {
            if (context.VipPackages.Any())
                return;

            var vipPackageList = new List<VipPackage>()
            {
                new VipPackage ()
                {
                    Name = "Gói vip 30 ngày",
                    Description = @"- Nghe nhạc không giới hạn trong 30 ngày
- Ngân hàng: NCB
- Số thẻ: 9704198526191432198
- Tên chủ thẻ: NGUYEN VAN A
- Ngày phát hành: 07/15
- Mật khẩu OTP: 123456",
                    Price = 100000,
                    PriceSell = 50000,
                    DurationDay = 30,
                },

                new VipPackage ()
                {
                    Name = "Gói vip 90 ngày",
                    Description = @"- Nghe nhạc không giới hạn trong 90 ngày
- Ngân hàng: NCB
- Số thẻ: 9704198526191432198
- Tên chủ thẻ: NGUYEN VAN A
- Ngày phát hành: 07/15
- Mật khẩu OTP: 123456",
                    Price = 300000,
                    PriceSell = 120000,
                    DurationDay = 90,
                },

                new VipPackage ()
                {
                    Name = "Gói vip 365 ngày",
                    Description = @"- Nghe nhạc không giới hạn trong 365 ngày
- Ngân hàng: NCB
- Số thẻ: 9704198526191432198
- Tên chủ thẻ: NGUYEN VAN A
- Ngày phát hành: 07/15
- Mật khẩu OTP: 123456",
                    Price = 500000,
                    PriceSell = 200000,
                    DurationDay = 365,
                }
            };

            context.VipPackages.AddRange(vipPackageList);
            await context.SaveChangesAsync();
        }
    }
}
