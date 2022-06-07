using System;
using AutoMapper;

namespace MadWorld.Business.Mappers.Interfaces
{
	public class BaseMapTranslator
	{
        private readonly IMapper _mapper;

        public BaseMapTranslator()
        {
            MapperConfiguration config = LoadConfigMapper();
            _mapper = config.CreateMapper();
        }

        public virtual MapperConfiguration LoadConfigMapper()
        {
            return new MapperConfiguration(config => { });
        }

        public Y Translate<T, Y>(T request)
        {
            return _mapper.Map<Y>(request);
        }

        public Y Translate<T, Y>(T request, Y baseObject)
        {
            return _mapper.Map(request, baseObject);
        }
    }
}

