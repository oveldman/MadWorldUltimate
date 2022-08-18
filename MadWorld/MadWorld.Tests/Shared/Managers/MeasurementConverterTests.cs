using System;
using MadWorld.Shared.Common;
using System.IO;
using MadWorld.Shared.Managers;
using MadWorld.Shared.Enums;
using Microsoft.Azure.WebJobs;

namespace MadWorld.Tests.Shared.Managers
{
	public class MeasurementConverterTests
	{

        [Theory]
        [AutoDomainData]
        public void ConvertLength_DoubleUnknownToFeet(MeasurementConverter converter)
        {
            // No Test data
            const double startValue = 1.0;
            const MeasurementType measureFrom = MeasurementType.Unknown;
            const MeasurementType measureTo = MeasurementType.Feet;

            // No Setup

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => converter.ConvertLength(startValue, measureFrom, measureTo));

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData(MeasurementType.Feet)]
        [AutoDomainInlineData(MeasurementType.Meter)]
        public void ConvertLength_DoubleMeasureToUnknown(MeasurementType measureFrom, MeasurementConverter converter)
        {
            // No Test data
            const double startValue = 1.0;
            const MeasurementType measureTo = MeasurementType.Unknown;

            // No Setup

            // Act & Assert
            Assert.Throws<NotImplementedException>(() => converter.ConvertLength(startValue, measureFrom, measureTo));

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData(1.0)]
        [AutoDomainInlineData(10.0)]
        public void ConvertLength_DoubleFeetToFeet_double(double startValue, MeasurementConverter converter)
        {
            // No Test data
            const MeasurementType measureFrom = MeasurementType.Feet;
            const MeasurementType measureTo = MeasurementType.Feet;

            // No Setup

            // Act
            double result = converter.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(startValue, result);

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData(1.0, 0.30480370641307)]
        [AutoDomainInlineData(3.2808, 1.0)]
        public void ConvertLength_DoubleFeetToMeter_double(double startValue, double expectedResult, MeasurementConverter converter)
        {
            // No Test data
            const MeasurementType measureFrom = MeasurementType.Feet;
            const MeasurementType measureTo = MeasurementType.Meter;

            // No Setup

            // Act
            double result = converter.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(expectedResult, result);

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData(1.0, 3.2808)]
        [AutoDomainInlineData(0.30480370641307, 1.0)]
        public void ConvertLength_DoubleMeterToFeet_double(double startValue, double expectedResult, MeasurementConverter converter)
        {
            // No Test data
            const MeasurementType measureFrom = MeasurementType.Meter;
            const MeasurementType measureTo = MeasurementType.Feet;

            // No Setup

            // Act
            double result = converter.ConvertLength(startValue, measureFrom, measureTo);

            // Assert
            Assert.Equal(expectedResult, result);

            // No Teardown
        }
    }
}

