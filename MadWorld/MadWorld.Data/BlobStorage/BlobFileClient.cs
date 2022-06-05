﻿using System;
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public class BlobFileClient : IBlobClient
	{
		private BlobClient _blobClient;

		public BlobFileClient(BlobClient client)
		{
			_blobClient = client;
		}

		public Response<BlobDownloadResult> DownloadContent()
        {
			return _blobClient.DownloadContent();
        }

		public Response<BlobContentInfo> Upload(Stream content)
        {
			return _blobClient.Upload(content);
		}
	}
}

