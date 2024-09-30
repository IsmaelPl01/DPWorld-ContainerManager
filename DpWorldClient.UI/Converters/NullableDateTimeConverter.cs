using System.Text.Json;
using System.Text.Json.Serialization;

namespace DpWorldClient.UI.Converters
{
    public class NullableDateTimeConverter : JsonConverter<DateTime?>
    {
        public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                string str = reader.GetString();

                if (string.IsNullOrEmpty(str))
                    return null;

                if (DateTime.TryParse(str, out DateTime date))
                    return date;

                throw new JsonException($"No se pudo convertir \"{str}\" a DateTime.");
            }
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            throw new JsonException($"Token inesperado al analizar la fecha. Se esperaba String o Null, se obtuvo {reader.TokenType}.");
        }

        public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteStringValue(value.Value.ToString("o")); // Formato ISO 8601
            else
                writer.WriteNullValue();
        }
    }
}