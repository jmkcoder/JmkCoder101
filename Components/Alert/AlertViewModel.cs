using Components.Component.ViewModels;

namespace Components.Alert
{
    public partial class AlertViewModel : ComponentViewModel
    {
        public string? Text { get; set; }
        public AlertEnum AlertType { get; set; }
    }
}
