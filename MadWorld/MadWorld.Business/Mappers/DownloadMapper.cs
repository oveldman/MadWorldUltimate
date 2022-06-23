using System;
using AutoMapper;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;
using MadWorld.Shared.Models.API.Downloads;

namespace MadWorld.Business.Mappers
{
	public class DownloadMapper : BaseMapTranslator, IDownloadMapper
	{
        private DownloadMapper() { }

        public static DownloadMapper Create()
        {
            DownloadMapper mapper = new();
            mapper.CreateMapper();
            return mapper;
        }

        public override MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => {
                CreateDownloadAndDownloadDto(ref config);
                CreateDownloadAndResponseDownload(ref config);
                CreateDownloadAndDownloadAnonymousDto(ref config);
            });
        }

        private static void CreateDownloadAndDownloadDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<Download, DownloadDto>()
                .ForMember(d => d.Id, s => s.MapFrom(f => f.RowKey))
                .ForMember(d => d.Created, s => s.MapFrom(f => f.Timestamp))
                .ReverseMap();
        }

        private static void CreateDownloadAndResponseDownload(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<Download, ResponseDownloadAnonymous>()
                .ReverseMap();
        }

        private static void CreateDownloadAndDownloadAnonymousDto(ref IMapperConfigurationExpression config)
        {
            config.CreateMap<Download, DownloadAnonymousDto>()
                .ForMember(d => d.Id, s => s.MapFrom(f => f.RowKey))
                .ReverseMap();
        }
    }
}

