using System;
using MadWorld.Business.Managers.Interfaces;
using MadWorld.Business.Mappers.Interfaces;
using MadWorld.Data.BlobStorage;
using MadWorld.Data.BlobStorage.Extensions;
using MadWorld.Data.BlobStorage.Interfaces;
using MadWorld.Data.TableStorage.Queries.Interfaces;
using MadWorld.Data.TableStorage.Tables;
using MadWorld.Shared.Models.AnonymousAPI.Downloader;

namespace MadWorld.Business.Managers
{
    public sealed class DownloadManager : IDownloadManager
    {
        private readonly IBlobStorageContainer _blobContainer;
        private readonly IDownloadQueries _downloadQueries;
        private readonly IDownloadMapper _mapper;

        public DownloadManager(IBlobStorageContainer blobContainer, IDownloadMapper mapper, IDownloadQueries downloadQueries)
        {
            _blobContainer = blobContainer;
            _downloadQueries = downloadQueries;
            _mapper = mapper;
        }

        public ResponseDownloadAnonymous Get(string id)
        {
            var download = _downloadQueries.GetDownload(id);

            return download.HasValue ? TranslateDownload(download.ValueOr(new Download())) : new ResponseDownloadAnonymous();
        }

        public ResponseDownloadsAnonymous GetAll()
        {
            var downloads = _downloadQueries.GetDownloads();

            return new ResponseDownloadsAnonymous
            {
                Downloads = _mapper.Translate<List<Download>, List<DownloadAnonymousDto>>(downloads)
            };
        }

        private ResponseDownloadAnonymous TranslateDownload(Download download)
        {
            var response = _mapper.Translate<Download, ResponseDownloadAnonymous>(download);
            response.BodyBase64 = _blobContainer.DownloadBase64(download.GetBlobFileName(), BlobPathNames.Downloads);
            response.Found = true;
            return response;
        }
    }
}

