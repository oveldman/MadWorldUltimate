using System.Net;
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
        return await _client.GetStringAsync($"GetStatusCode?StatusCode={statusCode}") ?? string.Empty;
    }
}