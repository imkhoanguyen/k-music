using KM.Application.DTOs.Auth;

namespace KM.Infrastructure.Abstract
{
    public interface IEmailService
    {
        Task SendMailAsync(CancellationToken cancellationToken, EmailRequest emailRequest);
    }
}