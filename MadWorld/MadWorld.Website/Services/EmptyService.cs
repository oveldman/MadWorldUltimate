﻿using System;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Links;
using MadWorld.Shared.Models.API.Users;
using MadWorld.Website.Services.Admin.Interfaces;
using MadWorld.Website.Services.Info.Interface;
using MadWorld.Website.Services.Interfaces;

namespace MadWorld.Website.Services
{
    public class EmptyService : IAccountService, IDownloadService, IDownloadAdminService, ILinkService, ILinkAdminService, IUserService
    {
        public Task<CommonResponse> DeleteDownload(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkGroupDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDto>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetCurrentAccountRoles()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseDownload> GetDownload(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MadWorld.Shared.Models.API.Downloads.DownloadDto>> GetDownloads()
        {
            throw new NotImplementedException();
        }

        public Task<MadWorld.Shared.Models.API.Links.ResponseLinks> GetLinkFromGroup(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LinkGroupAdminDto>> GetLinkGroups()
        {
            throw new NotImplementedException();
        }

        public Task<UserDetailDto> GetUser(string id)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse> SaveDownload(MadWorld.Shared.Models.API.Downloads.DownloadDto download)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse> SaveGroupLinks(List<LinkGroupAdminDto> linkGroups)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse> SaveLinks(LinkGroupAdminDto linkGroup)
        {
            throw new NotImplementedException();
        }

        public Task<CommonResponse> UpdateUser(UserDetailDto user)
        {
            throw new NotImplementedException();
        }

        Task<MadWorld.Shared.Models.API.Downloads.ResponseDownload> IDownloadAdminService.GetDownload(string id)
        {
            throw new NotImplementedException();
        }
    }
}
