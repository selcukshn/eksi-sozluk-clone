namespace Common.Models.Response;

public class Response
{
    public string? Message { get; set; }
    public Response() { }
    public Response(string message)
    {
        Message = message;
    }
}