using System.ComponentModel.DataAnnotations;

namespace Music.Core.DTOs.Users
{
    public class UpdateUserRoleDto
    {
        [Required(ErrorMessage ="Bạn chưa chọn quyền")]
        public required string Role { get; set; }
    }
}
