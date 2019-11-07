namespace BookStore.Shared.Interfaces
{
    public interface IApplicationConfiguration
    {
        string DropBoxAppKey { get; }
        string DropBoxAppSecret { get; }
        string DropBoxAccessToken { get; }
    }
}
