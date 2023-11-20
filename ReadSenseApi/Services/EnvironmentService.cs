using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public class EnvironmentService: IEnvironmentService
    {
        private readonly ReadSenseDBContext context;

        public EnvironmentService(ReadSenseDBContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Get all Environments
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Environment insert method
        /// </summary>
        /// <param name="environmentRequest"></param>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
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

        public int? GetUserDeviceLatestEnvironmentId(int userId, int deviceId)
        {
            return context.Environments.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId)?.Id;
        }
    }
}
