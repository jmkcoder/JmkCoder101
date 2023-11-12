using Components.Common;
using Components.Component.ViewModels;

namespace Components.Icon
{
    public partial class IconViewModel : ComponentViewModel
    {
        public string? Icon { get; set; }
        public ColorEnum Color { get; set; }
        public bool IsSolid { get; set; }
    }
}
