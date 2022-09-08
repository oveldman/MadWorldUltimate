using System.IO;
using System.Text;
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
    
    [Theory]
    [AutoDomainData]
    public async Task Run_RequestWithBody_ReboundRequest(
        string bodyText,
        Mock<HttpRequest> request,
        Mock<ILogger> logger)
    {
        // Test data
        var query = new QueryCollection();
        
        // Setup
        request.Setup(r => r.Body).Returns(new MemoryStream(Encoding.UTF8.GetBytes(bodyText)));
        request.Setup(r => r.Query).Returns(query);
        
        // Act
        var result = await GetRebound.Run(request.Object, logger.Object);

        // Assert
        Assert.Equal(bodyText, result);
        
        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public async Task Run_EmptyRequest_ReturnNoData(
        Mock<HttpRequest> request,
        Mock<ILogger> logger)
    {
        // No Test data

        // Setup
        request.Setup(r => r.Body).Returns(new MemoryStream());
        request.Setup(r => r.Query).Returns(new QueryCollection());
        
        // Act
        var result = await GetRebound.Run(request.Object, logger.Object);

        // Assert
        Assert.Equal("No data", result);
        
        // No Teardown
    }
}