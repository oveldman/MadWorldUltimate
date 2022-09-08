using MadWorld.API.Anonymous.Tests;
using MadWorld.Shared.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.Tests.Api.Anonymous.Tests;

public class PingTests
{
    [Theory]
    [AutoDomainData]
    public void Run_EmptyGetRequest_PingString(
        Mock<HttpRequest> request,
        Mock<ILogger> logger
        )
    {
        // Test data
        const string testDate = "10-10-2022 10:10:10";
        var testDateTime = DateTime.Parse(testDate);

        // Setup
        SystemTime.SetDateTime(testDateTime);

        // Act
        var result = Ping.Run(request.Object, logger.Object);
        
        // Assert
        Assert.Equal("Ping: 10-10-2022 10:10:10", result);

        //No Teardown
        SystemTime.ResetDateTime();
    }
}