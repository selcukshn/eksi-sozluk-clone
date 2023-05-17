using Newtonsoft.Json;

namespace Common.Models.Response
{
    public class Response
    {
        public string? Message { get; set; }
        public ResponseStatus Status { get; set; }
        public bool IsSuccess => Status == ResponseStatus.Success ? true : false;
        private HttpResponseMessage HttpResponse { get; set; }
        public Response(ResponseStatus status)
        {
            Status = status;
        }
        public Response(ResponseStatus status, HttpResponseMessage httpResponse) : this(status)
        {
            HttpResponse = httpResponse;
        }
        public Response(ResponseStatus status, string message) : this(status)
        {
            Message = message;
        }

        public async Task<TModel> ResultAsync<TModel>()
        {
            return JsonConvert.DeserializeObject<TModel>(await HttpResponse.Content.ReadAsStringAsync());
        }
    }
}