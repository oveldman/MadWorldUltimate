using System;
using AutoMapper;

namespace MadWorld.Business.Mappers.Interfaces
{
	public abstract class BaseMapTranslator
	{
        private IMapper _mapper;

        protected BaseMapTranslator()
        {
            _mapper = new MapperConfiguration(config => { }).CreateMapper();
        }

        public void CreateMapper()
        {
            MapperConfiguration config = LoadConfigMapper();
            _mapper = config.CreateMapper();
        }

        public abstract MapperConfiguration LoadConfigMapper();

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

