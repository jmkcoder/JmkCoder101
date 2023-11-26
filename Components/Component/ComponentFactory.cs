using Components.Component.Interface;
using Components.Component.ViewModels;
using System.Reflection;

namespace Components.Component
{
    public static class ComponentFactory
    {
        public static ComponentViewModel? Instantiate(string? name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var componentTypes = assembly.GetTypes().Where(t => typeof(IComponentViewModel).IsAssignableFrom(t) && t.IsClass);

            name += "ViewModel";

            foreach ( var componentType in componentTypes )
            {
                if (componentType.Name == name)
                {
                    return Activator.CreateInstance(componentType) as ComponentViewModel;
                }
            }

            return null;
        }
    }
}
