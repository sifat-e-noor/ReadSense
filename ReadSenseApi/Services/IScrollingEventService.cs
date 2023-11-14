using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public interface IScrollingEventService
    {
        public Task SaveScrollingEvent(int userId, int deviceId, ScrollEvents message);
    }
}
