using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Functions.Common.Extentions;
using MadWorld.Shared.Common;
using MadWorld.Tests.Functions.Common.Extentions.Mockups;
using Microsoft.AspNetCore.Http;

namespace MadWorld.Tests.Functions.Common.Extentions
{
	public class HttpRequestExtentionsTests
	{
		[Theory]
		[AutoDomainData]
		public async ValueTask GetBodyAsync_HttpRequest_Body(
			RequestMockup request)
		{
			// Test data
			Stream bodyStream = StreamConverter.Convert(request);

			// Setup
			HttpRequest httpRequest = new HttpRequestMockup(bodyStream);

			// Act
			RequestMockup requestResult = await httpRequest.GetBodyAsync<RequestMockup>();

			// Assert
			Assert.Equal(request.Test, requestResult.Test);

			// No Teardown
		}

		[Theory]
		[AutoDomainData]
		public async ValueTask GetBodyAsync_WrongHttpRequest_Empty(
			RequestWrongMockup request)
		{
			// Test data
			Stream bodyStream = StreamConverter.Convert(request);

			// Setup
			HttpRequest httpRequest = new HttpRequestMockup(bodyStream);

			// Act
			RequestMockup requestResult = await httpRequest.GetBodyAsync<RequestMockup>();

			// Assert
			Assert.Null(requestResult);

			// No Teardown
		}
	}
}


