using SwiftlyS2.Shared;

namespace SwiftlyExtensions.Services;

public class SwiftlyExtensionsService(ISwiftlyCore _core) : ISwiftlyExtensionsService
{
    public IServerSideClientManager ServerSideClientManager { get; } =
        new ServerSideClientManager(_core);

    public IGameFunctions GameFunctions { get; } = new GameFunctionsWrapper();
}
