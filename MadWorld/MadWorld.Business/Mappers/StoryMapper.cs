using AutoMapper;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Stories;

namespace MadWorld.Business.Mappers;

public class StoryMapper : BaseMapTranslator, IStoryMapper
{
    private StoryMapper() { }

    public static StoryMapper Create()
    {
        StoryMapper mapper = new();
        mapper.CreateMapper();
        return mapper;
    }
    
    public override MapperConfiguration LoadConfigMapper()
    {
        return new MapperConfiguration(config => {
            CreateStoryAndResponse(ref config);
        });
    }
    
    private static void CreateStoryAndResponse(ref IMapperConfigurationExpression config)
    {
        config.CreateMap<Story, ResponseStory>()
            .ForMember(d => d.Id, s => s.MapFrom(f => f.RowKey))
            .ReverseMap();
    }
}