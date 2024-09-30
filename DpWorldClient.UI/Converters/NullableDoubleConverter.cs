using System.Text.Json;
using System.Text.Json.Serialization;

namespace DpWorldClient.UI.Converters
{
    public class NullableDoubleConverter : JsonConverter<double?>
    {
        public override double? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            // Manejar números
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDouble();
            }
            // Manejar cadenas
            else if (reader.TokenType == JsonTokenType.String)
            {
                string str = reader.GetString();

                if (string.IsNullOrEmpty(str))
                    return null;

                if (double.TryParse(str, out double result))
                    return result;

                throw new JsonException($"No se pudo convertir \"{str}\" a double.");
            }
            // Manejar nulos
            else if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            throw new JsonException($"Token inesperado al analizar double. Se esperaba Number, String o Null, se obtuvo {reader.TokenType}.");
        }

        public override void Write(Utf8JsonWriter writer, double? value, JsonSerializerOptions options)
        {
            if (value.HasValue)
                writer.WriteNumberValue(value.Value);
            else
                writer.WriteNullValue();
        }
    }
}