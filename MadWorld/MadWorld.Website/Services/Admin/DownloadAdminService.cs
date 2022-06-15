using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Common;
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

        public async Task<ResponseDownload> GetDownload(string id, bool getBody)
        {
            return await _client.GetFromJsonAsync<ResponseDownload>($"GetDownload?id={id}&getBody={getBody}") ?? new();
        }

        public async Task<CommonResponse> SaveDownload(DownloadDto download)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync($"SaveDownload", download);
            return await response.Content.ReadFromJsonAsync<CommonResponse>() ?? new();
        }

        public async Task<CommonResponse> DeleteDownload(string id)
        {
            var response = await _client.DeleteAsync($"DeleteDownload?id={id}") ?? new();
            return await response.Content.ReadFromJsonAsync<CommonResponse>() ?? new CommonResponse();
        }
    }
}

