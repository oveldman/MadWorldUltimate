using System;
using MadWorld.Shared.Enums;

namespace MadWorld.Shared.Managers.Interfaces
{
    public interface IMeasurementConverter
    {
        double ConvertLength(double startValue, MeasurementType lengthTypeFrom, MeasurementType lengthTypeTo);
    }
}

