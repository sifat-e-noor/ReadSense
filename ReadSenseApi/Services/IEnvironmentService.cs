using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public interface IEnvironmentService
    {
        IEnumerable<Database.Entities.Environment> GetAll();
        Database.Entities.Environment? GetById(int id);
        Database.Entities.Environment? GetByUserId(int userId);
        Database.Entities.Environment? GetByDeviceId(int deviceId);
        Database.Entities.Environment? GetByDeviceIdAndUserId(int deviceId, int userId);
        Database.Entities.Environment? Insert(EnvironmentRequest environmentRequest, int userId, int deviceId);
    }
}
