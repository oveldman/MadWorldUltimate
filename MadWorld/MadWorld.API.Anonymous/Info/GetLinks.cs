using System;
using MadWorld.Functions.Common.Info;
using MadWorld.Shared.Models.AnonymousAPI.Info;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace MadWorld.API.Anonymous.Info
{
    public class GetLinks
    {
        [FunctionName(nameof(GetLinks))]
        public static ResponseLinks Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, RequestType.Get, Route = null)] HttpRequest req,
            ILogger log)
        {
            return new ResponseLinks
            {
                Groups = new()
                {
                    new LinkGroupDto
                    {
                        Name = "Nuget Packages",
                        Links = new()
                        {
                            new LinkDto
                            {
                                Name = "BlazorDownloadFile",
                                Url = "https://github.com/arivera12/BlazorDownloadFile/"
                            },
                            new LinkDto
                            {
                                Name = "BlazorTable",
                                Url = "https://github.com/IvanJosipovic/BlazorTable/"
                            },
                            new LinkDto
                            {
                                Name = "HTML Agility Pack",
                                Url = "https://html-agility-pack.net/"
                            }
                        }
                    },
                    new LinkGroupDto
                    {
                        Name = "CdnJS",
                        Links = new()
                        {
                            new LinkDto
                            {
                                Name = "Font-Awesome",
                                Url = "https://fontawesome.com/"
                            },
                            new LinkDto
                            {
                                Name = "Monaco Editor",
                                Url = "https://microsoft.github.io/monaco-editor/"
                            }
                        }
                    },
                    new LinkGroupDto
                    {
                        Name = "Sources",
                        Links = new()
                        {
                            new LinkDto
                            {
                                Name = "Azure Functions Proxies",
                                Url = "https://docs.microsoft.com/en-us/azure/azure-functions/functions-proxies#modify-requests-responses/"
                            },
                            new LinkDto
                            {
                                Name = "Dotnet 6",
                                Url = "https://docs.microsoft.com/en-us/dotnet/core/compatibility/6.0/"
                            },
                            new LinkDto
                            {
                                Name = "Convert Cert pem to pfx",
                                Url = "https://tomascrespo.com/convert-letsencrypt-pem-certificate-to-pfx/"
                            },
                            new LinkDto
                            {
                                Name = "Chrissainty - Blazor drag and drop",
                                Url = "https://chrissainty.com/investigating-drag-and-drop-with-blazor/"
                            },
                        }
                    },
                    new LinkGroupDto
                    {
                        Name = "Security",
                        Links = new()
                        {
                            new LinkDto
                            {
                                Name = "Let's Encrypt",
                                Url = "https://letsencrypt.org/"
                            },
                            new LinkDto
                            {
                                Name = "SSL Labs",
                                Url = "https://www.ssllabs.com/"
                            },
                            new LinkDto
                            {
                                Name = "Security Headers",
                                Url = "https://securityheaders.com/"
                            }
                        }
                    },
                    new LinkGroupDto
                    {
                        Name = "Tools",
                        Links = new()
                        {
                            new LinkDto
                            {
                                Name = "DNS Lookup",
                                Url = "https://toolbox.googleapps.com/apps/dig/#TXT/_acme-challenge.api.mad-world.nl."
                            }
                        }
                    }
                }
            };
        }
    }
}

