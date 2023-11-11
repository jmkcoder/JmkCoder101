using Components.Callout;
using Components.Common;
using Components.Component.ViewModels;

namespace Components.Badge
{
    public partial class BadgeViewModel
    {
        protected override string? Description => "Documentation and examples for badges, our small count and labeling component.";
        protected override bool WithSpace => false;
        protected override List<int> SpaceIndex => new() { 7 };

        protected override List<ComponentViewModel> Samples()
        {
            return new List<ComponentViewModel>
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
                };
        }
    }
}