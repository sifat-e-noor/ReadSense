using System.ComponentModel.DataAnnotations;

namespace ReadSenseApi.Database.Entities
{
    /// <summary>
    /// Represents a ReadSettings change Event in the database.
    /// </summary>
    public class ReadSettingsEvent
    {
        /// <summary>
        /// The unique identifier for the ReadSettingsEvent.
        /// </summary>
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

        /// <summary>
        /// The time of the change event. 
        /// </summary>
        public DateTimeOffset TimeOfChange { get; set; }

        /// <summary>
        /// The Font Family change in JSON format.
        /// </summary>

        public string? FontSize { get; set; }

        /// <summary>
        /// The Font change in JSON format.
        /// </summary>
        public string? Fonts { get; set; }

        /// <summary>
        /// The Line Height change in JSON format.
        /// </summary>
        public string? LineHeight { get; set; }

        /// <summary>
        /// The Line Spacing change in JSON format.
        /// </summary>
        public string? LineSpacing { get; set; }

        /// <summary>
        /// The Alignments change in JSON format.
        /// </summary>
        public string? Align { get; set; }

        /// <summary>
        /// The Layout change in JSON format.
        /// </summary>
        public string? Layout { get; set; }

        /// <summary>
        /// The book information in JSON format.
        /// </summary>
        public string? BookInfo { get; set; }

        /// <summary>
        /// The current settings in JSON format.
        /// </summary>
        public string? Settings { get; set; }

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        /// <summary>
        /// The ScrollingEvents associated with the ReadSettings after change.
        /// </summary>
        public List<ScrollingEvent> ScrollingEvents { get; } = [];
    }
}
