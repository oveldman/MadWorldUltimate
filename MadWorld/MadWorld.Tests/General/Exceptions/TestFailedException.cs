using System.Runtime.Serialization;

namespace MadWorld.Tests.General.Exceptions;

[Serializable]
public class TestFailedException : Exception
{
    public TestFailedException()
    {
    }
    
    protected TestFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}