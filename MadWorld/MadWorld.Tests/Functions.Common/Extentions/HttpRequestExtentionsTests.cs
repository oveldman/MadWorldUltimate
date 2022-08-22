using System;
using System.IO;
using System.Threading.Tasks;
using MadWorld.Functions.Common.Extensions;
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
			Option<RequestMockup?> requestResult = await httpRequest.GetBodyAsync<RequestMockup>();

            // Assert
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            Assert.Equal(request.Test, requestResult.ValueOr(new RequestMockup()).Test);
#pragma warning restore CS8602 // Dereference of a possibly null reference.

            // No Teardown
        }

		[Theory]
		[AutoDomainData]
		public async ValueTask GetBodyAsync_WrongHttpRequest_Empty(
			RequestWrongMockup request)
		{
			// Test data
			Stream bodyStream = StreamConverter.Convert(request) ?? new MemoryStream();

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


