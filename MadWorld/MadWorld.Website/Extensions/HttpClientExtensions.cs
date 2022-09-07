using System.Net;

namespace MadWorld.Website.Extensions;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> GetWithoutHttpRequestExceptionAsync(this HttpClient client, string? requestUri)
    {
        try
        {
            return await client.GetAsync(requestUri);
        }
        catch (HttpRequestException exception)
        {
            if (exception.StatusCode != null) throw;
            
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.ServiceUnavailable
            };
        }
    }
}