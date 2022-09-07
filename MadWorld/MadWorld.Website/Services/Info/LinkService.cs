using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Extensions;
using MadWorld.Website.Services.Info.Interface;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Info
{
	public class LinkService : ILinkService
	{
        private readonly HttpClient _client;

        public LinkService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiAnonymous);
        }

        public async Task<List<LinkGroupDto>> GetAll()
        {
            var response = await _client.GetWithoutHttpRequestExceptionAsync($"GetLinks");
            if (!response?.IsSuccessStatusCode ?? true) return new List<LinkGroupDto>();
            var responseLinks = await response.Content.ReadFromJsonAsync<ResponseLinks>();
            return responseLinks?.Groups ?? new List<LinkGroupDto>();
        }
    }
}

