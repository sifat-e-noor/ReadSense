using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public class EnvironmentService : IEnvironmentService
    {
        private readonly ReadSenseDBContext _context;

        public EnvironmentService(ReadSenseDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Database.Entities.Environment> GetAll()
        {
            return _context.Environments.IsNullOrEmpty() ? new List<Database.Entities.Environment>() : _context.Environments;
        }

        public Database.Entities.Environment? GetById(int id)
        {
            return _context.Environments.FirstOrDefault(x => x.Id == id);
        }

        public Database.Entities.Environment? GetByUserId(int userId)
        {
            return _context.Environments.FirstOrDefault(x => x.UserId == userId);
        }

        public Database.Entities.Environment? GetByDeviceId(int deviceId)
        {
            return _context.Environments.FirstOrDefault(x => x.DeviceId == deviceId);
        }

        public Database.Entities.Environment? GetByDeviceIdAndUserId(int deviceId, int userId)
        {
            return _context.Environments.OrderByDescending(x => x.Id).FirstOrDefault(x => x.DeviceId == deviceId && x.UserId == userId);
        }

        // Environment insert method
        public Database.Entities.Environment? Insert(EnvironmentRequest environmentRequest, int userId, int deviceId)
        {
            var environment = new Database.Entities.Environment
            {
                UserId = userId,
                DeviceId = deviceId,
                PlaceState = environmentRequest.PlaceState,
                TimeOfDay = environmentRequest.TimeOfDay,
                BrightnessLevel = environmentRequest.BrightnessLevel,
                Inserted = DateTime.Now.ToUniversalTime(),
            };

            _context.Environments.Add(environment);
            _context.SaveChanges();

            return environment;
        }
    }
}
