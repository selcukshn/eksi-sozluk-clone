using Blazor.Components.Bootstrap.Color;
using Blazor.Components.Bootstrap.Position;
using Microsoft.AspNetCore.Components;

namespace Blazor.Components.Bootstrap.Toast
{
    public class BaseToast : ComponentBase
    {
        [Parameter] public RenderFragment? ToastHeader { get; set; }
        [Parameter] public RenderFragment? ToastBody { get; set; }
        [Parameter] public BootstrapColor Color { get; set; } = BootstrapColor.Success;
        [Parameter] public BootstrapPosition Position { get; set; } = BootstrapPosition.TopEnd;
        public Dictionary<BootstrapColor, string> ToastColor = new Dictionary<BootstrapColor, string>{
            {BootstrapColor.Danger,"border-danger"},
            {BootstrapColor.Info,"border-info"},
            {BootstrapColor.Primary,"border-primary"},
            {BootstrapColor.Success,"border-success"},
            {BootstrapColor.Warning,"border-warning"},
            {BootstrapColor.Dark,"border-dark"},
            {BootstrapColor.Light,"border-light"},
            {BootstrapColor.Secondary,"border-secondary"},
        };
        public Dictionary<BootstrapPosition, string> ToastPosition = new Dictionary<BootstrapPosition, string>{
            {BootstrapPosition.Bottom,"bottom-0"},
            {BootstrapPosition.BottomEnd,"bottom-0 end-0"},
            {BootstrapPosition.BottomStart,"bottom-0 start-0"},
            {BootstrapPosition.End,"end-0"},
            {BootstrapPosition.Start,"start-0"},
            {BootstrapPosition.Top,"top-0"},
            {BootstrapPosition.TopEnd,"top-0 end-0"},
            {BootstrapPosition.TopStart,"top-0 end-0"},
        };
    }
}