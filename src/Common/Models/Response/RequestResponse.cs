namespace Common.Models.Response
{
    public class RequestResponse<T>
    where T : class, new()
    {
        public T Data { get; set; }
    }
}