using System.ComponentModel.DataAnnotations;

namespace Music.Core.DTOs.Genres
{
    public class GenreCreateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập thể loại")]
        [MinLength(1, ErrorMessage = "Tên thể loại không được để trống")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        [MinLength(1, ErrorMessage = "Tên thể loại không được để trống")]
        public required string Description { get; set; }

    }
}
