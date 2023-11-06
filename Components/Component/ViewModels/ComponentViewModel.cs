using Components.Component.Interface;
using System.Reflection;

namespace Components.Component.ViewModels
{
    public abstract class ComponentViewModel : IComponentViewModel
    {
        public string? HtmlCode { get; set; }

        public abstract ExampleViewModel Example();

        protected string[] GetSourceCode()
        {
            var viewModelPath = $"{GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/")}/{GetType().Name}.cs";
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly()?.Location) ?? string.Empty, viewModelPath);

            return File.ReadAllLines(path);
        }

        protected string GetViewPath()
        {
            return $"~/{GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/")}/Views/Index.cshtml";
        }
    }
}
