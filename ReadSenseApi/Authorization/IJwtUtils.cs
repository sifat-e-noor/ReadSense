using ReadSenseApi.Database.Entities;

namespace ReadSenseApi.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string? token);
    }
}
