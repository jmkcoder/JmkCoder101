using JmkCoder101.Component.Interface;
using System.Reflection;

namespace JmkCoder101.Component.ViewModels
{
    public abstract class ComponentViewModel : IComponentViewModel
    {
        public string? HtmlCode { get; set; }

        public abstract ExampleViewModel Example();

        protected string[] GetSourceCode()
        {
            return File.ReadAllLines($"{GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/")}/" +
                    $"{GetType().Name}.cs");
        }

        protected string GetViewPath()
        {
            return $"~/{ GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/")}/Views/Index.cshtml";
        }
    }
}
