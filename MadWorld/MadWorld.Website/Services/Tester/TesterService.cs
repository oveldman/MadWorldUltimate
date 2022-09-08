using System.Net;
using MadWorld.Website.Extensions;
using MadWorld.Website.Services.Tester.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Tester;

public class TesterService : ITesterService
{
    private readonly HttpClient _client;

    public TesterService(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient(ApiTypes.MadWorldApiAnonymous);
    }
    
    public async Task<string> GetServiceUnavailable()
    {
        const int statusCode = (int)HttpStatusCode.ServiceUnavailable;
        var response = await _client.GetWithoutHttpRequestExceptionAsync($"GetStatusCode?StatusCode={statusCode}");
        return response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : string.Empty;
    }
}