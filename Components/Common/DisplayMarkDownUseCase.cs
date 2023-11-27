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
            return System.IO.File.Exists(filePath) ? System.IO.File.ReadAllText(filePath) : string.Empty;
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
                    .ToDictionary(p => p[0], p => p[1]?.Trim('"'));

                var model = ComponentFactory.Instantiate(name);

                if (model is null)
                    return markdownContent;

                foreach (var property in model.GetType().GetProperties())
                {
                    if (parameterDictionary.ContainsKey(property.Name))
                    {
                        var item = parameterDictionary.First(p => p.Key == property.Name);

                        var castValue = ComponentUtilities.ConvertToObject(item, model.GetType());

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
    }
}
