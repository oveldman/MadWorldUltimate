using System.IO;
using MadWorld.API.Anonymous.Tests;
using MadWorld.Functions.Common.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace MadWorld.Tests.Api.Anonymous;

public class GetStatusCodeTests
{
    [Theory]
    [AutoDomainInlineData("200", 200)]
    [AutoDomainInlineData("403", 403)]
    [AutoDomainInlineData("503", 503)]
    public async Task Run_StatusCode_ThrowError(string statusCode, int expectedStatusCode)
    {
        // Test data
        var store = new Dictionary<string, StringValues>()
        {
            { QueryKeys.StatusCode, new StringValues(statusCode) }
        };
        var query = new QueryCollection(store);

        // Setup
        var request = new Mock<HttpRequest>();
        request.Setup(r => r.Body).Returns(new MemoryStream());
        request.Setup(r => r.Query).Returns(query);
        var logger = new Mock<ILogger>();
        var getStatusCode = new GetStatusCode();
        
        // Act
        var result = await getStatusCode.Run(request.Object, logger.Object);
        var statusCodeResult = result as StatusCodeResult;

        // Assert
        Assert.NotNull(statusCodeResult);
        Assert.Equal(expectedStatusCode, statusCodeResult.StatusCode);

        //No Teardown
    }
}