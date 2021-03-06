using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace MadWorld.Functions.Common.Extensions
{
	public static class HttpRequestExtensions
	{
		public static async ValueTask<Option<T?>> GetBodyAsync<T>(this HttpRequest httpRequest)
        {
			string requestBody = await new StreamReader(httpRequest.Body).ReadToEndAsync();
			var body = JsonConvert.DeserializeObject<T>(requestBody);
			return body.SomeNotNull();
		}
	}
}

