using Blazor.Components.Bootstrap.Color;
using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Bootstrap.Spinner
{
    public class BaseSpinner : ComponentBase
    {
        [Parameter] public SpinnerType Type { get; set; }
        [Parameter] public BootstrapColor Color { get; set; }
        public Dictionary<BootstrapColor, string> SpinnerColors = new Dictionary<BootstrapColor, string>{
            {BootstrapColor.Danger,"text-danger"},
            {BootstrapColor.Info,"text-info"},
            {BootstrapColor.Primary,"text-primary"},
            {BootstrapColor.Success,"text-success"},
            {BootstrapColor.Warning,"text-warning"},
            {BootstrapColor.Dark,"text-dark"},
            {BootstrapColor.Light,"text-light"},
            {BootstrapColor.Secondary,"text-secondary"},
        };
        public Dictionary<SpinnerType, string> SpinnerTypes = new Dictionary<SpinnerType, string> {
            {SpinnerType.Border,"spinner-border"},
            {SpinnerType.Grow,"spinner-grow"}
        };
    }
}