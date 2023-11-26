using Components.Alert;
using Components.Badge;
using Components.Callout;
using Components.Component.ViewModels;
using Components.Icon;

namespace Components.Component
{
    public static class ComponentFactory
    {
        public static ComponentViewModel? Instantiate(string? name)
        {
            name += "ViewModel";

            if (name == nameof(AlertViewModel))
            {
               return new AlertViewModel();
            }
            else if (name == nameof(BadgeViewModel))
            {
                return new BadgeViewModel();
            }
            else if (name == nameof(CalloutViewModel))
            {
                return new CalloutViewModel();
            }
            else if (name == nameof(IconViewModel))
            {
                return new IconViewModel();
            }

            return null;
        }
    }
}
