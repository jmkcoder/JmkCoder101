using System.Text.Json.Serialization;
using System.Text.Json;

namespace Components.Common.MarkDown
{
    public class JsonStringConverterFactory : JsonConverterFactory
    {
        public override bool CanConvert(Type typeToConvert)
        {
            return typeToConvert == typeof(string);
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            return new JsonStringConverter();
        }

        private class JsonStringConverter : JsonConverter<string>
        {
            public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                // Read the JSON string value
                string jsonString = ApplyCustomTransformation(reader.GetString() ?? string.Empty);

                // Perform custom deserialization if needed
                // For example, you might want to reverse the previous transformation
                string result = ReverseCustomTransformation(jsonString);

                return result;
            }

            public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
            {
                // Call your custom method for string conversion
                string result = ApplyCustomTransformation(value);

                // Write the result to the JSON writer
                writer.WriteStringValue(result);
            }

            private string ApplyCustomTransformation(string input)
            {
                // Apply your custom transformation logic here
                // For example, using Markdig to convert markdown to HTML
                return Markdig.Markdown.ToHtml(input).Replace("\r", "").Replace("\n", "").Replace("<p>", "").Replace("</p>", "");
            }

            private string ReverseCustomTransformation(string input)
            {
                // Implement the reverse of your custom transformation logic here
                // For example, you might need to convert HTML back to markdown
                // This is a placeholder and should be adjusted based on your needs
                return input;
            }
        }
    }
}
