using Components.Common.Enums;
using Components.Component.ViewModels;

namespace Components.Icon
{
    public partial class IconViewModel : ComponentViewModel
    {
        public string? Icon { get; set; }
        public ColorEnum Color { get; set; }
        public SizeEnum Size { get; set; } = SizeEnum.lg;
        public bool IsSolid { get; set; }
    }
}
