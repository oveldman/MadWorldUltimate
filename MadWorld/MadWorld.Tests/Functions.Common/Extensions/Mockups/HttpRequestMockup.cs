using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MadWorld.Tests.General.Exceptions;
using Microsoft.AspNetCore.Http;

namespace MadWorld.Tests.Functions.Common.Extensions.Mockups
{
	public class HttpRequestMockup : HttpRequest
	{
		public HttpRequestMockup(Stream body)
		{
            Body = body;
		}

        public override HttpContext HttpContext => throw new TestFailedException();

        public override string Method { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override string Scheme { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override bool IsHttps { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override HostString Host { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override PathString PathBase { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override PathString Path { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override QueryString QueryString { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override IQueryCollection Query { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override string Protocol { get => throw new TestFailedException(); set => throw new TestFailedException(); }

        public override IHeaderDictionary Headers => throw new TestFailedException();

        public override IRequestCookieCollection Cookies { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override long? ContentLength { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public override string ContentType { get => throw new TestFailedException(); set => throw new TestFailedException(); }
        public sealed override Stream Body { get; set; }

        public override bool HasFormContentType => throw new TestFailedException();

        public override IFormCollection Form { get => throw new TestFailedException(); set => throw new TestFailedException(); }

        public override Task<IFormCollection> ReadFormAsync(CancellationToken cancellationToken = default)
        {
            throw new TestFailedException();
        }
    }
}

