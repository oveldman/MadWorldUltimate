using System;
using Azure;

namespace MadWorld.Tests.Data.TableStorage.Mockups
{
    public class MockPage<T> : Page<T>
    {
        public MockPage(List<T> items)
        {
            Values = items;
        }

        public override IReadOnlyList<T> Values { get; }

        public override string? ContinuationToken => throw new NotImplementedException();

        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }
    }
}

