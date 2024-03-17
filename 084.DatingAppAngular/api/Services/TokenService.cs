using api.Entities;

namespace api.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
    public class TokenService : ITokenService
    {
        public TokenService()
        {
            
        }
        public string CreateToken(AppUser user)
        {
            string token = "";

            return token;
        }
    }

}
