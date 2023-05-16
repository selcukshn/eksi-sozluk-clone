using Blazor.Components.Bootstrap.Color;
using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Bootstrap.Alert
{
    public class BaseAlert : ComponentBase
    {
        [Parameter] public string? Message { get; set; }
        [Parameter] public BootstrapColor Color { get; set; }
        [Parameter] public bool Dismissible { get; set; }
        public Dictionary<BootstrapColor, string> AlertColors = new Dictionary<BootstrapColor, string>{
            {BootstrapColor.Danger,"alert-danger"},
            {BootstrapColor.Info,"alert-info"},
            {BootstrapColor.Primary,"alert-primary"},
            {BootstrapColor.Success,"alert-success"},
            {BootstrapColor.Warning,"alert-warning"},
            {BootstrapColor.Dark,"alert-dark"},
            {BootstrapColor.Light,"alert-light"},
            {BootstrapColor.Secondary,"alert-secondary"},
        };
    }
}