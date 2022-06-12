using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Downloads;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Admin
{
    public class DownloadAdminService : IDownloadAdminService
    {
        private readonly HttpClient _client;

        public DownloadAdminService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiB2C);
        }

        public async Task<List<DownloadDto>> GetDownloads()
        {
            ResponseDownloads response = await _client.GetFromJsonAsync<ResponseDownloads>($"GetDownloads") ?? new();
            return response.Downloads;
        }
    }
}

