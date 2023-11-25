using Components.Component.Interface;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace Components.Common
{
    public class DisplayMarkDownUseCase<T> : PageModel where T : IComponentViewModel, new()
    {

        private readonly RazorPageRenderer? _razorPageRenderer;
        private readonly string? _name;

        public DisplayMarkDownUseCase()
        {
            _razorPageRenderer = RazorPageRenderer.Instance;
            _name = typeof(T).Name.Replace("ViewModel", string.Empty);
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
            markdownContent = Regex.Replace(markdownContent, @"\{{" + _name + @"\s+(.*?)\}}", match =>
            {
                var parameters = match.Groups[1].Value;

                var parameterDictionary = parameters
                    .Split("\" ")
                    .Select(p => p.Split('='))
                    .ToDictionary(p => p[0], p => p[1].Trim('"'));

                var model = new T();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (parameterDictionary.ContainsKey(property.Name))
                    {
                        var castValue = ConvertToObject(parameterDictionary.First(p => p.Key == property.Name));

                        property.SetValue(model, castValue);
                    }
                }

                return Render(model);
            });

            return markdownContent;
        }

        private string Render(T model)
        {
            var view = _razorPageRenderer?.RenderPageAsync($"~/{_name}/Views/Index.cshtml", model).Result;

            return view ?? string.Empty;
        }

        private static string ConvertMarkdownToHtml(string markdownContent)
        {
            return Markdig.Markdown.ToHtml(markdownContent);
        }

        private object? ConvertToObject(KeyValuePair<string, string> item)
        {
            var propertyType = typeof(T).GetProperties().FirstOrDefault(x => x.Name == item.Key)?.PropertyType;

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
                return item.Value;
            }

            return null;
        }
    }
}
