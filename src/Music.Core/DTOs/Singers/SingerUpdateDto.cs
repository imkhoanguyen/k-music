﻿using Microsoft.AspNetCore.Http;
using Music.Core.Enum;

namespace Music.Core.DTOs.Singers
{
    public class SingerUpdateDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public Gender Gender { get; set; }
        public required string Introduction { get; set; }
        public required string Location { get; set; }
        public IFormFile? ImgFile { get; set; }
    }
}
