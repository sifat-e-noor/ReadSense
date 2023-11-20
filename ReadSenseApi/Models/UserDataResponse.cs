using ReadSenseApi.Database.Entities;
using System.Text.Json.Nodes;
using static ReadSenseApi.Database.Entities.Environment;

namespace ReadSenseApi.Models
{
    public class UserDataResponse
    {
        public int Id { get; set; }
        public Boolean? AgreementSigned { get; set; }

        public List<DeviceDataResponse>? Devices { get; set; } = new List<DeviceDataResponse>();
    }

    public class DeviceDataResponse
    {
        public int Id { get; set; }
        public string? FingerPrint { get; set; }

        public JsonNode? DeviceInfo { get; set; }

        public List<EnvironmentDataResponse>? Environments { get; set; } = new List<EnvironmentDataResponse>();
    }

    public class EnvironmentDataResponse
    {
        public int Id { get; set; }

        public State? PlaceState { get; set; }

        /// <summary>
        /// The time of day when the environment is being monitored.
        /// Possible values are Morning, Day, Evening, or Night.
        /// </summary>
        public LocationEnum? Location { get; set; }

        /// <summary>
        /// The brightness level of the environment.
        /// Possible values are Dark, Dim, or Bright.
        /// </summary>

        public Brightness? BrightnessLevel { get; set; }

        /// <summary>
        /// The date and time when the environment was inserted into the database.
        /// </summary>
        public DateTimeOffset? Inserted { get; set; }

        public List<ReadSettingsEventData>? ReadSettingsEvents { get; set; } = new List<ReadSettingsEventData>();
    }

    public class ReadSettingsEventData
    {
        public int Id { get; set; }

        public DateTimeOffset TimeOfChange { get; set; }

        public JsonNode? FontSize { get; set; }
        public JsonNode? Fonts { get; set; }
        public JsonNode? LineHeight { get; set; }
        public JsonNode? LineSpacing { get; set; }
        public JsonNode? Align { get; set; }
        public JsonNode? Layout { get; set; }

        public JsonNode? BookInfo { get; set; }

        public DateTimeOffset? Inserted { get; set; }

        public DateTimeOffset? LastUpdated { get; set; }

        public List<ScrollingEventData> ScrollingEvents { get; set; } = new List<ScrollingEventData>();
    }

    public class ScrollingEventData
    {
        public int Id { get; set; }

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
