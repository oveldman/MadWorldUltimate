using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MadWorld.API.Attributes;
using MadWorld.Shared.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace MadWorld.API.Admin.UserManagement
{
    public static class GetUsers
    {
        [AuthorizeFunction(RoleTypes.Adminstrator)]
        [FunctionName("GetUsers")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            var identity = req?.HttpContext?.User?.Identity as ClaimsIdentity;
            string email = identity?.Claims?.FirstOrDefault(c => c.Type == "emails")?.Value ?? string.Empty;
            string responseMessage = $"You got some users and you log in as: {email}";

            return new OkObjectResult(responseMessage);
        }
    }
}

