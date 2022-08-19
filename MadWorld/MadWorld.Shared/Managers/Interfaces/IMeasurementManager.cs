using System;
using MadWorld.Shared.Enums;

namespace MadWorld.Shared.Managers.Interfaces
{
    public interface IMeasurementManager
    {
        double ConvertLength(double startValue, MeasurementType lengthTypeFrom, MeasurementType lengthTypeTo);
    }
}

