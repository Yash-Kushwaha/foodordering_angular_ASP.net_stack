namespace UsersMicroservice.Service
{
    public interface ITokenGenerator
    {
        string GenerateJWTToken(string name, string role);
    }
}
