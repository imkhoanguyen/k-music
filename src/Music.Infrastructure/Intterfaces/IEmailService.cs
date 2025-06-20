using Music.Core.DTOs.Auth;

namespace Music.Infrastructure.Intterfaces
{
    public interface IEmailService
    {
        Task SendMailAsync(CancellationToken cancellationToken, EmailRequest emailRequest);
    }
}