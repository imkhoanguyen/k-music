using KM.Domain.Entities;

namespace API.Service.Abstract
{
    public interface ITokenService
    {
        public Task<string> CreateTokenAsync(AppUser user);
    }
}
