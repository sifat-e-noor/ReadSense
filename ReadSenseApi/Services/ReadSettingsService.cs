using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public class ReadSettingsService : IReadSettingsService
    {
        private readonly ReadSenseDBContext _context;
        private readonly IEnvironmentService _environmentService;

        public ReadSettingsService(ReadSenseDBContext context, IEnvironmentService environmentService)
        {
            _context = context;
            _environmentService = environmentService;
        }

        // ReadSettings insert method
        public Database.Entities.ReadSettingsEvent? Insert(int userId, int deviceId, int environmentId, int readSettingsId)
        {
            var readSettingsEvent = new Database.Entities.ReadSettingsEvent
            {
                UserId = userId,
                DeviceId = deviceId,
                EnvironmentId = environmentId,
                Id = readSettingsId,
                Inserted = DateTime.Now.ToUniversalTime(),
            };

            _context.ReadSettingsEvents.Add(readSettingsEvent);
            _context.SaveChanges();

            return readSettingsEvent;
        }

        public int Insert(int userId, int deviceId, List<ReadSettingsEventRequest> readSettingsEventRequests)
        {
            var environment = _environmentService.GetByDeviceIdAndUserId(deviceId, userId) ?? throw new Exception("Environment not found");

            foreach (var readSettingsEventRequest in readSettingsEventRequests)
            {
                var readSettingsEvent = new Database.Entities.ReadSettingsEvent
                {
                    UserId = userId,
                    DeviceId = deviceId,
                    EnvironmentId = environment.Id,
                    TimeOfChange = readSettingsEventRequest.SettingsApplyTime,
                    FontSize = readSettingsEventRequest.FontSize?.ToJsonString(),
                    Fonts = readSettingsEventRequest.Fonts?.ToJsonString(),
                    LineHeight = readSettingsEventRequest.LineHeight?.ToJsonString(),
                    LineSpacing = readSettingsEventRequest.LineSpacing?.ToJsonString(),
                    Align = readSettingsEventRequest.Align?.ToJsonString(),
                    Layout = readSettingsEventRequest.Layout?.ToJsonString(),
                    BookInfo = readSettingsEventRequest.BookInfo?.ToJsonString(),
                    Inserted = DateTime.Now.ToUniversalTime(),
                };

                _context.ReadSettingsEvents.Add(readSettingsEvent);
            }

            return _context.SaveChanges();

        }

        // ReadSettings update method
        public Database.Entities.ReadSettingsEvent? Update(int userId, int deviceId, int environmentId, int readSettingsId)
        {
            var readSettingsEvent = _context.ReadSettingsEvents.FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId && x.EnvironmentId == environmentId);

            if (readSettingsEvent == null)
            {
                return null;
            }

            readSettingsEvent.Id = readSettingsId;
            readSettingsEvent.LastUpdated = DateTime.Now.ToUniversalTime();

            _context.SaveChanges();

            return readSettingsEvent;
        }

        // ReadSettings delete method
        public bool Delete(int userId, int deviceId, int environmentId)
        {
            var readSettingsEvent = _context.ReadSettingsEvents.FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId && x.EnvironmentId == environmentId);

            if (readSettingsEvent == null)
            {
                return false;
            }

            _context.ReadSettingsEvents.Remove(readSettingsEvent);
            _context.SaveChanges();

            return true;
        }

        // ReadSettings get method
        public Database.Entities.ReadSettingsEvent? Get(int userId, int deviceId, int environmentId)
        {
            return _context.ReadSettingsEvents.FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId && x.EnvironmentId == environmentId);
        }

        // ReadSettings get all method
        public IEnumerable<Database.Entities.ReadSettingsEvent> GetAll()
        {
            return _context.ReadSettingsEvents.IsNullOrEmpty() ? new List<Database.Entities.ReadSettingsEvent>() : _context.ReadSettingsEvents;
        }

        // ReadSettings get by user id method
        public IEnumerable<Database.Entities.ReadSettingsEvent> GetByUserId(int userId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId);
        }

        // ReadSettings get by device id method
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByDeviceId(int deviceId)
        {
            return _context.ReadSettingsEvents.Where(x => x.DeviceId == deviceId);
        }

        // ReadSettings get by environment id method
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByEnvironmentId(int environmentId)
        {
            return _context.ReadSettingsEvents.Where(x => x.EnvironmentId == environmentId);
        }

        // ReadSettings get by read settings id method
        public Database.Entities.ReadSettingsEvent? GetById(int readSettingsId)
        {
            return _context.ReadSettingsEvents.FirstOrDefault(x => x.Id == readSettingsId);
        }

        // ReadSettings get by user id and device id method
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByUserIdAndDeviceId(int userId, int deviceId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId && x.DeviceId == deviceId);
        }

        // ReadSettings get by user id and environment id method
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByUserIdAndEnvironmentId(int userId, int environmentId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId && x.EnvironmentId == environmentId);
        }
    }
}
