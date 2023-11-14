using ReadSenseApi.Database;
using ReadSenseApi.Database.Entities;
using ReadSenseApi.Models;

namespace ReadSenseApi.Services
{
    public class ScrollingEventService(ReadSenseDBContext context) : IScrollingEventService
    {
        public async Task SaveScrollingEvent(int userId,int deviceId, ScrollEvents message)
        {
            var events = message.MapToScrollingEvent(userId, deviceId);

            if(!events.Any())
            {
                return;
            }

            context.ScrollingEvents.AddRange(events);

            var readingHistory = context.ReadingHistories.FirstOrDefault(x => x.UserId == userId && x.BookId == message.BookId);
            if(readingHistory != null)
            {
                readingHistory.LastUpdated = DateTime.Now;
                readingHistory.PTagIndex = events.Last().EndPTagIndex.GetValueOrDefault();
            }
            else
            {
                context.ReadingHistories.Add(new ReadingHistory
                {
                    UserId = userId,
                    BookId = message.BookId,
                    PTagIndex = events.Last().EndPTagIndex.GetValueOrDefault(),
                    Inserted = DateTime.Now,
                    LastUpdated = DateTime.Now
                });
            }

            await context.SaveChangesAsync();
        }
    }
}
