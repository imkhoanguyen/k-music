using KM.Domain.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace KM.Application.DTOs.Playlists
{
    public class PlaylistUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên danh sách phát")]
        public required string Name { get; set; }
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public IFormFile? ImgFile { get; set; } = null;
        public bool IsPublic { get; set; } = false;
    }
}
