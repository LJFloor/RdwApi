using System.Text.Json;
using System.Text.Json.Serialization;

namespace RdwApi.Converters
{
    // *visible frustration*
    public class RdwBooleanConverter : JsonConverter<bool>
    {
        public override bool CanConvert(Type typeToConvert) => 
            typeToConvert == typeof(bool);

        public override bool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => 
            (reader.GetString() ?? "Nee") == "Ja";

        public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) => 
            writer.WriteStringValue(value ? "Ja" : "Nee");
    }
}
