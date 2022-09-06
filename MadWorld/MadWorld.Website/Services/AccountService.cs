using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Account;
using MadWorld.Website.Services.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _client;

        public AccountService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiAuthorization);
        }

        public async Task<List<string>> GetCurrentAccountRoles()
        {
            var response = await _client.GetAsync("GetCurrentUserRoles");

            if (!response.IsSuccessStatusCode) return new List<string>();
            var responseRoles = await response.Content.ReadFromJsonAsync<ResponseRoles>();
            return responseRoles?.Roles ?? new List<string>();

        }
    }
}

