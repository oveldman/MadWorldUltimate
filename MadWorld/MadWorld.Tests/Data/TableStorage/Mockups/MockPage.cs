using System;
using Azure;
using MadWorld.Tests.General.Exceptions;

namespace MadWorld.Tests.Data.TableStorage.Mockups
{
    public class MockPage<T> : Page<T>
    {
        public MockPage(List<T> items)
        {
            Values = items;
        }

        public override IReadOnlyList<T> Values { get; }

        public override string? ContinuationToken => throw new TestFailedException();

        public override Response GetRawResponse()
        {
            throw new TestFailedException();
        }
    }
}

