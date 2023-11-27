using Components.Component;
using Components.Component.Interface;
using Components.Component.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Components.Common.MarkDown
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
            var pattern = @"{{(.*?})}}";

            var regex = new Regex(pattern, RegexOptions.Singleline);
            var matches = regex.Matches(markdownContent);

            foreach (Match match in matches)
            {
                string result = match.Groups[1].Value;

                var newModel = GetModel(result);

                if (newModel == null)
                    continue;

                markdownContent = markdownContent.Replace($"{{{{{result}}}}}", Render(newModel));
            }

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

        private static ComponentViewModel? GetModel(string jsonText)
        {
            JsonSerializerOptions options = new JsonSerializerOptions();
            options.Converters.Add(new JsonEnumConverterFactory());
            options.Converters.Add(new JsonStringConverterFactory());

            var jsonDocument = JsonDocument.Parse(jsonText);

            var rootElement = jsonDocument.RootElement;

            var modelName = GetModelName(rootElement);

            var property = rootElement.GetProperty(modelName);

            var model = ComponentFactory.Instantiate(modelName);

            if (model == null)
                return null;

            return (ComponentViewModel?)property.Deserialize(model.GetType(), options);
        }

        private static string GetModelName(JsonElement rootElement)
        {
            var property = rootElement.EnumerateObject().First();

            return property.Name;
        }
    }
}