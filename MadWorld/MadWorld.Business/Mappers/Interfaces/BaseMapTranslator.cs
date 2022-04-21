using System;
using AutoMapper;

namespace MadWorld.Business.Mappers.Interfaces
{
	public abstract class BaseMapTranslator
	{
        private IMapper _mapper;

        public BaseMapTranslator()
        {
            MapperConfiguration config = LoadConfigMapper();
            _mapper = config.CreateMapper();
        }

        public abstract MapperConfiguration LoadConfigMapper();

        public Y Translate<T, Y>(T request)
        {
            return _mapper.Map<Y>(request);
        }
    }
}

