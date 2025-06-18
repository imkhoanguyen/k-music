using System.ComponentModel.DataAnnotations;

namespace KM.Application.DTOs.Genres
{
    public class GenreCreateDto
    {
        [Required(ErrorMessage = "Vui lòng nhập thể loại")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mô tả")]
        public string? Description { get; set; }

    }
}
