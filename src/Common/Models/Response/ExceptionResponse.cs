namespace Common.Models.Response
{
    public class ExceptionResponse : Response
    {
        public string? Detail { get; set; }
        public ExceptionResponse() { }
        public ExceptionResponse(string message) : base(message) { }
        public ExceptionResponse(string message, string detail) : base(message)
        {
            Detail = detail;
        }
    }
}