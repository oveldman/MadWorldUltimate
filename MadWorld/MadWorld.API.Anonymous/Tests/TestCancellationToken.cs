using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MadWorld.Functions.Common.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Tests;

public class TestCancellationToken
{
    private const int DefaultWaitSeconds = 1;
    private const int MaximumWaitSeconds = 10;
    
    [FunctionName(nameof(TestCancellationToken))]
    public static async Task<string> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, RequestType.Delete, RequestType.Post, RequestType.Put, Route = null)] HttpRequest req,
        ILogger log)
    {
        var cancellationToken = req.HttpContext.RequestAborted;
        var seconds = await new StreamReader(req.Body).ReadToEndAsync();
        if (string.IsNullOrEmpty(seconds))
        {
            seconds = req.Query[QueryKeys.WaitSeconds];
        }

        try
        {
            var secondsWaited = await WaitSeconds(seconds, cancellationToken);
            return $"Waited for {secondsWaited} seconds";
        }
        catch (TaskCanceledException)
        {
            return "Task was cancelled before it could complete";
        }
    }

    private static async Task<int> WaitSeconds(string seconds, CancellationToken cancellationToken)
    {
        var secondsToWait = int.TryParse(seconds, out var secondsParsed) ? secondsParsed : DefaultWaitSeconds;
        secondsToWait = CheckForMaximumSeconds(secondsToWait);
        var milliseconds = secondsToWait * 1000;
        await Task.Delay(milliseconds, cancellationToken);
        return secondsToWait;
    }

    private static int CheckForMaximumSeconds(int secondsToWait)
    {
        return secondsToWait < MaximumWaitSeconds ? secondsToWait : MaximumWaitSeconds;
    }
}