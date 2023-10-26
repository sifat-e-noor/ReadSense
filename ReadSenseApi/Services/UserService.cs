using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Authorization;
using ReadSenseApi.Database;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;
using System.Text.Json.Nodes;

namespace ReadSenseApi.Services
{
    public class UserService : IUserService
    {
        private readonly ReadSenseDBContext _context;

        private readonly IJwtUtils _jwtUtils;

        public UserService(ReadSenseDBContext readSenseDBContext, IJwtUtils jwtUtils)
        {
            _context = readSenseDBContext;
            _jwtUtils = jwtUtils;
        }

        public AuthenticateResponse? Authenticate(AuthenticateRequest model)
        {
            var user = _context.Users.SingleOrDefault(x => !string.IsNullOrEmpty(model.Username) 
                && model.Username.ToLower().Equals(x.Username) 
                && x.Password == model.Password);

            // If user does not exist, create a new User
            if (user == null) 
            { 
               user = new User
               {
                   Username = model.Username?.ToLower(),
                   Password = model.Password
               };
               
               _context.Users.Add(user);
               _context.SaveChanges();
            }

            var device = addDeviceInfo(user, model.DeviceInfo);

            // authentication successful so generate jwt token
            var token = _jwtUtils.GenerateJwtToken(user, device.Id);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users.IsNullOrEmpty() ? new List<User>() : _context.Users;
        }

        public User? GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        private Device addDeviceInfo(User user, JsonNode? deviceInfo)
        {
            var device = new Device();

            device.DeviceInfo = deviceInfo?.ToString();
            device.UserId = user.Id;

            _context.Devices.Add(device);
            _context.SaveChanges();

            return device;
        }
    }
}
