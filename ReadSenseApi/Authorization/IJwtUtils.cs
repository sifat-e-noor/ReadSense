using ReadSenseApi.Database.Entities;
using System.Security.Claims;

namespace ReadSenseApi.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user, int deviceId);
        public IEnumerable<Claim>? ValidateJwtToken(string? token);
    }
}
