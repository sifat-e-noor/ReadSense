using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ReadSenseApi.Models
{
    public class ReadSettingsEventRequest
    {
        [JsonPropertyName("fontSize")]
        public JsonNode? FontSize { get; set; }

        [JsonPropertyName("fonts")]
        public JsonNode? Fonts { get; set; }

        [JsonPropertyName("lineHeight")]
        public JsonNode? LineHeight { get; set; }

        [JsonPropertyName("lineSpacing")]
        public JsonNode? LineSpacing { get; set; }

        [JsonPropertyName("align")]
        public JsonNode? Align { get; set; }

        [JsonPropertyName("layout")]
        public JsonNode? Layout { get; set; }

        [JsonPropertyName("bookInfo")]
        public JsonNode? BookInfo { get; set; }

        [JsonPropertyName("settingsApplyTime")]
        public DateTime SettingsApplyTime { get; set; }
    }
}
