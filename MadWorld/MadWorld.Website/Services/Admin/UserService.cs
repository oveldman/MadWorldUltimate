using System;
using System.Net.Http.Json;
using MadWorld.Shared.Models.API.Account;
using MadWorld.Shared.Models.API.Common;
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

        public async Task<List<UserDto>> GetAllUsers()
        {
            ResponseUsers response = await _client.GetFromJsonAsync<ResponseUsers>("GetUsers") ?? new();
            return response.Users;
        }

        public async Task<UserDetailDto> GetUser(string id)
        {
            ResponseUser response = await _client.GetFromJsonAsync<ResponseUser>($"GetUser?id={id}") ?? new();
            return response.User;
        }

        public async Task<CommonResponse> UpdateUser(UserDetailDto user)
        {
            RequestUser request = new()
            {
                User = user
            };

            HttpResponseMessage response = await _client.PutAsJsonAsync($"SaveUser", request);
            return await response.Content.ReadFromJsonAsync<CommonResponse>() ?? new();
        }
    }
}

