﻿namespace Music.Core.DTOs.Comments
{
    public class CommentUpdateDto
    {
        public int Id { get; set; }
        public required string Content { get; set; }
    }
}
