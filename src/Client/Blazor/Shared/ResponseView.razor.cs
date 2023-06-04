using Blazor.Models;
using Microsoft.AspNetCore.Components;

namespace Blazor.Shared
{
    public class ResponseViewRazor : ComponentBase
    {
        [Parameter] public ApplicationState State { get; set; }
        [Parameter] public RenderFragment? ResponseWaiting { get; set; }
        [Parameter] public RenderFragment? ResponseSuccess { get; set; }
        [Parameter] public RenderFragment? ResponseNotFound { get; set; }
        [Parameter] public RenderFragment? ResponseError { get; set; }
        [Parameter] public RenderFragment? ResponseNone { get; set; }
    }
}