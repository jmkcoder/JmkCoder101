using Components.Component.ViewModels;

namespace Components.Alert
{
    public partial class AlertViewModel
    {
        public override ExampleViewModel Example()
        {
            return new ExampleViewModel()
            {
                Title = "Alert",
                Description = "Provide contextual feedback messages for typical user actions with the handful of available and flexible alert messages.",
                ViewPath = GetViewPath(),
                ModelLines = GetSourceCode(),
                Components = new List<ComponentViewModel>
                {
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Info,
                        Text = "This is an info alert — check it out!",
                    },
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Success,
                        Text = "This is a success alert — check it out!",
                    },
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Warning,
                        Text = "This is a warning alert — check it out!",
                    },
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Danger,
                        Text = "This is a danger alert — check it out!",
                    },
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Light,
                        Text = "This is a light alert — check it out!",
                    },
                    new AlertViewModel
                    {
                        AlertType = AlertEnum.Dark,
                        Text = "This is a dark alert — check it out!",
                    },
                }
            };
        }
    }
}
