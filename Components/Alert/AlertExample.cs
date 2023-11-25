using Components.Common;
using Components.Component.ViewModels;
using Microsoft.Extensions.FileProviders;

namespace Components.Alert
{
    public partial class AlertViewModel
    {
        protected override string? Description => "Provide contextual feedback messages for typical user actions with the handful of available and flexible alert messages.";

        protected override string? Documentation { get; set; }

        protected override List<ComponentViewModel> Samples()
        {
            var displayMarkDownUseCase = new DisplayMarkDownUseCase<AlertViewModel>();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Namespace);
            Documentation = displayMarkDownUseCase.Display($"{path}/Documentation.md");

            return new List<ComponentViewModel>
                {
                    new AlertViewModel
                    {
                        Color = ColorEnum.Primary,
                        Text = "This is a primary alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Secondary,
                        Text = "This is an secondary alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Info,
                        Text = "This is an info alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Success,
                        Text = "This is a success alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Warning,
                        Text = "This is a warning alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Danger,
                        Text = "This is a danger alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Light,
                        Text = "This is a light alert — check it out!",
                        IsDismissible = true,
                    },
                    new AlertViewModel
                    {
                        Color = ColorEnum.Dark,
                        Text = "This is a dark alert — check it out!",
                        IsDismissible = true,
                    },
                };
        }
    }
}
