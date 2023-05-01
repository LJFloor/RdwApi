using System.Text.Json;
using System.Text.Json.Serialization;

namespace RdwApi.Converters
{
    /// <summary>
    /// It is as silly as it sounds
    /// </summary>
    public class IntegerInStringConverter : JsonConverter<int>
    {

        public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(int);

        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return int.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}
