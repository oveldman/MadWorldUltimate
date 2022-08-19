using System;
using System.Text;
using Newtonsoft.Json;

namespace MadWorld.Shared.Common
{
	public static class StreamConverter
	{
		public static Stream Convert<T>(T item)
        {
			if (item is null)
            {
				return new MemoryStream();
            }

			var body = GetStringFromObject(item);
			var byteArray = Encoding.ASCII.GetBytes(body);
			return new MemoryStream(byteArray);
		}

		private static string GetStringFromObject<T>(T item)
        {
			var itemType = typeof(T);

			if (itemType.IsPrimitiveType())
            {
				return item?.ToString() ?? string.Empty;
            }

			return JsonConvert.SerializeObject(item);
		}

		private static bool IsPrimitiveType(this Type type)
        {
			return type.IsPrimitive || type == typeof(string) || type == typeof(decimal);
		}
	}
}

