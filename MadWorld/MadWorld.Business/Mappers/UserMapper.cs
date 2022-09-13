using System;
using AutoMapper;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Mappers
{
    public sealed class UserMapper : BaseMapTranslator, IUserMapper
    {
        private UserMapper() { }

        public static UserMapper Create()
        {
            UserMapper mapper = new();
            mapper.CreateMapper();
            return mapper;
        }

        public override MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => {
                CreateUserAndUserDto(ref config);
                CreateUserAndUserDetailDto(ref config);
            });
        }

        private static void CreateUserAndUserDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDto>()
                .ForMember(d => d.ID, s => s.MapFrom(f => f.RowKey));
        }

        private static void CreateUserAndUserDetailDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserDetailDto>()
                .ForMember(d => d.ID, s => s.MapFrom(f => f.RowKey))
                .ReverseMap();
        }
    }
}

