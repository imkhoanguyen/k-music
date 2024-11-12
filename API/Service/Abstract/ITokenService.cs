using KM.Domain.Entities;

namespace API.Service.Abstract
{
    public interface ITokenService
    {
        public string CreateToken(AppUser user);
    }
}
