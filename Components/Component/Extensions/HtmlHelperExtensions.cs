using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace Components.Component.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static IEnumerable<PropertyInfo>? GetSourceCode(this IHtmlHelper htmlHelper, Type? type)
        {
            if (type is not null)
            {
                var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
                var baseProperties = type.BaseType?.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                var allProperties = baseProperties?.Concat(properties.Where(x => !baseProperties.Select(y => y.Name).Contains(x.Name))) ?? properties;

                return allProperties;
            }

            return null;
        }

        public static bool IsType(this IHtmlHelper htmlHelper, Type? type, Type? comparedType)
        {
            if (type is not null && comparedType is not null)
            {
                return type != null && Nullable.GetUnderlyingType(type) == comparedType || type == comparedType;
            }

            return false;
        }
    }
}
