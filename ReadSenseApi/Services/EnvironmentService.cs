using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public class EnvironmentService(ReadSenseDBContext context) : IEnvironmentService
    {
        public IEnumerable<Database.Entities.Environment> GetAll()
        {
            return context.Environments.IsNullOrEmpty() ? new List<Database.Entities.Environment>() : context.Environments;
        }

        public Database.Entities.Environment? GetById(int id)
        {
            return context.Environments.FirstOrDefault(x => x.Id == id);
        }

        public Database.Entities.Environment? GetByUserId(int userId)
        {
            return context.Environments.FirstOrDefault(x => x.UserId == userId);
        }

        public Database.Entities.Environment? GetByDeviceId(int deviceId)
        {
            return context.Environments.FirstOrDefault(x => x.DeviceId == deviceId);
        }

        public Database.Entities.Environment? GetByDeviceIdAndUserId(int deviceId, int userId)
        {
            return context.Environments.OrderByDescending(x => x.Id).FirstOrDefault(x => x.DeviceId == deviceId && x.UserId == userId);
        }

        // Environment insert method
        public Database.Entities.Environment? Insert(EnvironmentRequest environmentRequest, int userId, int deviceId)
        {
            var environment = new Database.Entities.Environment
            {
                UserId = userId,
                DeviceId = deviceId,
                PlaceState = environmentRequest.PlaceState,
                Location = environmentRequest.Location,
                BrightnessLevel = environmentRequest.BrightnessLevel,
                Inserted = DateTime.Now.ToUniversalTime(),
            };

            context.Environments.Add(environment);
            context.SaveChanges();

            return environment;
        }
    }
}
