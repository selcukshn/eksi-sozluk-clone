namespace Common.Models.Response
{
    public class ExceptionResponse : Response
    {
        public ExceptionResponse() { }
        public ExceptionResponse(string message) : base(message) { }
    }
}