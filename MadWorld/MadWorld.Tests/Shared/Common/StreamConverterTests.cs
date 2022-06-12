using System;
using System.IO;
using MadWorld.Shared.Common;
using MadWorld.Tests.Shared.Common.Mockups;

namespace MadWorld.Tests.Shared.Common
{
	public class StreamConverterTests
	{
		[Fact]
		public void Convert_RandomObject_Stream()
		{
			// Test data
			TestObject testObject = new()
			{
				Test = "test"
			};

			// No Setup

			// Act
			Stream result = StreamConverter.Convert(testObject) ?? new MemoryStream();

			// Assert
			string stringResult = new StreamReader(result).ReadToEnd();

			Assert.Equal("{\"Test\":\"test\"}", stringResult);

			// No Teardown
		}

		[Fact]
		public void Convert_String_Stream()
		{
			// No Test data
			string testData = "test";

			// No Setup

			// Act
			Stream result = StreamConverter.Convert(testData) ?? new MemoryStream();

			// Assert
			string stringResult = new StreamReader(result).ReadToEnd();

			Assert.Equal(testData, stringResult);

			// No Teardown
		}

		[Fact]
		public void Convert_Null_Stream()
		{
			// No Test data
			string? testData = null;

			// No Setup

			// Act
			Stream result = StreamConverter.Convert(testData) ?? new MemoryStream();

			// Assert
			string stringResult = new StreamReader(result).ReadToEnd();

			Assert.Equal(string.Empty, stringResult);

			// No Teardown
		}

		[Fact]
		public void Convert_Int_Stream()
		{
			// No Test data
			int testData = 10;

			// No Setup

			// Act
			Stream result = StreamConverter.Convert(testData) ?? new MemoryStream();

			// Assert
			string stringResult = new StreamReader(result).ReadToEnd();

			Assert.Equal(testData.ToString(), stringResult);

			// No Teardown
		}

		[Fact]
		public void Convert_Decimal_Stream()
		{
			// No Test data
			decimal testData = 10;

			// No Setup

			// Act
			Stream result = StreamConverter.Convert(testData) ?? new MemoryStream();

			// Assert
			string stringResult = new StreamReader(result).ReadToEnd();

			Assert.Equal(testData.ToString(), stringResult);

			// No Teardown
		}
	}
}

