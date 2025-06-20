using Music.Domain.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Music.Application.DTOs.Songs
{
    public class SongCreateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập tên bài hát")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Ảnh bài hát không được thiếu")]
        [AllowedExtensions(new string[] { ".jpg", ".png", ".jpeg", ".webp" })]
        [MaxFileResolution(1, ErrorMessage = "Kích thước file ảnh tối đa là 1 MB.")]
        public required IFormFile ImgFile { get; set; }

        [Required(ErrorMessage = "File nhạc không được thiếu")]
        [AllowedExtensions(new string[] { ".mp3", ".m4a" })]
        [MaxFileResolution(10, ErrorMessage = "Kích thước file nhạc tối đa là 10 MB.")]
        public required IFormFile SongFile { get; set; }

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
