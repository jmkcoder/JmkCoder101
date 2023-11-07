using Components.Common;
using Components.Component.ViewModels;

namespace Components.Alert
{
    public partial class AlertViewModel : ComponentViewModel
    {
        public string? Text { get; set; }
        public ColorEnum Color { get; set; }
        public bool IsDismissible { get; set; }
    }
}
