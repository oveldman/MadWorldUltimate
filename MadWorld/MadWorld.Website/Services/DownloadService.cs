﻿using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
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

        public async Task<ResponseDownload> GetDownload(string id)
        {
            return await _client.GetFromJsonAsync<ResponseDownload>($"Download?id={id}") ?? new ResponseDownload();
        }
    }
}

