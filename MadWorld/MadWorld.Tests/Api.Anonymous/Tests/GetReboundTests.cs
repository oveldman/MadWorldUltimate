using System.IO;
using MadWorld.API.Anonymous.Tests;
using MadWorld.Functions.Common.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace MadWorld.Tests.Api.Anonymous.Tests;

public class GetReboundTests
{
    [Theory]
    [AutoDomainData]
    public async Task Run_RequestWithQueryString_ReboundRequest(
        string queryItem,
        Mock<HttpRequest> request,
        Mock<ILogger> logger)
    {
        // Test data
        var store = new Dictionary<string, StringValues>()
        {
            { QueryKeys.Request, new StringValues(queryItem) }
        };
        var query = new QueryCollection(store);
        
        // Setup
        request.Setup(r => r.Body).Returns(new MemoryStream());
        request.Setup(r => r.Query).Returns(query);
        
        // Act
        var result = await GetRebound.Run(request.Object, logger.Object);

        // Assert
        Assert.Equal(queryItem, result);
        
        // No Teardown
    }
}