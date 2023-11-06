using JmkCoder101.Component.ViewModels;

namespace JmkCoder101.Components.Alert
{
    public partial class AlertViewModel : ComponentViewModel
    {
        public string? Text { get; set; }
        public AlertEnum AlertType { get; set; }
    }
}
