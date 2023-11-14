using ReadSenseApi.Database.Entities;
using System.Text.Json.Serialization;

namespace ReadSenseApi.Models
{
    public class ScrollEvents
    {
        public int EnvironmentId { get; set; }

        public int? ReadSettingsEventId { get; set; }

        public int BookId { get; set; }

        public required List<ScrollEventData> Data { get; set; }

        public IEnumerable<ScrollingEvent> MapToScrollingEvent(int userId, int deviceId) 
        {
            if (Data.Count == 0)
            {
                return [];
            }

            return Data.Select((x, i) => new ScrollingEvent
                    {
                        UserId = userId,
                        DeviceId = deviceId,
                        EnvironmentId = EnvironmentId,
                        ReadSettingsEventId = ReadSettingsEventId,
                        BookId = BookId,
                        StartPosition = x.StartScrollY,
                        EndPosition = x.EndScrollY,
                        StartTime = x.Start,
                        EndTime = x.End,
                        StartPTagIndex = x.StartPTagIndex,
                        EndPTagIndex = x.EndPTagIndex
                    });
            
        }
       
    }

    public class ScrollEventData
    {
        public long Start { get; set; }
        public long End { get; set; }

        public float StartScrollY { get; set; }
        public float EndScrollY { get; set; }
        public int? StartPTagIndex { get; set; }
        public int? EndPTagIndex { get; set; }
    }
}
