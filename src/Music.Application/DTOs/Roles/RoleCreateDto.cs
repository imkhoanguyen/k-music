﻿using System.ComponentModel.DataAnnotations;

namespace Music.Application.DTOs.Roles
{
    public class RoleCreateDto
    {
        [Required(ErrorMessage = "Tên quyền không được trống")]
        public required string Name { get; set; }
        [Required(ErrorMessage = "Mô tả không được trống")]
        public required string Description { get; set; }
    }
}
