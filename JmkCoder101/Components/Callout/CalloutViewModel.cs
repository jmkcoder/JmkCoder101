using JmkCoder101.Component.ViewModels;

namespace JmkCoder101.Components.Callout
{
    public partial class CalloutViewModel : ComponentViewModel
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public CalloutEnum CalloutType { get; set; }
    }
}