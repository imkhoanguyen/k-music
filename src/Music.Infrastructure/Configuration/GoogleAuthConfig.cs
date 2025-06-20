namespace Music.Infrastructure.Configuration
{
    public class GoogleAuthConfig
    {
        public static string ConfigName = "GoogleAuthSettings";
        public string ClientId { get; set; } = string.Empty;
    }
}
