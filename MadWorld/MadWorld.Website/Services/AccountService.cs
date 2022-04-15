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
            ResponseRoles response = await _client.GetFromJsonAsync<ResponseRoles>("GetCurrentUserRoles") ?? new ResponseRoles();
            return response.Roles;
        }
    }
}

