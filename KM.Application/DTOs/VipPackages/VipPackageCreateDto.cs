using System.ComponentModel.DataAnnotations;

namespace KM.Application.DTOs.VipPackages
{
    public class VipPackageCreateDto
    {
        [Required(ErrorMessage = "Tên gói đăng ký không được trống")]
        public required string Name { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0")]
        public decimal Price { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Giá sau khi giảm phải lớn hơn 0")]
        public decimal PriceSell { get; set; }
        public int DurationDay { get; set; }
        [Required(ErrorMessage = "Mô tả gói đăng ký không được trống")]
        public required string Description { get; set; }
    }
}
