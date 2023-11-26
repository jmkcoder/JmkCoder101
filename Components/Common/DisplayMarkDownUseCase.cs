using Components.Component;
using Components.Component.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;

namespace Components.Common
{
    public class DisplayMarkDownUseCase : PageModel
    {

        private readonly RazorPageRenderer? _razorPageRenderer;

        public DisplayMarkDownUseCase()
        {
            _razorPageRenderer = RazorPageRenderer.Instance;
        }

        public string Display(string filePath)
        {
            string markdownContent = ReadMarkdownFromFile(filePath);

            markdownContent = ReplacePlaceholdersWithPartialViews(markdownContent);

            return ConvertMarkdownToHtml(markdownContent);
        }

        private static string ReadMarkdownFromFile(string filePath)
        {
            return System.IO.File.ReadAllText(filePath);
        }

        private string ReplacePlaceholdersWithPartialViews(string markdownContent)
        {
            markdownContent = Regex.Replace(markdownContent, @"\{{(?<name>\w+)\s+(.*?)\}}", match =>
            {
                var name = match.Groups["name"].Value.Trim();
                var parameters = match.Groups[1].Value;

                var parameterDictionary = parameters
                    .Split("\" ")
                    .Select(p => p.Split('='))
                    .ToDictionary(p => p[0], p => p[1].Trim('"'));

                var model = ComponentFactory.Instantiate(name);

                if (model is null)
                    return markdownContent;

                foreach (var property in model.GetType().GetProperties())
                {
                    if (parameterDictionary.ContainsKey(property.Name))
                    {
                        var castValue = ConvertToObject(parameterDictionary.First(p => p.Key == property.Name), model.GetType());

                        property.SetValue(model, castValue);
                    }
                }

                return Render(model);
            });

            return markdownContent;
        }

        private string Render(IComponentViewModel model)
        {
            var name = model.GetType().Name.Replace("ViewModel", "");

            var view = _razorPageRenderer?.RenderPageAsync($"~/{name}/Views/Index.cshtml", model).Result;

            return view ?? string.Empty;
        }

        private static string ConvertMarkdownToHtml(string markdownContent)
        {
            return Markdig.Markdown.ToHtml(markdownContent);
        }

        private object? ConvertToObject(KeyValuePair<string, string> item, Type type)
        {
            var propertyType = type.GetProperties().FirstOrDefault(x => x.Name == item.Key)?.PropertyType;

            if (propertyType != null && propertyType.IsEnum)
            {
                var values = Enum.GetValues(propertyType);

                for (var i = 0; i < (values?.Length ?? 0); i++)
                {
                    ;
                    if (i.ToString() == item.Value || Enum.GetName(propertyType, i) == item.Value)
                    {
#pragma warning disable CS8601 // Possible null reference assignment.
                        return values != null && values.GetValue(i) != null ? Enum.Parse(propertyType, values.GetValue(i).ToString()) : null;
#pragma warning restore CS8601 // Possible null reference assignment.
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
                return Markdig.Markdown.ToHtml(item.Value).Replace("\r","").Replace("\n", "").Replace("<p>", "<p style=\"margin-bottom: 0;\">");
            }

            return null;
        }
    }
}
