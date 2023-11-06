using Components.Common;
using Components.Component.ViewModels;

namespace Components.Callout
{
    public partial class CalloutViewModel
    {
        public override ExampleViewModel Example()
        {
            return new ExampleViewModel()
            {
                Title = "Callout",
                Description = "Provide contextual feedback messages for typical user actions with the handful of available and flexible callout messages.",
                ViewPath = GetViewPath(),
                ModelLines = GetSourceCode(),
                Components = new List<ComponentViewModel>
                {
                    new CalloutViewModel
                    {
                        Color = ColorEnum.Info,
                        Title = "This is an info callout.",
                        Message = "Example text to show it in action.",
                    },
                    new CalloutViewModel
                    {
                        Color = ColorEnum.Warning,
                        Title = "This is a warning callout.",
                        Message = "Example text to show it in action.",
                    },
                    new CalloutViewModel
                    {
                        Color = ColorEnum.Danger,
                        Title = "This is a danger callout.",
                        Message = "Example text to show it in action.",
                    },
                }
            };
        }
    }
}