using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using MadWorld.Website.Extensions;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services
{
	public class DownloadService : IDownloadService
	{
        private readonly HttpClient _client;

        public DownloadService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiAnonymous);
        }

        public async Task<ResponseDownloadAnonymous> GetDownload(string id)
        {
            var response = await _client.GetWithoutHttpRequestExceptionAsync($"Download?id={id}");
            
            if (!response?.IsSuccessStatusCode ?? true) return new ResponseDownloadAnonymous();
            return await response.Content.ReadFromJsonAsync<ResponseDownloadAnonymous>() ?? new ResponseDownloadAnonymous();
        }

        public async Task<ResponseDownloadsAnonymous> GetDownloads()
        {
            var response = await _client.GetAsync($"GetDownloads");
            
            if (!response?.IsSuccessStatusCode ?? true) return new ResponseDownloadsAnonymous();
            return await response.Content.ReadFromJsonAsync<ResponseDownloadsAnonymous>() ?? new ResponseDownloadsAnonymous();
        }
    }
}

