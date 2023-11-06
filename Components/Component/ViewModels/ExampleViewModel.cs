namespace Components.Component.ViewModels
{
    public class ExampleViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ViewPath { get; set; }
        public string[]? ModelLines { get; set; }
        public List<ComponentViewModel>? Components { get; set; }
        public bool WithSpace { get; set; } = true;
        public List<int> SpaceIndex { get; set; } = new List<int>();
    }
}
