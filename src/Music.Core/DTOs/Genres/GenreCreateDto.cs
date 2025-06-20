using System.ComponentModel.DataAnnotations;

namespace Music.Core.DTOs.Genres
{
    public class GenreCreateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập thể loại")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public required string Description { get; set; }

    }
}
