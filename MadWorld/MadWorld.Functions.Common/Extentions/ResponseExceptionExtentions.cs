using System;
using MadWorld.Shared.Models.API.Exception;
using Newtonsoft.Json;

namespace MadWorld.Functions.Common.Extentions
{
	public static class ResponseExceptionExtentions
	{
		public static string ToJson(this ResponseException response)
        {
			return JsonConvert.SerializeObject(response);
        }
	}
}

