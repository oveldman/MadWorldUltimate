using System;
using AutoMapper;

namespace MadWorld.Business.Mappers.Interfaces
{
	public interface IMapTranslator
	{
		MapperConfiguration LoadConfigMapper();
		Y Translate<T, Y>(T request);
	}
}

