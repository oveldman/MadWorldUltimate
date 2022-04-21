using System;
using AutoMapper;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Users;

namespace MadWorld.Business.Mappers
{
    public class UserMapper : BaseMapTranslator, IUserMapper
    {
        public override MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => {
                CreateUserAndUserModel(ref config);
            });
        }

        private static void CreateUserAndUserModel(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<User, UserModel>()
                .ForMember(d => d.ID, s => s.MapFrom(f => f.RowKey));
        }
    }
}

