using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.BlobStorage;
using MadWorld.Data.BlobStorage.Extensions;
using MadWorld.Data.BlobStorage.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.API.Common;
using MadWorld.Shared.Models.API.Downloads;

namespace MadWorld.Business.Managers
{
	public sealed class DownloadAdminManager : IDownloadAdminManager
	{
		private const string AddErrorMessage = "Something went wrong while adding a new file";
		private const string UpdateErrorMessage = "Something went wrong while updating a file";

		private readonly IBlobStorageContainer _blobContainer;
		private readonly IDownloadQueries _downloadQueries;
		private readonly IDownloadMapper _mapper;

		public DownloadAdminManager(IBlobStorageContainer blobContainer, IDownloadMapper mapper, IDownloadQueries downloadQueries)
		{
			_blobContainer = blobContainer;
			_downloadQueries = downloadQueries;
			_mapper = mapper;
		}

		public CommonResponse DeleteDownload(string id)
        {
			Option<Download> downloadOption = _downloadQueries.GetDownload(id);

			if (downloadOption.HasValue)
            {
				Download download = downloadOption.ValueOr(new Download());
				download.IsDeleted = true;
				_blobContainer.Delete(download.GetBlobFileName(), BlobPathNames.Downloads);
				_downloadQueries.UpdateDownload(download);
			}

			return new()
			{
				Succeed = true
			};
		}

		public ResponseDownload GetDownload(string id, bool getBody)
        {
			Option<Download> download = _downloadQueries.GetDownload(id);

			if (download.HasValue)
            {
				return CreateDownload(download.ValueOr(new Download()), getBody);
			}

			return new()
			{
				Found = false
			};
		}

		private ResponseDownload CreateDownload(Download download, bool getBody)
        {
			DownloadDto downloadDto = _mapper.Translate<Download, DownloadDto>(download);

			if (getBody)
            {
				downloadDto.BodyBase64 = _blobContainer.DownloadBase64(download.GetBlobFileName(), BlobPathNames.Downloads);
			}

			return new()
			{
				Found = true,
				Download = downloadDto
			};
        }

		public ResponseDownloads GetAllDownloads()
        {
			List<Download> downloads = _downloadQueries.GetDownloads();
			List<DownloadDto> downloadDtos = _mapper.Translate<List<Download>, List<DownloadDto>>(downloads);
			return new()
			{
				Downloads = downloadDtos
			};
        }

		public CommonResponse SaveDownload(DownloadDto download)
        {
			if (download.IsNew)
            {
				return AddDownload(download);
            }
			else
            {
				return TryUpdateDownload(download);
			}
        }

		private CommonResponse AddDownload(DownloadDto downloadDto)
        {
			Download download = _mapper.Translate<DownloadDto, Download>(downloadDto);
			download.RowKey = Guid.NewGuid().ToString();
			bool succeed = _downloadQueries.AddDownload(download);

			if (succeed)
            {
				return AddDownloadToBlobs(download, downloadDto.BodyBase64);
			}

			return new()
			{
				ErrorMessage = AddErrorMessage
			};
        }

		private CommonResponse AddDownloadToBlobs(Download download, string bodyBase64)
        {
			bool succeed = _blobContainer.UploadBase64(download.GetBlobFileName(), bodyBase64, download.Content, BlobPathNames.Downloads);

			if (succeed)
			{
				return new()
				{
					Succeed = true
				};
			}

			return new()
			{
				ErrorMessage = AddErrorMessage
			};
		}

		private CommonResponse TryUpdateDownload(DownloadDto downloadDto)
        {
			Option<Download> downloadOption = _downloadQueries.GetDownload(downloadDto.Id);

			if (downloadOption.HasValue)
            {
				return UpdateDownload(downloadDto, downloadOption);
            }

			return new()
			{
				ErrorMessage = UpdateErrorMessage
			};
		}

		private CommonResponse UpdateDownload(DownloadDto downloadDto, Option<Download> downloadOption)
        {
			Download download = downloadOption.ValueOr(new Download());
			download = _mapper.Translate(downloadDto, download);
			bool succeed = _downloadQueries.UpdateDownload(download);

			if (succeed)
			{
				return new()
				{
					Succeed = true
				};
			}

			return new()
			{
				ErrorMessage = UpdateErrorMessage
			};
		}
	}
}

