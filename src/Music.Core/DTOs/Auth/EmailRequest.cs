namespace Music.Core.DTOs.Auth
{
    public class EmailRequest
    {
        public required string To { get; set; }
        public required string Subject { get; set; }
        public required string Content { get; set; }
    }
}
