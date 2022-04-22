using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MadWorld.Functions.Common.Extentions
{
	public static class HttpRequestExtentions
	{
		public static async ValueTask<T> GetBodyAsync<T>(this HttpRequest httpRequest)
        {
			string requestBody = await new StreamReader(httpRequest.Body).ReadToEndAsync();
			return JsonConvert.DeserializeObject<T>(requestBody);
		}
	}
}

