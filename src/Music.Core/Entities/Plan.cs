using Music.Core.Entities.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.Entities
{
    public class Plan : EntityAuditBase<int>
    {
        [Required(ErrorMessage = "Tên gói đăng ký không được trống")]
        public string Name { get; set; } = string.Empty;
        [Range(1, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0")]
        public decimal Price { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = "Giá bán sau khi giảm phải lớn hơn 0")]
        public decimal PriceSell { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Thời gian phải lớn hơn 0")]
        public int DurationDay { get; set; }
        [Required(ErrorMessage = "Mô tả gói đăng ký không được trống")]
        public string Description { get; set; } = string.Empty;
        public bool IsDelete { get; set; } = false;
    }
}
