using Newtonsoft.Json;

namespace Common.Models.Response;

public class RequestResponse : Response
{
    public ResponseStatus Status { get; set; }
    public string? Detail { get; set; }
    private HttpResponseMessage? HttpResponse { get; set; }
    public bool IsSuccess => Status == ResponseStatus.Success ? true : false;
    public RequestResponse() { }
    public RequestResponse(string message) : base(message) { }
    public RequestResponse(ResponseStatus status)
    {
        Status = status;
    }
    public RequestResponse(ResponseStatus status, HttpResponseMessage httpResponse) : this(status)
    {
        HttpResponse = httpResponse;
    }
    public RequestResponse(ResponseStatus status, string message) : base(message)
    {
        Status = status;
    }

    public async Task<TModel?> ResultAsync<TModel>()
    {
        if (HttpResponse == null)
            return default;
        return JsonConvert.DeserializeObject<TModel>(await HttpResponse.Content.ReadAsStringAsync());
    }
}