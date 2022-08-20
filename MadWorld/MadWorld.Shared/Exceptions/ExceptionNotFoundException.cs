using System.Runtime.Serialization;

namespace MadWorld.Shared.Exceptions;

[Serializable]
public class ExceptionNotFoundException : Exception
{
    public ExceptionNotFoundException()
    {
    }
    
    protected ExceptionNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}