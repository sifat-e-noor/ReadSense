using System.ComponentModel.DataAnnotations;

namespace ReadSenseApi.Database.Entities
{
    public class ScrollingEvent
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int DeviceId { get; set; }

        public int EnvironmentId { get; set; }

        public int? ReadSettingsEventId { get; set; }

        public int BookId { get; set; }

        public float StartPosition { get; set; }
        public float EndPosition { get; set; }

        /// <summary>
        /// Scroll Start Time, A number representing the timestamp, in milliseconds
        /// </summary>
        public long StartTime { get; set; }

        /// <summary>
        /// Scroll End Time, A number representing the timestamp, in milliseconds
        /// </summary>
        public long EndTime { get; set; }

        public int? StartPTagIndex { get; set; }
        public int? EndPTagIndex { get; set; }

    }
}
