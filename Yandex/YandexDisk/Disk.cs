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
        public async void UpLoad(string diskPath, string localPath, bool isOwerwrite = false)
            => await new DiskHttpApi(Token).Files.UploadFileAsync(diskPath, isOwerwrite, localPath, CancellationToken.None);

        /// <summary>
        /// Asynchronous disk loading.
        /// </summary>
        /// <param name="diskPath">Path on disk with extension.</param>
        /// <param name="localPath">Local path with extension.</param>
        public async void DownLoad(string diskPath, string localPath)
            => await new DiskHttpApi(Token).Files.DownloadFileAsync(diskPath, localPath);
    }
}
