using System.Runtime.Serialization;

namespace MadWorld.Shared.Exceptions;

[Serializable]
public class InternalServerErrorException : Exception
{
    public InternalServerErrorException(string message) : base(message)
    {
    }

    protected InternalServerErrorException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}