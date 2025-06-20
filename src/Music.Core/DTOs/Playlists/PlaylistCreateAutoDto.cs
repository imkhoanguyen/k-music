using Microsoft.AspNetCore.Http;
using Music.Core.Validations;
using System.ComponentModel.DataAnnotations;

namespace Music.Core.DTOs.Playlists
{
    public class PlaylistCreateAutoDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên danh sách phát")]
        public required string Name { get; set; }
        public List<int> SelectedGenres { get; set; } = [];
        public List<int> SelectedSingers { get; set; } = [];
        public int Count { get; set; } = 0;
        public bool IsPublic { get; set; } = false;
        [Required(ErrorMessage = "Vui lòng chọn hình ảnh cho danh sách phát")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public required IFormFile ImgFile { get; set; }
        public string UserId { get; set; } = "";

    }
}
