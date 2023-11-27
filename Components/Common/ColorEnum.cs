using System.Text.Json.Serialization;

namespace Components.Common
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
