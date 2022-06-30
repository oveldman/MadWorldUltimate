using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Services.Info.Interface;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Info
{
	public class StoryService : IStoryService
	{
        private readonly HttpClient _client;

        public StoryService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiAnonymous);
        }

        public async Task<ResponseStory> Get()
        {
            return await _client.GetFromJsonAsync<ResponseStory>($"GetStory") ?? new();
        }
    }
}

