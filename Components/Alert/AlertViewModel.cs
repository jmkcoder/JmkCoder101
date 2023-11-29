using Components.Common.Enums;
using Components.Component.ViewModels;
using Components.Icon;

namespace Components.Alert
{
    public partial class AlertViewModel : ComponentViewModel
    {
        public string? Text { get; set; }
        public ColorEnum Color { get; set; }
        public bool IsDismissible { get; set; }
        public IconViewModel? Icon { get; set; }
    }
}
