using System;
using AutoMapper;

namespace MadWorld.Business.Mappers.Interfaces
{
	public interface IMapTranslator
	{
		MapperConfiguration LoadConfigMapper();
		TResponse Translate<TRequest, TResponse>(TRequest request);
		TResponse Translate<TRequest, TResponse>(TRequest request, TResponse baseObject);
	}
}

