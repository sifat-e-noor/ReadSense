using AutoMapper;
using System.Text.Json.Nodes;

namespace ReadSenseApi.Helpers
{
    public class JsonNodeTypeConverter : ITypeConverter<string?, JsonNode?>
    {
        public JsonNode? Convert(string? source, JsonNode? destination, ResolutionContext context)
        {
            if (source == null)
            {
                return null;
            }

            return JsonNode.Parse(source);
        }
    }
}
