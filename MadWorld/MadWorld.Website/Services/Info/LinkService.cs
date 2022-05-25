using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Info;
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
            var response = await _client.GetFromJsonAsync<ResponseLinks>($"GetLinks") ?? new ResponseLinks();
            return response.Groups;
        }
    }
}

