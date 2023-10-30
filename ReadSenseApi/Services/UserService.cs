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
                && model.Username.ToLower().Equals(x.Username));

            // If user does not exist, create a new User
            if (user == null) 
            { 
               user = new User
               {
                   Username = model.Username?.ToLower(),
                   Inserted = DateTime.Now.ToUniversalTime(),
               };
               
               _context.Users.Add(user);
               _context.SaveChanges();
            }

            var device = addDeviceInfo(user,model.FingerPrint, model.DeviceInfo);

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

        public void UpdateAgreementSigned(User user, bool agreementSigned)
        {
            user.AgreementSigned = agreementSigned;
            user.LastUpdated = DateTime.Now.ToUniversalTime();

            _context.Users.Update(user);
            _context.SaveChanges();
        }

        private Device addDeviceInfo(User user, String? fingerPrint, JsonNode? deviceInfo)
        {
            var device = _context.Devices.FirstOrDefault(x => x.UserId == user.Id && x.FingerPrint == fingerPrint);

            if (fingerPrint != null &&  device != null)
            {
                return device;
            }
            
            device = new Device();

            device.DeviceInfo = deviceInfo?.ToString();
            device.UserId = user.Id;
            device.FingerPrint = fingerPrint;
            device.Inserted = DateTime.Now.ToUniversalTime();

            _context.Devices.Add(device);
            _context.SaveChanges();

            return device;
        }
    }
}
