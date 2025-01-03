﻿using KM.Domain.Enum;
using Microsoft.AspNetCore.Http;

namespace KM.Application.DTOs.Singers
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
