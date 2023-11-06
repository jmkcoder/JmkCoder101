using Components.Common;
using Components.Component.ViewModels;

namespace Components.Callout
{
    public partial class CalloutViewModel : ComponentViewModel
    {
        public string? Title { get; set; }
        public string? Message { get; set; }
        public ColorEnum Color { get; set; }
    }
}