using System.Net;
using Common.Models.Response;
using Newtonsoft.Json;

namespace Blazor.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient Client;

        public RequestService(HttpClient client)
        {
            Client = client;
        }

        public async Task<RequestResponse> GetAsync(string address)
        {
            try
            {
                var response = await Client.GetAsync(address);
                if (response.IsSuccessStatusCode)
                    return new RequestResponse(ResponseStatus.Success, response);
                else
                {
                    var exception = JsonConvert.DeserializeObject<ExceptionResponse>(await response.Content.ReadAsStringAsync()) ?? new ExceptionResponse("Bilinmeyen hata");
                    return new RequestResponse()
                    {
                        Message = exception.Message,
                        Status = response.StatusCode == HttpStatusCode.NotFound ? ResponseStatus.NotFound : ResponseStatus.Error
                    };
                }
            }
            catch (Exception exception)
            {
                return new RequestResponse(ResponseStatus.Error, exception.Message);
            }
        }
    }
}