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

        public TResponse Translate<TRequest, TResponse>(TRequest request)
        {
            return _mapper.Map<TResponse>(request);
        }

        public TResponse Translate<TRequest, TResponse>(TRequest request, TResponse baseObject)
        {
            return _mapper.Map(request, baseObject);
        }
    }
}

