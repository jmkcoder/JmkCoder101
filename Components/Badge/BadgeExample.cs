using Components.Common;
using Components.Component.ViewModels;

namespace Components.Badge
{
    public partial class BadgeViewModel
    {
        public override ExampleViewModel Example()
        {
            return new ExampleViewModel()
            {
                Title = "Badge",
                Description = "Documentation and examples for badges, our small count and labeling component.",
                ViewPath = GetViewPath(),
                ModelLines = GetSourceCode(),
                WithSpace = false,
                SpaceIndex = new List<int> { 7 },
                Components = new List<ComponentViewModel>
                {
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Primary,
                        Text = "Primary",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Secondary,
                        Text = "Secondary",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Info,
                        Text = "Info",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Success,
                        Text = "Success",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Warning,
                        Text = "Warning",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Danger,
                        Text = "Danger",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Light,
                        Text = "Light",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Dark,
                        Text = "Dark",
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Primary,
                        Text = "Primary",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Secondary,
                        Text = "Secondary",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Info,
                        Text = "Info",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Success,
                        Text = "Success",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Warning,
                        Text = "Warning",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Danger,
                        Text = "Danger",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Light,
                        Text = "Light",
                        IsPill = true,
                    },
                    new BadgeViewModel
                    {
                        Color = ColorEnum.Dark,
                        Text = "Dark",
                        IsPill = true,
                    },
                }
            };
        }
    }
}