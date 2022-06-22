using System;
using MadWorld.Shared.Models.API.Exception;
using Newtonsoft.Json;

namespace MadWorld.Functions.Common.Extensions
{
	public static class ResponseExceptionExtensions
	{
		public static string ToJson(this ResponseException response)
        {
			return JsonConvert.SerializeObject(response);
        }
	}
}

