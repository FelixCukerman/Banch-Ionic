using BookStore.BLL.Interfaces;
using BookStore.Shared.Interfaces;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Sharing;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.BLL.Providers
{
    public class DropBoxManager : IDropBoxManager
    {
        private IApplicationConfiguration _applicationConfiguration { get; set; }

        public DropBoxManager(IApplicationConfiguration applicationConfiguration)
        {
            _applicationConfiguration = applicationConfiguration;
        }

        public async Task UploadFile(byte[] content, int bookId)
        {
            var client = new DropboxClient(_applicationConfiguration.DropBoxAccessToken);

            using (var memory = new MemoryStream(content))
            {
                await client.Files.UploadAsync($"/{bookId}.png", WriteMode.Overwrite.Instance, body: memory);
            }
        }

        public async Task<string> GetFileLink(int bookId)
        {
            var client = new DropboxClient(_applicationConfiguration.DropBoxAccessToken);

            string remotePath = $"/{bookId}.png";
            string rawOption = "raw=1";
            string url = string.Empty;
            string result = string.Empty;

            try
            {
                ListSharedLinksResult links = await client.Sharing.ListSharedLinksAsync(remotePath);
                url = links.Links.FirstOrDefault().Url;
            }
            catch(Exception ex)
            {
                SharedLinkMetadata metadata = await client.Sharing.CreateSharedLinkWithSettingsAsync(remotePath);
                url = metadata.Url;
            }

            result = $"{url}&{rawOption}";

            return result;
        }
    }
}
