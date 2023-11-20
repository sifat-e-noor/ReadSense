using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEnvironmentService
    {
        /// <summary>
        /// Get all Environments
        /// </summary>
        /// <returns></returns>
        IEnumerable<Database.Entities.Environment> GetAll();
        Database.Entities.Environment? GetById(int id);
        Database.Entities.Environment? GetByUserId(int userId);
        Database.Entities.Environment? GetByDeviceId(int deviceId);
        Database.Entities.Environment? GetByDeviceIdAndUserId(int deviceId, int userId);
        Database.Entities.Environment? Insert(EnvironmentRequest environmentRequest, int userId, int deviceId);

        int? GetUserDeviceLatestEnvironmentId(int userId, int deviceId);
    }
}
