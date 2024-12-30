using KM.Domain.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KM.Application.DTOs.Users
{
    public class UserUpdateDto
    {
        [Required(ErrorMessage = "UserName không được trống")]
        [StringLength(23, MinimumLength = 5, ErrorMessage = "UserName phải lớn hơn 4 ký tự và bé hơn 24 ký tự")]
        public required string UserName { get; set; }
        [Required(ErrorMessage = "Email không được trống")]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage = "Không đúng định dạng email")]
        public required string Email { get; set; }
        public required string Gender { get; set; }
        [Required(ErrorMessage = "FullName không được trống")]
        [StringLength(100, ErrorMessage = "FullName không được quá 100 ký tự")]
        public required string FullName { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public IFormFile? ImgFile { get; set; }
    }
}
