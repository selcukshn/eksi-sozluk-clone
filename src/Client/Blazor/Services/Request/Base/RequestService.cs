using System.Net;
using System.Net.Http.Json;
using Common.Models.Response;
using Newtonsoft.Json;

namespace Blazor.Services.Request.Base
{
    public class RequestService : IRequestService
    {
        protected readonly HttpClient Client;
        public RequestService(HttpClient client)
        {
            Client = client;
        }

        public async Task<RequestResponse> GetAsync(string address)
        {
            return await RequestAsync(async c => await c.GetAsync(address));
        }
        public async Task<RequestResponse> PostAsync(string address, object body)
        {
            return await RequestAsync(async c => await c.PostAsync(address, JsonContent.Create(body)));
        }
        private async Task<RequestResponse> RequestAsync(Func<HttpClient, Task<HttpResponseMessage>> request)
        {
            try
            {
                var response = await request(Client);
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