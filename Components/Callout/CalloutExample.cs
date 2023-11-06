using Components.Component.ViewModels;

namespace Components.Callout
{
    public partial class CalloutViewModel : ComponentViewModel
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
                        CalloutType = CalloutEnum.Info,
                        Title = "This is an info callout.",
                        Message = "Example text to show it in action.",
                    },
                    new CalloutViewModel
                    {
                        CalloutType = CalloutEnum.Warning,
                        Title = "This is a warning callout.",
                        Message = "Example text to show it in action.",
                    },
                    new CalloutViewModel
                    {
                        CalloutType = CalloutEnum.Danger,
                        Title = "This is a danger callout.",
                        Message = "Example text to show it in action.",
                    },
                }
            };
        }
    }
}