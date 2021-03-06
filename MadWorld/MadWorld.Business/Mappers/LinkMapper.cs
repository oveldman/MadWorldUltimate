using System;
using AutoMapper;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using MadWorld.Shared.Models.API.Links;

namespace MadWorld.Business.Mappers
{
	public class LinkMapper : BaseMapTranslator, ILinkMapper
	{
        private LinkMapper() { }

        public static LinkMapper Create()
        {
            LinkMapper mapper = new();
            mapper.CreateMapper();
            return mapper;
        }

        public override MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => {
                CreateLinkGroupAndLinkGroupAdminDto(ref config);
                CreateLinkAndLinkAdminDto(ref config);
                CreateLinkGroupAndLinkGroupDto(ref config);
                CreateLinkAndLinkDto(ref config);
            });
        }

        private static void CreateLinkGroupAndLinkGroupAdminDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<LinkGroup, LinkGroupAdminDto>()
                .ForMember(d => d.Id, s => s.MapFrom(f => f.RowKey))
                .ReverseMap();
        }

        private static void CreateLinkAndLinkAdminDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<Link, LinkAdminDto>()
                .ForMember(d => d.Id, s => s.MapFrom(f => f.RowKey))
                .ReverseMap();
        }

        private static void CreateLinkGroupAndLinkGroupDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<LinkGroup, LinkGroupDto>()
                .ReverseMap();
        }

        private static void CreateLinkAndLinkDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<Link, LinkDto>()
                .ReverseMap();
        }
    }
}

