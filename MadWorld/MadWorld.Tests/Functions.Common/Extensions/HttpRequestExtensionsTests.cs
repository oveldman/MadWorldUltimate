using System.IO;
using MadWorld.Functions.Common.Extensions;
using MadWorld.Shared.Common;
using MadWorld.Tests.Functions.Common.Extensions.Mockups;
using Microsoft.AspNetCore.Http;

namespace MadWorld.Tests.Functions.Common.Extensions
{
	public class HttpRequestExtensionsTests
	{
		[Theory]
		[AutoDomainData]
		public async ValueTask GetBodyAsync_HttpRequest_Body(
			RequestMockup request)
		{
			// Test data
			var bodyStream = StreamConverter.Convert(request);

			// Setup
			HttpRequest httpRequest = new HttpRequestMockup(bodyStream);

			// Act
			var requestResult = await httpRequest.GetBodyAsync<RequestMockup>();

            // Assert
            Assert.Equal(request.Test, requestResult.ValueOr(new RequestMockup())?.Test);

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
			Option<RequestMockup?> requestResult = await httpRequest.GetBodyAsync<RequestMockup>();

			// Assert
			Assert.False(requestResult.HasValue);

			// No Teardown
		}
	}
}


