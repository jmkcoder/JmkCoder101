using Components.Common.Enums;
using Components.Component.ViewModels;

namespace Components.Icon
{
    public partial class IconViewModel
    {
        protected override string? Description => "Icon component. Allows to render both svg and font icons. It uses Font Awesome v6.";

        protected override bool WithSpace => false;

        protected override List<int> SpaceIndex => new() { 7 };

        protected override List<ComponentViewModel> Samples()
        {
            return new List<ComponentViewModel>()
            {
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Primary,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Secondary,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Success,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Danger,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Warning,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Info,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Light,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Dark,
                    IsSolid = true
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Primary,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Secondary,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Success,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Danger,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Warning,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Info,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Light,
                    IsSolid = false
                },
                new IconViewModel()
                {
                    Icon = "heart",
                    Color = ColorEnum.Dark,
                    IsSolid = false
                },
            };
        }
    }
}
