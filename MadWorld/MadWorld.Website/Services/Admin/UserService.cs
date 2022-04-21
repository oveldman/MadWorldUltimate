using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Account;
using MadWorld.Shared.Models.API.Users;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Types;

namespace MadWorld.Website.Services.Admin
{
	public class UserService : IUserService
	{
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient(ApiTypes.MadWorldApiB2C);
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            ResponseUsers response = await _client.GetFromJsonAsync<ResponseUsers>("GetUsers") ?? new ResponseUsers();
            return response.Users;
        }
    }
}

