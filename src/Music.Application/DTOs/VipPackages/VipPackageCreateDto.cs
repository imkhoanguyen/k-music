using System.ComponentModel.DataAnnotations;

namespace Music.Application.DTOs.VipPackages
{
    public class VipPackageCreateDto
    {
        [Required(ErrorMessage = "Tên gói đăng ký không được trống")]
        public required string Name { get; set; }
        [Range(10000, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 10000 (10.000VND)")]
        public decimal Price { get; set; }
        [Range(10000, double.MaxValue, ErrorMessage = "Giá bán sau khi giảm phải lớn hơn 10000 (10.000VND)")]
        public decimal PriceSell { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Thời gian phải lớn hơn 0")]
        public int DurationDay { get; set; }
        [Required(ErrorMessage = "Mô tả gói đăng ký không được trống")]
        public required string Description { get; set; }
    }
}
