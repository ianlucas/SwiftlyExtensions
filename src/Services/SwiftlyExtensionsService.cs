using SwiftlyS2.Shared;

namespace SwiftlyExtensions.Services;

public class SwiftlyExtensionsService(ISwiftlyCore _core) : IExtensionService
{
    public IServerSideClientManager ServerSideClientManager { get; } =
        new ServerSideClientManager(_core);
}
