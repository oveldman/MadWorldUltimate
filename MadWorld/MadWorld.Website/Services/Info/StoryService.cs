using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Website.Extensions;
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
            var response = await _client.GetWithoutHttpRequestExceptionAsync($"GetStory");
            
            if (!response?.IsSuccessStatusCode ?? true) return new ResponseStory();
            return await response.Content.ReadFromJsonAsync<ResponseStory>() ?? new ResponseStory();
        }
    }
}

