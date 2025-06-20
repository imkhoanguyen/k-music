using System.ComponentModel.DataAnnotations;

namespace Music.Core.DTOs.Auth
{
    public class ResetPasswordDto
    {
        public required string Email { get; set; }
        public required string Token { get; set; }
        public required string Password { get; set; }
    }
}
