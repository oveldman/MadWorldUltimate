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

			string body = GetStringFromObject(item);
			byte[] byteArray = Encoding.ASCII.GetBytes(body);
			return new MemoryStream(byteArray);
		}

		private static string GetStringFromObject<T>(T item)
        {
			Type itemType = typeof(T);

			if (itemType is not null && itemType.IsPrimitiveType())
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

