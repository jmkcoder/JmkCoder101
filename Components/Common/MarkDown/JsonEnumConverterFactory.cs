using System.Text.Json.Serialization;
using System.Text.Json;

namespace Components.Common.MarkDown
{
    public class JsonEnumConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert.IsEnum;
        }

        public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type converterType = typeof(EnumNameConverter<>).MakeGenericType(typeToConvert);
            return Activator.CreateInstance(converterType) as JsonConverter;
        }

        private class EnumNameConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : Enum
        {
            public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType == JsonTokenType.String)
                {
                    var enumName = reader.GetString();

                    if (enumName == null)
                        return (TEnum)Enum.ToObject(typeof(TEnum), 0);

                    return (TEnum)Enum.Parse(typeof(TEnum), enumName, ignoreCase: true);
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    if (reader.TryGetInt32(out int enumValue))
                    {
                        return (TEnum)Enum.ToObject(typeof(TEnum), enumValue);
                    }
                }

                throw new JsonException($"Unable to convert {reader.TokenType} to {typeof(TEnum)}.");
            }

            public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
            {
                writer.WriteStringValue(value.ToString());
            }
        }
    }
}
