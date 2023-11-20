using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using ReadSenseApi.Models;
using ReadSenseApi.Services;
using System.Security.Claims;

namespace ReadSenseApi.SignalRHubs
{
    [Authorize]
    public class ScrollEventHub : Hub
    {
        private readonly IScrollingEventService ScrollingEventService;

        public ScrollEventHub(IScrollingEventService ScrollingEventService)
        {
            this.ScrollingEventService = ScrollingEventService;
        }

        public async Task ScrollEvents(ScrollEvents message)
        {
            var userId = Context.User?.Claims?.FirstOrDefault(x => x.Type == "id")?.Value;
            var deviceId = Context.User?.Claims?.FirstOrDefault(x => x.Type == "deviceId")?.Value;

            if (userId == null || deviceId == null)
            {
                return;
            }

            await ScrollingEventService.SaveScrollingEvent(int.Parse(userId),int.Parse(deviceId), message);
        }
            
    }
}
