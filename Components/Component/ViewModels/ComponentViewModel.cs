using Components.Component.Interface;
using System.Reflection;

namespace Components.Component.ViewModels
{
    public abstract class ComponentViewModel : IComponentViewModel
    {
        public string? Id { get; set; }

        public string? Classes { get; set; }

        protected abstract string? Description { get; }

        protected virtual bool WithSpace { get; } = true;

        protected virtual string? Documentation { get; set; }

        protected virtual List<int> SpaceIndex { get; } = new List<int>();

        protected abstract List<ComponentViewModel> Samples();

        protected string Namespace { get; set; } = string.Empty;

        public ComponentViewModel()
        {
            Namespace = GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/") ?? string.Empty;
        }

        public ExampleViewModel Example()
        {
            return new ExampleViewModel()
            {
                Title = GetComponentName(),
                Description = Description,
                ViewPath = GetViewPath(),
                WithSpace = WithSpace,
                SpaceIndex = SpaceIndex,
                Components = Samples(),
                Documentation = Documentation
            };
        }

        protected string GetViewPath()
        {
            return $"~/{Namespace}/Views/Index.cshtml";
        }

        protected string GetComponentName()
        {
            return GetType().Name.Replace("ViewModel", string.Empty);
        }
    }
}
