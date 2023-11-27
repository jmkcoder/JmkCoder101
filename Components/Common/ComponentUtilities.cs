namespace Components.Common
{
    public static class ComponentUtilities
    {
        public static object? ConvertToObject(KeyValuePair<string, string?> item, Type type)
        {
            if (item.Value == null)
                return null;

            var propertyType = type.GetProperties().FirstOrDefault(x => x.Name == item.Key)?.PropertyType;

            if (propertyType != null && propertyType.IsEnum)
            {
                var values = Enum.GetValues(propertyType);

                for (var i = 0; i < (values?.Length ?? 0); i++)
                {
                    ;
                    if (i.ToString() == item.Value || Enum.GetName(propertyType, i) == item.Value)
                    {
                        return values != null && values.GetValue(i) != null ? Enum.Parse(propertyType, values?.GetValue(i)?.ToString() ?? "0") : null;
                    }
                };
            }
            else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(int) || propertyType == typeof(int))
            {
                return item.Value != null ? int.Parse(item.Value) : 0;
            }
            else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(bool) || propertyType == typeof(bool))
            {
                return item.Value != null ? bool.Parse(item.Value) : 0;
            }
            else if (propertyType != null && Nullable.GetUnderlyingType(propertyType) == typeof(string) || propertyType == typeof(string))
            {
                return Markdig.Markdown.ToHtml(item.Value).Replace("\r", "").Replace("\n", "").Replace("<p>", "<p style=\"margin-bottom: 0;\">");
            }

            return null;
        }
    }
}
