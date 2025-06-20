using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using Music.Core.Validations;

namespace Music.Core.DTOs.Songs
{
    public class SongUpdateDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên bài hát")]
        public required string Name { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public IFormFile? ImgFile { get; set; } = null;

        [AllowedExtensions(new string[] { ".mp3", ".m4a" })]
        [MaxFileResolution(10, ErrorMessage = "Kích thước file nhạc tối đa là 10 MB.")]
        public IFormFile? SongFile { get; set; } = null;

        [Required(ErrorMessage = "Vui lòng nhập thông tin bài hát")]
        public required string Introduction { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lyric")]
        public required string Lyric { get; set; }

        [NotEmptyList(ErrorMessage = "Danh sách thể loại của bài hát không được rỗng")]
        public List<int> GenreList { get; set; } = [];

        [NotEmptyList(ErrorMessage = "Danh sách ca sĩ của bài hát không được rỗng")]
        public List<int> SingerList { get; set; } = [];
    }
}
