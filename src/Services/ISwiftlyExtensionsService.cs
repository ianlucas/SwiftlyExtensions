namespace SwiftlyExtensions.Services;

public interface ISwiftlyExtensionsService
{
    public IServerSideClientManager ServerSideClientManager { get; }

    public IGameFunctions GameFunctions { get; }
}
