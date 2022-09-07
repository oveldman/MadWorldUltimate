using System.Net;
using System.Net.Http;
using System.Threading;
using MadWorld.Website.Extensions;
using Moq.Protected;

namespace MadWorld.Tests.Website.Extensions;

public class HttpClientExtensions
{
    [Theory]
    [AutoDomainInlineData(HttpStatusCode.OK, HttpStatusCode.OK)]
    [AutoDomainInlineData(HttpStatusCode.ServiceUnavailable, HttpStatusCode.ServiceUnavailable)]
    public async Task GetWithoutHttpRequestExceptionAsync_Url_GetResponse(
        HttpStatusCode testcase,
        HttpStatusCode expected,
        Mock<HttpMessageHandler> handler
        )
    {
        // Test data
        var response = new HttpResponseMessage
        {
            StatusCode = testcase
        };

        // Setup
        handler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(response)
            .Verifiable();
        
        var httpClient = new HttpClient(handler.Object);

        // Act
        var result = await httpClient.GetWithoutHttpRequestExceptionAsync("https://www.TestUrl.nl");

        // Assert
        Assert.Equal(expected, result.StatusCode);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public async Task GetWithoutHttpRequestExceptionAsync_Url_ServerNotRunning(
        Mock<HttpMessageHandler> handler)
    {
        // Test data
        var exception = new HttpRequestException("Not Found", new Exception(), null);

        // Setup
        handler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(exception)
            .Verifiable();
        
        var httpClient = new HttpClient(handler.Object);

        // Act
        var result = await httpClient.GetWithoutHttpRequestExceptionAsync("https://www.TestUrl.nl");

        // Assert
        Assert.Equal(HttpStatusCode.ServiceUnavailable, result.StatusCode);

        // No Teardown
    }
    
    [Theory]
    [AutoDomainData]
    public async Task GetWithoutHttpRequestExceptionAsync_Url_ThrowHttpRequestExceptionWithStatusCode(
        Mock<HttpMessageHandler> handler)
    {
        // Test data
        var exception = new HttpRequestException("Crash", new Exception(), HttpStatusCode.InternalServerError);

        // Setup
        handler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ThrowsAsync(exception)
            .Verifiable();
        
        var httpClient = new HttpClient(handler.Object);

        // Act & Assert
        var result = await Assert.ThrowsAsync<HttpRequestException>(() => httpClient.GetWithoutHttpRequestExceptionAsync("https://www.TestUrl.nl"));
        Assert.Equal(HttpStatusCode.InternalServerError, result.StatusCode);
        
        // No Teardown
    }
}