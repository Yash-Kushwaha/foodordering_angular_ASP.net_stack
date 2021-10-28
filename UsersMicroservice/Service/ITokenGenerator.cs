using UsersMicroservice.Models;

namespace UsersMicroservice.Service
{
    public interface ITokenGenerator
    {
        string GenerateJWTToken(User user);
    }
}
