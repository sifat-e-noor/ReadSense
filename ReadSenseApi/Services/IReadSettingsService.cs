using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public interface IReadSettingsService
    {
        Database.Entities.ReadSettingsEvent? Insert(int userId, int deviceId, int environmentId, int readSettingsId);
        public ReadSettingsEvent Insert(int userId, int deviceId, List<ReadSettingsEventRequest> readSettingsEventRequests);
        Database.Entities.ReadSettingsEvent? Update(int userId, int deviceId, int environmentId, int readSettingsId);
        bool Delete(int userId, int deviceId, int environmentId);

        public IEnumerable<Database.Entities.ReadSettingsEvent> GetAll();
        public Database.Entities.ReadSettingsEvent? GetById(int id);
    }
}
