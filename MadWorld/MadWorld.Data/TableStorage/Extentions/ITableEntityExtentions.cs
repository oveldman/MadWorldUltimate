using System;
using Azure.Data.Tables;

namespace MadWorld.Data.TableStorage.Extentions
{
	public static class ITableEntityExtentions
	{
		public static bool IsEmpty(this ITableEntity entity)
        {
			return string.IsNullOrEmpty(entity?.RowKey);
        }
	}
}

