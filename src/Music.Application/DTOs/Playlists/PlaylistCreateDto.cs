using Music.Domain.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Music.Application.DTOs.Playlists
{
    public class PlaylistCreateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên danh sách phát")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh cho danh sách phát")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public required IFormFile ImgFile { get; set; }
        public List<int> SongList { get; set; } = [];
        public bool IsPublic { get; set; } = false;
        public string UserId { get; set; } = string.Empty;
    }
}
