using System.Text.Json;
using System.Text.Json.Serialization;

namespace RdwApi.Converters
{
    internal class NullableStringConverter : JsonConverter<string?>
    {
        public override bool CanConvert(Type typeToConvert) => typeToConvert == typeof(string);

        public override string? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString() ?? "Niet geregistreerd";
            return value == "Niet geregistreerd" ? null : value;
        }

        public override void Write(Utf8JsonWriter writer, string? value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value ?? "Niet geregistreerd");
        }
    }
}
