using System.ComponentModel.DataAnnotations;

namespace KM.Application.DTOs.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "UserName không được trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "UserName phải lớn hơn 4 ký tự và bé hơn 50 ký tự")]
        public required string UserName { get; set; }
        [Required(ErrorMessage ="Email không được trống")]
        [RegularExpression("^\\w+@[a-zA-Z_]+?\\.[a-zA-Z]{2,3}$", ErrorMessage ="Không đúng định dạng email")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Password không được trống")]
        [StringLength(23, MinimumLength = 5, ErrorMessage = "Password phải lớn hơn 4 ký tự và bé hơn 24 ký tự")]
        public required string Password { get; set; }
        public required string Gender { get; set; }
        [Required(ErrorMessage = "UserName không được trống")]
        [StringLength(100, ErrorMessage = "FullName không được quá 100 ký tự")]
        public required string FullName { get; set; }
    }
}
