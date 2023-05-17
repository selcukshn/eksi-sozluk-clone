using System.Net;
using Common.Models.Response;

namespace Blazor.Services.Request
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient Client;

        public RequestService(HttpClient client)
        {
            Client = client;
        }

        public async Task<Response> GetAsync(string address)
        {
            try
            {
                var response = await Client.GetAsync(address);
                if (response.IsSuccessStatusCode)
                    return new Response(ResponseStatus.Success, response);
                else
                {
                    string message = await response.Content.ReadAsStringAsync();
                    if (response.StatusCode == HttpStatusCode.NotFound)
                        return new Response(ResponseStatus.NotFound, message);
                    else
                        return new Response(ResponseStatus.Error, message);
                }
            }
            catch (Exception exception)
            {
                return new Response(ResponseStatus.Error, exception.Message);
            }
        }
    }
}