using System;
using MadWorld.Data.TableStorage.Tables;

namespace MadWorld.Data.BlobStorage.Extentions
{
	public static class DownloadExtentions
	{
		public static string GetBlobFileName(this Download download)
        {
			return $"{download.RowKey}.{download.Extention}";
        }
	}
}

