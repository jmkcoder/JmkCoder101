using Components.Component.Interface;
using System.Reflection;

namespace Components.Component.ViewModels
{
    public abstract class ComponentViewModel : IComponentViewModel
    {
        public string? Id { get; set; }

        protected abstract string? Description { get; }

        protected virtual bool WithSpace { get; } = true;

        protected virtual List<int> SpaceIndex { get; } = new List<int>();

        protected abstract List<ComponentViewModel> Samples();

        public ExampleViewModel Example()
        {
            return new ExampleViewModel()
            {
                Title = GetComponentName(),
                Description = "Provide contextual feedback messages for typical user actions with the handful of available and flexible callout messages.",
                ViewPath = GetViewPath(),
                WithSpace = WithSpace,
                SpaceIndex = SpaceIndex,
                Components = Samples()
            };
        }

        protected string GetViewPath()
        {
            return $"~/{GetType().Namespace?.Replace($"{Assembly.GetAssembly(GetType())?.GetName().Name}.", string.Empty).Replace(".", "/")}/Views/Index.cshtml";
        }

        protected string GetComponentName()
        {
            return GetType().Name.Replace("ViewModel", string.Empty);
        }
    }
}
