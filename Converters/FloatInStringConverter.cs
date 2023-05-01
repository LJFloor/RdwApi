using System.Text.Json;
using System.Text.Json.Serialization;

namespace RdwApi.Converters
{
    public class FloatInStringConverter : JsonConverter<float>
    {
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert == typeof(float);

        public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
            float.Parse(reader.GetString());

        public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options) =>
            writer.WriteStringValue(value.ToString());
    }
}
