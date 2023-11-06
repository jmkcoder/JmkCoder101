using Components.Common;
using Components.Component.ViewModels;

namespace Components.Badge
{
    public partial class BadgeViewModel : ComponentViewModel
    {
        public string? Text { get; set; }
        public ColorEnum Color { get; set; }
        public bool IsPill { get; set; }
    }
}