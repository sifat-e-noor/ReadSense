using Microsoft.IdentityModel.Tokens;
using ReadSenseApi.Database;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;
using System.Text.Json.Nodes;

namespace ReadSenseApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ReadSettingsService(
            ReadSenseDBContext _context,
            IEnvironmentService _environmentService
        ) : IReadSettingsService
    {

        /// <summary>
        /// ReadSettings insert method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="environmentId"></param>
        /// <param name="readSettingsId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ReadSettings insert method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="readSettingsEventRequests"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ReadSettingsEvent Insert(int userId, int deviceId, List<ReadSettingsEventRequest> readSettingsEventRequests)
        {
            var environment = _environmentService.GetByDeviceIdAndUserId(deviceId, userId) ?? throw new Exception("Environment not found");
            var readSettingsEvents = new List<Database.Entities.ReadSettingsEvent>();
            foreach (var readSettingsEventRequest in readSettingsEventRequests)
            {
                readSettingsEvents.Add( new Database.Entities.ReadSettingsEvent
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
                    Settings = readSettingsEventRequest.Settings?.ToJsonString(),
                    Inserted = DateTime.Now.ToUniversalTime(),
                });
            }

            _context.ReadSettingsEvents.AddRange(readSettingsEvents);
            _context.SaveChanges();

            JsonNode? currentReadSettings = readSettingsEventRequests.Last().Settings;
            if (currentReadSettings != null )
            {
                SetCurrentReadSettingsForDevice(deviceId, currentReadSettings.ToJsonString());
            }
         

            return readSettingsEvents.Last();

        }

        /// <summary>
        /// ReadSettings update method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="environmentId"></param>
        /// <param name="readSettingsId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ReadSettings delete method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="environmentId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// ReadSettings get method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="environmentId"></param>
        /// <returns></returns>
        public Database.Entities.ReadSettingsEvent? Get(int userId, int deviceId, int environmentId)
        {
            return _context.ReadSettingsEvents.FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId && x.EnvironmentId == environmentId);
        }

        /// <summary>
        /// ReadSettings get all method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent> GetAll()
        {
            return _context.ReadSettingsEvents.IsNullOrEmpty() ? new List<Database.Entities.ReadSettingsEvent>() : _context.ReadSettingsEvents;
        }

        /// <summary>
        /// ReadSettings get by user id method
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent> GetByUserId(int userId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId);
        }

        /// <summary>
        /// ReadSettings get by device id method
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByDeviceId(int deviceId)
        {
            return _context.ReadSettingsEvents.Where(x => x.DeviceId == deviceId);
        }

        /// <summary>
        /// ReadSettings get by environment id method
        /// </summary>
        /// <param name="environmentId"></param>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByEnvironmentId(int environmentId)
        {
            return _context.ReadSettingsEvents.Where(x => x.EnvironmentId == environmentId);
        }

        /// <summary>
        /// ReadSettings get by read settings id method
        /// </summary>
        /// <param name="readSettingsId"></param>
        /// <returns></returns>
        public Database.Entities.ReadSettingsEvent? GetById(int readSettingsId)
        {
            return _context.ReadSettingsEvents.FirstOrDefault(x => x.Id == readSettingsId);
        }

        /// <summary>
        /// ReadSettings get by user id and device id method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByUserIdAndDeviceId(int userId, int deviceId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId && x.DeviceId == deviceId);
        }

        /// <summary>
        /// ReadSettings get by user id and environment id method
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="environmentId"></param>
        /// <returns></returns>
        public IEnumerable<Database.Entities.ReadSettingsEvent>? GetByUserIdAndEnvironmentId(int userId, int environmentId)
        {
            return _context.ReadSettingsEvents.Where(x => x.UserId == userId && x.EnvironmentId == environmentId);
        }

        /// <summary>
        /// Get current user read settings if present or else set starting read settings for the user current environment
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="deviceId"></param>
        /// <param name="readSettingsRequest"></param>
        /// <returns></returns>
        public ReadSettingsRequest GetCurrentUserReadSettings(int userId, int deviceId, ReadSettingsRequest readSettingsRequest)
        {
            if (!readSettingsRequest.EnvironmentId.HasValue)
            {
                readSettingsRequest.EnvironmentId = _environmentService.GetUserDeviceLatestEnvironmentId(userId, deviceId) ?? throw new Exception("Environment not found");
            }
            
            if (readSettingsRequest.ReadSettingsEventId.HasValue && _context.ReadSettingsEvents.FirstOrDefault(x => x.Id == readSettingsRequest.ReadSettingsEventId) != null)
            {
                return readSettingsRequest;
            }
            

            // if readsettings event not present for the user, device and environment; then create a new readsettings event.
            var readSettingsEvent = _context.ReadSettingsEvents.OrderByDescending(x => x.Id).FirstOrDefault(x => x.UserId == userId && x.DeviceId == deviceId && x.EnvironmentId == readSettingsRequest.EnvironmentId);

            if (readSettingsEvent != null)
            {
                readSettingsRequest.ReadSettingsEventId = readSettingsEvent.Id;
                readSettingsRequest.Settings = readSettingsEvent.Settings != null ? JsonNode.Parse(readSettingsEvent.Settings) : readSettingsRequest.Settings;
                return readSettingsRequest;
            }

            var currentReadSettings = GetCurrentReadSettingsFromDevice(deviceId);
            if (currentReadSettings != null)
            {
                readSettingsRequest.Settings = JsonNode.Parse(currentReadSettings);
            }


            readSettingsEvent = new Database.Entities.ReadSettingsEvent
            {
                UserId = userId,
                DeviceId = deviceId,
                EnvironmentId = readSettingsRequest.EnvironmentId.Value,
                TimeOfChange = DateTime.Now.ToUniversalTime(),
                FontSize = null,
                Fonts = null,
                LineHeight = null,
                LineSpacing = null,
                Align = null,
                Layout = null,
                BookInfo = readSettingsRequest.BookId.HasValue?  $"{{ id: {readSettingsRequest.BookId.Value} }}" : null,
                Settings = readSettingsRequest.Settings?.ToJsonString(),
                Inserted = DateTime.Now.ToUniversalTime(),
            };

            _context.ReadSettingsEvents.Add(readSettingsEvent);
            _context.SaveChanges();

            return readSettingsRequest;
        }

        /// <summary>
        /// Get current user read settings if present on the device table
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        private string? GetCurrentReadSettingsFromDevice(int deviceId)
        {
            return _context.Devices.FirstOrDefault(x => x.Id == deviceId)?.ReadSettings;
        }

        private void SetCurrentReadSettingsForDevice(int deviceId, string readSettings)
        {
            var device = _context.Devices.FirstOrDefault(x => x.Id == deviceId);
            if (device == null)
            {
                return;
            }

            device.ReadSettings = readSettings;
            device.LastUpdated = DateTime.Now.ToUniversalTime();
            _context.SaveChanges();
        }
    }
}
