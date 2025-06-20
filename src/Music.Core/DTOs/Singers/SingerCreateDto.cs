using Microsoft.AspNetCore.Http;
using Music.Core.Enum;

namespace Music.Core.DTOs.Singers
{
    public class SingerCreateDto
    {
        public required string Name { get; set; }
        public Gender Gender { get; set; }
        public required string Introduction { get; set; }
        public required string Location { get; set; }
        public required IFormFile ImgFile { get; set; }
    }
}
