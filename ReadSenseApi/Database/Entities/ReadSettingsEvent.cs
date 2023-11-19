using System.ComponentModel.DataAnnotations;

namespace ReadSenseApi.Database.Entities
{
    public class ReadSettingsEvent
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The unique identifier for the user associated with the settings.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// The unique identifier for the device associated with the settings.
        /// </summary>
        public int DeviceId { get; set; }

        /// <summary>
        /// The unique identifier for the environment associated with the settings.
        /// </summary>
        public int EnvironmentId { get; set; }

        public DateTimeOffset TimeOfChange { get; set; }

        public string? FontSize { get; set; }
        public string? Fonts { get; set; }
        public string? LineHeight { get; set; }
        public string? LineSpacing { get; set; }
        public string? Align { get; set; }
        public string? Layout { get; set; }

        public string? BookInfo { get; set; }

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public List<ScrollingEvent> ScrollingEvents { get; } = [];
    }
}
