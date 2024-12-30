using KM.Domain.Enum;

namespace KM.Application.DTOs.Users
{
    public class UserDto
    {
        public required string FullName { get; set; }
        public required string Gender { get; set; }
        public required string ImgUrl { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public required string UserName { get; set; }
        public bool IsLooked { get; set; } = false;
        public required string Role { get; set; }
        public required string Email { get; set; }
    }
}
