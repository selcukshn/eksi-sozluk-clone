using Common.Models.Response;

namespace Blazor.Models
{
    public class ApplicationState
    {
        public ResponseStatus Status { get; set; }
        public string? Message { get; set; }
        public string? Detail { get; set; }
        public ApplicationState(ResponseStatus status)
        {
            Status = status;
        }
        public ApplicationState(ResponseStatus status, string message) : this(status)
        {
            Message = message;
        }

        public void SetResponse(RequestResponse response)
        {
            Status = response.Status;
            Message = response.Message;
            Detail = response.Detail;
        }
    }
}