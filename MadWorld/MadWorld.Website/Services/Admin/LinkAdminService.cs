using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Admin
{
	public class LinkAdminService : ILinkAdminService
	{
        private readonly HttpClient _client;

        public LinkAdminService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiB2C);
        }

        public async Task<ResponseLinks> GetLinkFromGroup(string id)
        {
            return await _client.GetFromJsonAsync<ResponseLinks>($"GetLinks?id={id}") ?? new();
        }

        public async Task<List<LinkGroupAdminDto>> GetLinkGroups()
        {
            ResponseLinkGroups response = await _client.GetFromJsonAsync<ResponseLinkGroups>("GetLinkGroups") ?? new();
            return response.LinkGroups;
        }

        public async Task<CommonResponse> SaveGroupLinks(List<LinkGroupAdminDto> linkGroups)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"SaveLinkGroups", linkGroups);
            return await response.Content.ReadFromJsonAsync<CommonResponse>() ?? new();
        }

        public async Task<CommonResponse> SaveLinks(LinkGroupAdminDto linkGroup)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync($"SaveLinks", linkGroup);
            return await response.Content.ReadFromJsonAsync<CommonResponse>() ?? new();
        }
    }
}

