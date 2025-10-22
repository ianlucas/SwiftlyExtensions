using SwiftlyExtensions.Functions;
using SwiftlyS2.Shared.Memory;

namespace SwiftlyExtensions.Services;

public interface IGameFunctions
{
    IUnmanagedFunction<GameFunctions.IsAbleToApplySprayDelegate> IsAbleToApplySprayFn { get; }
    IUnmanagedFunction<GameFunctions.SetSignonStateDelegate> SetSignonStateFn { get; }
    IUnmanagedFunction<GameFunctions.ConnectDelegate> ConnectFn { get; }
}
