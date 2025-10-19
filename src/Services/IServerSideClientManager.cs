using SwiftlyS2.Shared.SchemaDefinitions;

namespace SwiftlyExtensions.Services;

public interface IServerSideClientManager
{
    public void AddSignonMiddleware(Func<CCSPlayerController, int, bool> handler);
}
