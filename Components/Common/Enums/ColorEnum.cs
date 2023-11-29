using System.Text.Json.Serialization;

namespace Components.Common.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ColorEnum
    {
        Primary,
        Secondary,
        Success,
        Info,
        Warning,
        Danger,
        Light,
        Dark
    }
}
