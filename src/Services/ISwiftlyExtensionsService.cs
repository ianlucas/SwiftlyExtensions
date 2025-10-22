using SwiftlyExtensions.Functions;
using SwiftlyS2.Shared.Memory;

namespace SwiftlyExtensions.Services;

public interface ISwiftlyExtensionsService
{
    public IServerSideClientManager ServerSideClientManager { get; }

    public IUnmanagedFunction<GameFunctions.IsAbleToApplySprayDelegate> IsAbleToApplySprayFn { get; }

    public IUnmanagedFunction<GameFunctions.SetSignonStateDelegate> SetSignonStateFn { get; }

    public IUnmanagedFunction<GameFunctions.ConnectDelegate> ConnectFn { get; }
}
