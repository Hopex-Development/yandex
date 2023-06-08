using System.Threading;
using YandexDisk.Client.Clients;
using YandexDisk.Client.Http;

namespace Hopex.YandexDisk
{
    /// <summary>
    /// YandexDisk workflow.
    /// </summary>
    public class Disk
    {
        /// <summary>
        /// Account token.
        /// </summary>
        private string Token { get; }

        /// <summary>
        /// YandexDisk workflow.
        /// </summary>
        /// <param name="token">Account token.</param>
        public Disk(string token) => Token = token;

        /// <summary>
        /// Asynchronously uploading a file to disk.
        /// </summary>
        /// <param name="diskPath">Path on disk with extension.</param>
        /// <param name="localPath">Local path with extension.</param>
        /// <param name="isOwerwrite">Need overwrite file.</param>
        public async void UploadFile(string diskPath, string localPath, bool isOwerwrite = false)
            => await new DiskHttpApi(Token)
            .Files
            .UploadFileAsync(
                path: diskPath, 
                overwrite: isOwerwrite, 
                localFile: localPath,
                cancellationToken: CancellationToken.None
            );

        /// <summary>
        /// Asynchronous disk loading.
        /// </summary>
        /// <param name="diskPath">Path on disk with extension.</param>
        /// <param name="localPath">Local path with extension.</param>
        public async void DownLoadFile(string diskPath, string localPath)
            => await new DiskHttpApi(Token)
            .Files
            .DownloadFileAsync(
                path: diskPath, 
                localFile: localPath
            );
    }
}
