using System.Text.Json.Nodes;

namespace ReadSenseApi.Models
{
    /// <summary>
    /// Represents a ReadSettings Request
    /// </summary>
    public class ReadSettingsRequest
    {
        /// <summary>
        /// Represents the Id of the Book
        /// </summary>
        public int? BookId { get; set; } 

        /// <summary>
        /// Represents the Id of the ReadSettingsEvent
        /// </summary>
        public int? ReadSettingsEventId { get; set; }

        /// <summary>
        /// Represents the Id of the Environment
        /// </summary>
        public int? EnvironmentId { get; set; }

        /// <summary>
        /// Represents the Current Read Settings of the User
        /// </summary>
        public JsonNode? Settings { get; set; }
    }
}
