using BookStore.Shared.Interfaces;

namespace BookStore.Shared.Configuration
{
    public class ApplicationConfiguration : IApplicationConfiguration
    {
        public string DropBoxAppKey { get; private set; }
        public string DropBoxAppSecret { get; private set; }
        public string DropBoxAccessToken { get; private set; }

        public ApplicationConfiguration(
            string dropBoxAppKey,
            string dropBoxAppSecret,
            string dropBoxAccessToken
        )
        {
            DropBoxAppKey = dropBoxAppKey;
            DropBoxAppSecret = dropBoxAppSecret;
            DropBoxAccessToken = dropBoxAccessToken;
        }
    }
}
