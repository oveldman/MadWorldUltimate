﻿using System;
using Azure.Storage.Blobs;
using MadWorld.Data.BlobStorage.Extensions;
using MadWorld.Data.BlobStorage.Interfaces;

namespace MadWorld.Data.BlobStorage
{
	public sealed class BlobContainerContext : IBlobContainerClient
	{
		private readonly BlobContainerClient _client;

		public BlobContainerContext(BlobContainerClient containerClient)
		{
			_client = containerClient;
		}

		public IBlobClient GetBlobClient(string blobName)
		{
			var blobClient = _client.GetBlobClient(blobName);
			return new BlobFileClient(blobClient);
		}
	}
}

