using SwiftlyExtensions.Functions;
using SwiftlyS2.Shared.Memory;

namespace SwiftlyExtensions.Services;

public class GameFunctionsWrapper : IGameFunctions
{
    public IUnmanagedFunction<GameFunctions.IsAbleToApplySprayDelegate> IsAbleToApplySprayFn =>
        GameFunctions.IsAbleToApplySprayFn
        ?? throw new InvalidOperationException("IsAbleToApplySprayFn is not initialized.");

    public IUnmanagedFunction<GameFunctions.SetSignonStateDelegate> SetSignonStateFn =>
        GameFunctions.SetSignonStateFn
        ?? throw new InvalidOperationException("SetSignonStateFn is not initialized.");

    public IUnmanagedFunction<GameFunctions.ConnectDelegate> ConnectFn =>
        GameFunctions.ConnectFn
        ?? throw new InvalidOperationException("ConnectFn is not initialized.");
}
