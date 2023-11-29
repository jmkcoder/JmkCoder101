using System.Text.Json.Serialization;

namespace Components.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SizeEnum
    {
        xxs,
        xs,
        sm,
        md,
        lg,
        xl,
        xxl
    }
}
