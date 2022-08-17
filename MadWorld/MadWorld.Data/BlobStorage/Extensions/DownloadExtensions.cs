using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.BlobStorage.Extensions
{
	public static class DownloadExtensions
	{
		public static string GetBlobFileName(this Download download)
        {
			return $"{download.RowKey}.{download.Extention}";
        }
	}
}

